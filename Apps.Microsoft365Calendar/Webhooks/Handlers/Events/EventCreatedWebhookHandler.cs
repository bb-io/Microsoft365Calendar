using Apps.Microsoft365Calendar.Webhooks.Inputs;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Microsoft365Calendar.Webhooks.Handlers.Events;

public class EventCreatedWebhookHandler([WebhookParameter(true)] CalendarInput input)
    : BaseWebhookHandler(input, SubscriptionEvent)
{
    private const string SubscriptionEvent = "created";

    protected override string GetResource()
    {
        var calendarInput = (CalendarInput)WebhookInput;
        var resource = $"/me/calendars/{calendarInput.CalendarId}/events";
        return resource;
    }
}