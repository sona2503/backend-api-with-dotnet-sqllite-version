using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ItemsApi.Data;
using ItemsApi.Models;

[ApiController]
[Route("toko")]
public class TokoController : ControllerBase
{
    private readonly AppDb _db;

    public TokoController(AppDb db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _db.Tokos.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var toko = await _db.Tokos.FindAsync(id);
        return toko is null ? NotFound() : Ok(toko);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Toko toko)
    {
        _db.Tokos.Add(toko);
        await _db.SaveChangesAsync();
        return Created($"/toko/{toko.Id}", toko);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Toko input)
    {
        var toko = await _db.Tokos.FindAsync(id);
        if (toko is null) return NotFound();

        toko.Nama = input.Nama;
        toko.Alamat = input.Alamat;

        await _db.SaveChangesAsync();
        return Ok(toko);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var toko = await _db.Tokos.FindAsync(id);
        if (toko is null) return NotFound();

        _db.Tokos.Remove(toko);
        await _db.SaveChangesAsync();
        return Ok(toko);
    }
}
