using Blackbird.Applications.Sdk.Common;

namespace Apps.Microsoft365Calendar.Webhooks.Inputs;

public class SenderInput
{
    [Display("Sender email")]
    public string? Email { get; set; }
}