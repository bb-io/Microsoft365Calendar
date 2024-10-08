﻿using Apps.Microsoft365Calendar.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Microsoft365Calendar.Webhooks.Inputs;

public class MailFolderInput : IWebhookInput
{
    [Display("Message folder")]
    [DataSource(typeof(MailFolderDataSourceHandler))]
    public string MailFolderId { get; set; }
}