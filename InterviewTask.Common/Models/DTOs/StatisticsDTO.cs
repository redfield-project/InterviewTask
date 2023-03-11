using System.ComponentModel.DataAnnotations;

namespace InterviewTask.Common.Models.DTOs;

public class StatisticsDTO
{
    public int StoreId { get; set; }
    [Required]
    public DateTime? StartDate { get; set; }
    [Required]
    public DateTime? EndDate { get; set; }
}
