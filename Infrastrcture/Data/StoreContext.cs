using System;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastrcture.Data;

public class StoreContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
}
