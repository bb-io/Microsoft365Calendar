using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Microsoft365Calendar.DataSourceHandlers;

public class RecurrencePatternDataSourceHandler(InvocationContext invocationContext)
    : BaseInvocable(invocationContext), IDataSourceHandler
{
    public Dictionary<string, string> GetData(DataSourceContext context)
    {
        return new[] { "Daily", "Weekly", "Monthly" }.ToDictionary(p => p, p => p);
    }
}