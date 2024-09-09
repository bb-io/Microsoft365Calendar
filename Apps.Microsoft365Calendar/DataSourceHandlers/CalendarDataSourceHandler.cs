using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Microsoft365Calendar.DataSourceHandlers;

public class CalendarDataSourceHandler(InvocationContext invocationContext)
    : BaseInvocable(invocationContext), IAsyncDataSourceHandler
{
    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context,
        CancellationToken cancellationToken)
    {
        var client = new MicrosoftOutlookClient(InvocationContext.AuthenticationCredentialsProviders);
        var calendars = await client.Me.Calendars.GetAsync(requestConfiguration =>
            requestConfiguration.QueryParameters.Select = ["id", "name"], cancellationToken);
        
        return calendars.Value
            .Where(c => context.SearchString == null 
                        || c.Name.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .ToDictionary(c => c.Id, c => c.Name);
    }
}