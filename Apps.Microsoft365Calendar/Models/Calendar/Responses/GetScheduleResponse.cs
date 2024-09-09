using Apps.Microsoft365Calendar.Models.Dtos;

namespace Apps.MicrosoftOutlook.Models.Calendar.Responses;

public class GetScheduleResponse
{
    public IEnumerable<ScheduleDto> Schedules { get; set; }
}