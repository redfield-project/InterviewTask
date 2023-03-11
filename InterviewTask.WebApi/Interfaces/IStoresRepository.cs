using InterviewTask.Common.Models;

namespace InterviewTask.WebApi.Interfaces
{
    public interface IStoresRepository
    {
        Task<IEnumerable<Store>> GetStores();
        Task<Store?> GetStore(int id);
        Task PutStore(int id, Store store);
        Task<int> PostStore(Store store);
        Task DeleteStore(int id);
    }
}
