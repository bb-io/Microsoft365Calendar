using Apps.MicrosoftOutlook.Webhooks.Payload;
using Blackbird.Applications.Sdk.Common.Authentication;

namespace Apps.Microsoft365Calendar.Webhooks.Lists.ItemGetters;

public abstract class ItemGetter<T>(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
{
    protected readonly IEnumerable<AuthenticationCredentialsProvider> AuthenticationCredentialsProviders = authenticationCredentialsProviders;

    public abstract Task<T?> GetItem(EventPayload eventPayload);
}