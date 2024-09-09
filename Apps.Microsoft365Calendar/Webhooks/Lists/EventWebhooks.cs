using Apps.Microsoft365Calendar.Models.Dtos;
using Apps.Microsoft365Calendar.Webhooks.Handlers.Events;
using Apps.Microsoft365Calendar.Webhooks.Lists.ItemGetters;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Microsoft365Calendar.Webhooks.Lists;

[WebhookList]
public class EventWebhooks(InvocationContext invocationContext) : BaseWebhookList(invocationContext)
{
    [Webhook("On event created", typeof(EventCreatedWebhookHandler), 
        Description = "This webhook is triggered when a new event is created.")]
    public async Task<WebhookResponse<EventDto>> OnMessageCreated(WebhookRequest request)
    {
        return await HandleWebhookRequest(request, new EventGetter(AuthenticationCredentialsProviders));
    }
}