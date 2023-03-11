using InterviewTask.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace InterviewTask.WebApi.Interfaces
{
    public interface IEntriesRepository
    {
        Task<IEnumerable<Entry>> GetEntries();

        Task<IEnumerable<Entry>> GetEntriesByStoreId(int storeId);
        Task<Entry?> GetEntry(int id);
        Task PutEntry(int id, Entry entry);
        Task<int> PostEntry(Entry entry);
        Task DeleteEntry(int id);
    }
}
