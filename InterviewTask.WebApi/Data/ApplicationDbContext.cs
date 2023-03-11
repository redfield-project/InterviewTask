using InterviewTask.Common.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace InterviewTask.WebApi.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Store> Stores { get; set; }
    public DbSet<Entry> Entries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Entry>()
            .HasOne(e => e.Store)
            .WithMany(s => s.Entries)
            .HasForeignKey(s => s.StoreForeignKey);

        List<Store> stores = new List<Store>();
        for (int i = 0; i <= 10; i++)
        {
            var store = new Store()
            {
                Id = i + 1,
                Name = $"Name{i}",
                City = $"City{i}",
                Country = $"Country{i}"
            };

            stores.Add(store);
        }

        var entryId = 1;
        List<Entry> entries = new List<Entry>();
        foreach (var store in stores)
        {
            for (int x = 0; x <= 50; x++)
            {
                RandomDateTime date = new RandomDateTime();
                entries.Add(new Entry() { Id = entryId++, EntryDate = date.Next(), StoreForeignKey = store.Id });
            }
        }

        modelBuilder.Entity<Store>().HasData(stores);
        modelBuilder.Entity<Entry>().HasData(entries);

        base.OnModelCreating(modelBuilder);
    }
}
