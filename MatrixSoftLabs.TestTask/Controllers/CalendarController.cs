using MatrixSoftLabs.TestTask.Entity;
using MatrixSoftLabs.TestTask.Models;
using MatrixSoftLabs.TestTask.Services;
using Microsoft.AspNetCore.Mvc;

namespace MatrixSoftLabs.TestTask.Controllers;

public class CalendarController : Controller
{
    private readonly ICalendarFeedService _googleCalendarFeedService;
    private readonly MatrixSoftLabsDbContext _dbContext;

    public CalendarController(GoogleCalendarFeedService googleCalendarFeedService,
                              MatrixSoftLabsDbContext dbContext)
    {
        _googleCalendarFeedService = googleCalendarFeedService;
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        return View("Calendar");
    }
    [HttpGet]
    public async Task<IActionResult> GetEvents(string start, string end)
    {
        if (!DateTimeOffset.TryParse(start, out var startOffset))
            throw new ArgumentException(start);
        if (!DateTimeOffset.TryParse(end, out var endOffset))
            throw new ArgumentException(end);

        var events = await _googleCalendarFeedService.GetEvents(startOffset, endOffset);

        return Json(events);
    }
}