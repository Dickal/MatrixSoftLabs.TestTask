using MatrixSoftLabs.TestTask.Models;

namespace MatrixSoftLabs.TestTask.Services;

public class MicrosoftCalendarFeedService : ICalendarFeedService
{
    public Task<List<Event>> GetEvents(DateTimeOffset startDateTimeOffset, DateTimeOffset enDateTimeOffset)
    {
        throw new NotImplementedException();
    }
}