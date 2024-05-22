using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using MatrixSoftLabs.TestTask.Models;

namespace MatrixSoftLabs.TestTask.Services;

public class GoogleCalendarFeedService : ICalendarFeedService
{
    private readonly CalendarService _calendarService;
    private readonly string _swedenTimeZone = "Europe/Stockholm";
    private readonly string _swedenCalendarId = "en.swedish.official#holiday@group.v.calendar.google.com";

    public GoogleCalendarFeedService(CalendarService calendarService)
    {
        _calendarService = calendarService;
    }

    public async Task<List<Event>> GetEvents(DateTimeOffset startDateTimeOffset, DateTimeOffset enDateTimeOffset)
    {
        var request = _calendarService.Events.List(_swedenCalendarId);
        request.TimeMinDateTimeOffset = startDateTimeOffset;
        request.TimeMaxDateTimeOffset = enDateTimeOffset;
        request.TimeZone = _swedenTimeZone;
        var response = await request.ExecuteAsync();
        var result = response.Items.Select(e => new Event()
        {
            Id = e.Id,
            AllDay = true,
            Title = e.Summary,
            Description = e.Description,
            Start = e.Start.Date,
            End = e.End.Date
        }).ToList();
        return result;
    }
}