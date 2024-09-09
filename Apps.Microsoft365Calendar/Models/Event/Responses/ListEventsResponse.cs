using Apps.Microsoft365Calendar.Models.Dtos;

namespace Apps.MicrosoftOutlook.Models.Event.Responses;

public class ListEventsResponse
{
    public IEnumerable<EventDto> Events { get; set; }
}