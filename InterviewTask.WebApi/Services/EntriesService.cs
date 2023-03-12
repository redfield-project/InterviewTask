namespace InterviewTask.WebApi.Services;

using AutoMapper;
using InterviewTask.Common.Models;
using InterviewTask.Common.Models.DTOs;
using InterviewTask.Common.Models.Responses;
using InterviewTask.WebApi.Interfaces;

public class EntriesService : IEntriesService
{
    private readonly IEntriesRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<EntriesService> _logger;

    public EntriesService(IEntriesRepository repository, IMapper mapper, ILogger<EntriesService> logger)
	{
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<BaseResponse> AddEntry(EntryDTO entryDTO)
    {
        var entry = _mapper.Map<Entry>(entryDTO);

        try
        {
            var id = await _repository.PostEntry(entry);
            return new BaseResponse { Status = true, Message = null };
        }
        catch (Exception ex)
        {
            _logger.LogError("{ex}", ex.Message);
            return new BaseResponse { Status = false, Message = "An unexpected exception occurred." };
        }
    }
}
