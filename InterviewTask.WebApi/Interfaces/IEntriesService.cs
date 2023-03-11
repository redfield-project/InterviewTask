using InterviewTask.Common.Models;
using InterviewTask.Common.Models.DTOs;
using InterviewTask.Common.Models.Responses;

namespace InterviewTask.WebApi.Interfaces;

public interface IEntriesService
{
    Task<BaseResponse> AddEntry(EntryDTO entryDTO);
}
