namespace InterviewTask.WebApi.Services;

using AutoMapper;
using InterviewTask.Common.Models;
using InterviewTask.Common.Models.DTOs;
using InterviewTask.Common.Models.Responses;
using InterviewTask.WebApi.Interfaces;

public class StoresService : IStoresService
{
    private readonly IStoresRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<StoresService> _logger;

    public StoresService(IStoresRepository repository, IMapper mapper, ILogger<StoresService> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<ExtendedResponse> AddStore(StoreDTO storeDTO)
    {
        var store = _mapper.Map<Store>(storeDTO);

        try
        {
            var id = await _repository.PostStore(store);
            return new ExtendedResponse { Id = id, Status = true, Message = null };
        }
        catch (Exception ex)
        {
            _logger.LogError("{ex}", ex.Message);
            return new ExtendedResponse { Status = false, Message = "An unexpected exception occurred." };
        }
    }

    public async Task<StoreResponse> GetStore(int id)
    {
        try
        {
            var store = await _repository.GetStore(id);
            if (store != null)
            {
                return new StoreResponse { Id = store.Id, Name = store.Name, City = store.City, Country = store.Country, Status = true, Message = null };
            }
            return new StoreResponse { Status = false, Message = "Store don`t exists." };
        }
        catch (Exception ex)
        {
            _logger.LogError("{ex}", ex.Message);
            return new StoreResponse { Status = false, Message = "An unexpected exception occurred." };
        }
    }

    public async Task<int[]> GetStoresList()
    {
        var stores = await _repository.GetStores();
        var ids = stores.Select(x => x.Id).ToArray();
        return ids;
    }

    public async Task<ExtendedResponse> UpdateStore(Store store)
    {
        var id = store.Id;

        try
        {
            await _repository.PutStore(id, store);
            return new ExtendedResponse { Id = id, Status = true, Message = null };
        }
        catch (Exception ex)
        {
            _logger.LogError("{ex}", ex.Message);
            return new ExtendedResponse { Status = false, Message = "An unexpected exception occurred." };
        }
    }

    public async Task<BaseResponse> DeleteStore(int id)
    {
        try
        {
            await _repository.DeleteStore(id);
            return new BaseResponse { Status = true, Message = null };
        }
        catch (Exception ex)
        {
            _logger.LogError("{ex}", ex.Message);
            return new BaseResponse { Status = false, Message = "An unexpected exception occurred." };
        }
    }
}
