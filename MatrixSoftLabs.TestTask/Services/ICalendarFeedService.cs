using MatrixSoftLabs.TestTask.Models;

namespace MatrixSoftLabs.TestTask.Services;

public interface ICalendarFeedService
{
    Task<List<Event>> GetEvents(DateTimeOffset startDateTimeOffset, DateTimeOffset enDateTimeOffset);
}