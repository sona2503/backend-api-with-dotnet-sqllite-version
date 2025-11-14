using Microsoft.EntityFrameworkCore;
using ItemsApi.Models;


namespace ItemsApi.Data;

public class AppDb : DbContext
{
    public AppDb(DbContextOptions<AppDb> options) : base(options) { }

    public DbSet<Item> Items => Set<Item>();
    public DbSet<Toko> Tokos => Set<Toko>();
}
