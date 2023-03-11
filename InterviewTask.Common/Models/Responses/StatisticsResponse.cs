namespace InterviewTask.Common.Models.Responses;

public class StatisticsResponse : BaseResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public List<Statistic> Statistics { get; set; } = new List<Statistic>();
}
