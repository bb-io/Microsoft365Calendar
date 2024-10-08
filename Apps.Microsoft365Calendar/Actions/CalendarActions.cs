using Apps.Microsoft365Calendar.Invocables;
using Apps.Microsoft365Calendar.Models.Dtos;
using Apps.MicrosoftOutlook.Models.Calendar.Requests;
using Apps.MicrosoftOutlook.Models.Calendar.Responses;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;
using Microsoft.Graph.Models;
using Microsoft.Graph.Models.ODataErrors;

namespace Apps.Microsoft365Calendar.Actions;

[ActionList]
public class CalendarActions(InvocationContext invocationContext) : AppInvocable(invocationContext)
{
     #region GET
    
    [Action("List calendars", Description = "List current user's calendars.")] 
    public async Task<ListCalendarsResponse> ListCalendars(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
    {
        var client = new MicrosoftOutlookClient(authenticationCredentialsProviders);
        var calendars = await client.Me.Calendars.GetAsync();
        return new ListCalendarsResponse
        {
            Calendars = calendars.Value.Select(c => new CalendarDto(c))
        };
    }
    
    [Action("Get calendar", Description = "Get a calendar. If calendar is not specified, default calendar is returned.")]
    public async Task<CalendarDto> GetCalendar(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        [ActionParameter] GetCalendarRequest request)
    {
        var client = new MicrosoftOutlookClient(authenticationCredentialsProviders);
        Microsoft.Graph.Models.Calendar? calendar;
        if (request == null || request.CalendarId == null)
            calendar = await client.Me.Calendar.GetAsync();
        else
        {
            try
            {
                calendar = await client.Me.Calendars[request.CalendarId].GetAsync();
            }
            catch (ODataError error)
            {
                throw new ArgumentException(error.Error.Message);
            }
        }
        
        var calendarDto = new CalendarDto(calendar);
        return calendarDto;
    }
    
    #endregion
    
    #region POST

    [Action("Create calendar", Description = "Create a new calendar.")]
    public async Task<CalendarDto> CreateCalendar(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        [ActionParameter] CreateCalendarRequest request)
    {
        var client = new MicrosoftOutlookClient(authenticationCredentialsProviders);
        var requestBody = new Microsoft.Graph.Models.Calendar
        {
            Name = request.CalendarName
        };
        try
        {
            var createdCalendar = await client.Me.Calendars.PostAsync(requestBody);
            var createdCalendarDto = new CalendarDto(createdCalendar);
            return createdCalendarDto;
        }
        catch (ODataError error)
        {
            throw new ArgumentException(error.Error.Message);
        }
    }
    
    [Action("Get users' schedule information", Description = "Get the free/busy availability information for " +
                                                                       "a collection of users in specified time period.")]
    public async Task<GetScheduleResponse> GetSchedule(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        [ActionParameter] GetScheduleRequest request)
    {
        var client = new MicrosoftOutlookClient(authenticationCredentialsProviders);
        var requestBody = new Microsoft.Graph.Me.Calendar.GetSchedule.GetSchedulePostRequestBody
        {
            Schedules = request.Emails,
            StartTime = new DateTimeTimeZone
            {
                DateTime = request.StartDateTime.ToString("yyyy-MM-ddTHH:mm:ss"),
                TimeZone = TimeZoneInfo.Local.Id
            },
            EndTime = new DateTimeTimeZone
            {
                DateTime = request.EndDateTime.ToString("yyyy-MM-ddTHH:mm:ss"),
                TimeZone = TimeZoneInfo.Local.Id
            }
        };
        try
        {
            var schedules = await client.Me.Calendar.GetSchedule.PostAsync(requestBody);
            var schedulesDto = schedules.Value.Select(s => new ScheduleDto(s));
            return new GetScheduleResponse { Schedules = schedulesDto };
        }
        catch (ODataError error)
        {
            throw new ArgumentException(error.Error.Message);
        }
    }
    
    #endregion
    
    #region PATCH

    [Action("Rename calendar", Description = "Rename a calendar. If calendar is not specified, default " +
                                                       "calendar is renamed.")]
    public async Task<CalendarDto> RenameCalendar(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        [ActionParameter] RenameCalendarRequest request)
    {
        var client = new MicrosoftOutlookClient(authenticationCredentialsProviders);
        Microsoft.Graph.Models.Calendar? renamedCalendar;
        var requestBody = new Microsoft.Graph.Models.Calendar
        {
            Name = request.CalendarName
        };
        try
        {
            if (request.CalendarId == null)
                renamedCalendar = await client.Me.Calendar.PatchAsync(requestBody);
            else
                renamedCalendar = await client.Me.Calendars[request.CalendarId].PatchAsync(requestBody);
        }
        catch (ODataError error)
        {
            throw new ArgumentException(error.Error.Message);
        }
        
        var renamedCalendarDto = new CalendarDto(renamedCalendar);
        return renamedCalendarDto;
    }
    
    #endregion
    
    #region DELETE

    [Action("Delete calendar", Description = "Delete calendar other than the default calendar.")]
    public async Task DeleteCalendar(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        [ActionParameter] DeleteCalendarRequest request)
    {
        var client = new MicrosoftOutlookClient(authenticationCredentialsProviders);
        try
        {
            await client.Me.Calendars[request.CalendarId].DeleteAsync();
        }
        catch (ODataError error)
        {
            throw new ArgumentException(error.Error.Message);
        }
    }

    #endregion
}