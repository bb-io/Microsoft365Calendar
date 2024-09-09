using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Microsoft365Calendar.DataSourceHandlers;

public class MailFolderDataSourceHandler(InvocationContext invocationContext)
    : BaseInvocable(invocationContext), IAsyncDataSourceHandler
{
    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context,
        CancellationToken cancellationToken)
    {
        var client = new MicrosoftOutlookClient(InvocationContext.AuthenticationCredentialsProviders);
        var mailFolders = await client.Me.MailFolders.GetAsync(requestConfiguration =>
            {
                requestConfiguration.QueryParameters.Select = new[] { "id", "displayName" };
                requestConfiguration.QueryParameters.Filter = $"contains(displayName, '{context.SearchString ?? ""}')";
            }
            , cancellationToken);
        
        return mailFolders.Value.ToDictionary(f => f.Id, f => f.DisplayName);
    }
}