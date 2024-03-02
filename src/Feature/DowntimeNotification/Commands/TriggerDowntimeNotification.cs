using DowntimeNotification.Helpers;
using DowntimeNotification.Models;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Text;
using Sitecore.Web.UI.Sheer;
using System;
using System.Collections.Specialized;
using System.Linq;

namespace DowntimeNotification.Commands
{
    public class TriggerDowntimeNotification : Command
    {
        public override void Execute(CommandContext context)
        {
            NameValueCollection parameters = new NameValueCollection();
            Context.ClientPage.Start((object)this, "Run", parameters);
        }
        protected virtual void Run(ClientPipelineArgs args)
        {
            if (args.IsPostBack)
            {
                if (!args.HasResult)
                    return;
                string result = args.Result;
                DowntimeNotificationFormModel downtimeDataResult = DialogFormHelper.Parse(result);
                if (downtimeDataResult != null)
                {
                    this.CreateUpdateItem(downtimeDataResult);
                }
            }
            else
            {
                UrlString urlString = new UrlString(UIUtil.GetUri("control:DowntimeNotification"));
                SheerResponse.ShowModalDialog(urlString.ToString(), "600px", "350px", string.Empty, true);
                args.WaitForPostBack();
            }
        }

        private void CreateUpdateItem(DowntimeNotificationFormModel downtimeDataResult)
        {
            Database db = Client.ContentDatabase;
            Item downtimeSettingsItem = db.GetItem(Constants.DownNotificationSettingsId);
            if (downtimeSettingsItem != null)
            {
                Item downtimeItem = downtimeSettingsItem.Children.Where(x => x.TemplateID == Templates.DowntimeNotificationItemTemplateId)?.FirstOrDefault();
                using (new Sitecore.SecurityModel.SecurityDisabler())
                {
                    try
                    {
                        if (downtimeItem != null)
                        {
                            downtimeItem.Editing.BeginEdit();
                            downtimeItem["Title"] = downtimeDataResult.Title;
                            downtimeItem["StartTime"] = downtimeDataResult.StartTime;
                            downtimeItem["EndTime"] = downtimeDataResult.EndTime;
                            downtimeItem["IsEnabled"] = "1";
                            downtimeItem.Editing.EndEdit();
                        }
                        else
                        {
                            string itemName = $"DownTimeNofication";
                            var template = db.GetTemplate(Templates.DowntimeNotificationItemTemplateId);
                            Item newItem = downtimeSettingsItem.Add(itemName, template);
                            if (newItem != null)
                            {
                                newItem.Editing.BeginEdit();
                                newItem["Title"] = downtimeDataResult.Title;
                                newItem["StartTime"] = downtimeDataResult.StartTime;
                                newItem["EndTime"] = downtimeDataResult.EndTime;
                                newItem["IsEnabled"] = "1";
                                newItem.Editing.EndEdit();
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        Sitecore.Diagnostics.Log.Error("Exception During Saving/Creating Notification Item", ex, this);
                    }
                }
            }
        }
    }
}
