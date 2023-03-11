using InterviewTask.Common.Models.Responses;

namespace InterviewTask.WebApi.Interfaces;

public interface IStatisticsService
{
    Task<StatisticsResponse> GetStatistics(int storeId, DateTime startDate, DateTime endDate);
}
