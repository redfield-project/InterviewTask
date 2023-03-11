namespace InterviewTask.WebApi.Repositories;

using InterviewTask.WebApi.Data;
using InterviewTask.Common.Models;
using Microsoft.EntityFrameworkCore;
using InterviewTask.WebApi.Interfaces;

public class EntriesRepository : IEntriesRepository
{
    private readonly ApplicationDbContext _context;

    public EntriesRepository(ApplicationDbContext context)
	{
        _context = context;
    }

    public async Task<IEnumerable<Entry>> GetEntries()
    {
        return await _context.Entries.ToListAsync();
    }

    public async Task<IEnumerable<Entry>> GetEntriesByStoreId(int storeId)
    {
        return await _context.Entries.Where(e => e.StoreForeignKey == storeId).ToListAsync();
    }

    public async Task<Entry?> GetEntry(int id)
    {
        return await _context.Entries.FindAsync(id);
    }

    public async Task PutEntry(int id, Entry entry)
    {
        if (id != entry.Id)
        {
            return;
        }

        _context.Entry(entry).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EntryExists(id))
            {
                return;
            }
            else
            {
                throw;
            }
        }
    }

    public async Task<int> PostEntry(Entry entry)
    {
        _context.Entries.Add(entry);
        await _context.SaveChangesAsync();

        return entry.Id;
    }

    public async Task DeleteEntry(int id)
    {
        var entry = await _context.Entries.FindAsync(id);
        if (entry == null)
        {
            return;
        }

        _context.Entries.Remove(entry);
        await _context.SaveChangesAsync();
    }

    private bool EntryExists(int id)
    {
        return _context.Entries.Any(e => e.Id == id);
    }
}
