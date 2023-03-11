namespace InterviewTask.WebApi.Data;

public class RandomDateTime
{
    readonly DateTime start;
    readonly Random gen;

    public RandomDateTime()
    {
        start = new DateTime(2022, 1, 1);
        gen = new Random();
    }

    public DateTime Next()
    {
        return start.AddDays(gen.Next(0, 366));
    }
}
