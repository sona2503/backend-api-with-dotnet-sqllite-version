using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ItemsApi.Data;
using ItemsApi.Models;

[ApiController]
[Route("items")]
public class ItemsController : ControllerBase
{
    private readonly AppDb _db;

    public ItemsController(AppDb db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _db.Items.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var item = await _db.Items.FindAsync(id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Item item)
    {
        _db.Items.Add(item);
        await _db.SaveChangesAsync();
        return Created($"/items/{item.Id}", item);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Item input)
    {
        var item = await _db.Items.FindAsync(id);
        if (item is null) return NotFound();

        item.Name = input.Name;
        item.Price = input.Price;

        await _db.SaveChangesAsync();
        return Ok(item);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _db.Items.FindAsync(id);
        if (item is null) return NotFound();

        _db.Items.Remove(item);
        await _db.SaveChangesAsync();
        return Ok(item);
    }
}
