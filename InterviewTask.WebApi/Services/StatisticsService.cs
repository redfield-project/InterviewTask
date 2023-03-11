namespace InterviewTask.WebApi.Services;

using AutoMapper;
using InterviewTask.Common.Models;
using InterviewTask.Common.Models.Responses;
using InterviewTask.WebApi.Interfaces;

public class StatisticsService : IStatisticsService
{
    private readonly IStoresRepository _storeRepository;
    private readonly IEntriesRepository _entriesRepository;
    private readonly IMapper _mapper;

    public StatisticsService(IStoresRepository storeRepository, IEntriesRepository entriesRepository, IMapper mapper)
    {
        _storeRepository = storeRepository;
        _entriesRepository = entriesRepository;
        _mapper = mapper;
    }

    public async Task<StatisticsResponse> GetStatistics(int storeId, DateTime startDate, DateTime endDate)
    {
        var store = await _storeRepository.GetStore(storeId);
        if (store == null)
        {
            return new StatisticsResponse() { Status = false, Message = "Store dont exists." };
        }

        var statisticsResponse = _mapper.Map<StatisticsResponse>(store);

        var entries = await _entriesRepository.GetEntriesByStoreId(storeId);

        var distinctDates = entries
          .Select(d => new DateTime(d.EntryDate!.Value.Year, d.EntryDate!.Value.Month, 1))
          .Distinct()
          .ToList();

        distinctDates.Sort();

        var statistics = new List<Statistic>();
        foreach (var date in distinctDates) 
        {
            var count = entries.Where(e => e.EntryDate!.Value.Year == date.Year && e.EntryDate!.Value.Month == date.Month).Count();
            statistics.Add(new Statistic() { Date = date, Count = count });
        }

        statisticsResponse.Statistics = statistics;

        statisticsResponse.Status = true;
        statisticsResponse.Message = null;

        return statisticsResponse;
    }
}
