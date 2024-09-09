using Apps.Microsoft365Calendar.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.MicrosoftOutlook.Models.Event.Requests;

public class DeleteEventRequest
{
    [Display("Event")]
    [DataSource(typeof(EventDataSourceHandler))]
    public string EventId { get; set; }
}