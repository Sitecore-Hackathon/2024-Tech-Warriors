using DowntimeNotification.Helpers;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;
using System.Linq;

namespace DowntimeNotification.Commands
{
    public class DisableDowntimeNotification : Command
    {
        /// <summary>
        /// Executes the command
        /// </summary>
        /// <param name="context">CommandContext</param>
        public override void Execute(CommandContext context)
        {
            Context.ClientPage.Start((object)this, "Run");
        }

        /// <summary>
        /// Disables the IsEnabled check on Notification Item
        /// </summary>
        /// <param name="args">ClientPipelineArgs</param>
        protected virtual void Run(ClientPipelineArgs args)
        {
            if (args.IsPostBack)
            {
                if (!args.HasResult)
                    return;
                if (args.Result == "yes")
                {
                    Database db = Client.ContentDatabase;
                    Item downtimeSettingsItem = db.GetItem(Constants.DownNotificationSettingsId);
                    if (downtimeSettingsItem != null)
                    {
                        Item downtimeItem = downtimeSettingsItem.Children.Where(x => x.TemplateID == Templates.DowntimeNotificationItem.Id)?.FirstOrDefault();
                        if (downtimeItem != null)
                        {
                            ItemHelper.UpdateNotificationItem(downtimeItem, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, "0");
                            SheerResponse.Alert("Downtime Notification has been disabled");
                        }
                        else
                        {
                            SheerResponse.Alert("Downtime Notification must be enabled before to disable the notification");
                        }
                    }
                }
            }
            else
            {
                SheerResponse.YesNoCancel("Are you sure you would like to disable notification message", "600px", "125px");
                args.WaitForPostBack();
            }
        }
    }
}