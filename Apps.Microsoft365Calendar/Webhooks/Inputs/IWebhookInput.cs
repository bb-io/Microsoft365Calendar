using Blackbird.Applications.Sdk.Common;

namespace Apps.Microsoft365Calendar.Webhooks.Inputs;

public class IWebhookInput
{
    [Display("Shared emails")]
    public List<string>? SharedEmails { get; set; }
}