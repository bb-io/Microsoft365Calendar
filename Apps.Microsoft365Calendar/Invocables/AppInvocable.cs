using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Microsoft365Calendar.Invocables;

public class AppInvocable(InvocationContext invocationContext) : BaseInvocable(invocationContext)
{
    protected AuthenticationCredentialsProvider[] Creds =>
        InvocationContext.AuthenticationCredentialsProviders.ToArray();
}