namespace InterviewTask.WebApi.Repositories;

using InterviewTask.WebApi.Data;
using InterviewTask.Common.Models;
using Microsoft.EntityFrameworkCore;
using InterviewTask.WebApi.Interfaces;

public class StoresRepository : IStoresRepository
{
    private readonly ApplicationDbContext _context;

    public StoresRepository(ApplicationDbContext context)
	{
        _context = context;
    }

    public async Task<IEnumerable<Store>> GetStores()
    {
        return await _context.Stores.ToListAsync();
    }

    public async Task<Store?> GetStore(int id)
    {
        return await _context.Stores.FindAsync(id);
    }

    public async Task PutStore(int id, Store store)
    {
        if (id != store.Id)
        {
            return;
        }

        _context.Entry(store).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!StoreExists(id))
            {
                return;
            }
            else
            {
                throw;
            }
        }
    }

    public async Task<int> PostStore(Store store)
    {
        _context.Stores.Add(store);
        await _context.SaveChangesAsync();

        return store.Id;
    }

    public async Task DeleteStore(int id)
    {
        var store = await _context.Stores.FindAsync(id);
        if (store == null)
        {
            return;
        }

        _context.Stores.Remove(store);
        await _context.SaveChangesAsync();
    }

    private bool StoreExists(int id)
    {
        return _context.Stores.Any(e => e.Id == id);
    }
}
