namespace InterviewTask.Common.Models;

public class Entry : BaseEntity
{
    public DateTime? EntryDate { get; set; }

    public int StoreForeignKey { get; set; }
    public Store? Store { get; set; }
}
