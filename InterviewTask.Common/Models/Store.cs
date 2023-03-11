namespace InterviewTask.Common.Models;

public class Store : BaseEntity
{
    public string? Name { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }

    public ICollection<Entry>? Entries { get; set; }
}
