using Apps.Microsoft365Calendar.Models.Dtos;
using Apps.MicrosoftOutlook.Webhooks.Payload;
using Blackbird.Applications.Sdk.Common.Authentication;

namespace Apps.Microsoft365Calendar.Webhooks.Lists.ItemGetters;

public class EventGetter(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
    : ItemGetter<EventDto>(authenticationCredentialsProviders)
{
    public override async Task<EventDto?> GetItem(EventPayload eventPayload)
    {
        var client = new MicrosoftOutlookClient(AuthenticationCredentialsProviders);
        var calendarEvent = await client.Me.Events[eventPayload.ResourceData.Id].GetAsync();
        return new EventDto(calendarEvent);
    }
}