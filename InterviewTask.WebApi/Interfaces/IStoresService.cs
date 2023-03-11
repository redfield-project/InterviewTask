using InterviewTask.Common.Models;
using InterviewTask.Common.Models.DTOs;
using InterviewTask.Common.Models.Responses;

namespace InterviewTask.WebApi.Interfaces;

public interface IStoresService
{
    Task<ExtendedResponse> AddStore(StoreDTO storeDTO);
    Task<StoreResponse> GetStore(int id);
    Task<int[]> GetStoresList();
    Task<ExtendedResponse> UpdateStore(Store store);
    Task<BaseResponse> DeleteStore(int id);
}
