using System.IO;
using System.Web.UI;
using DowntimeNotification.Helpers;
using Sitecore.Diagnostics;
using Sitecore.Shell.Applications.ContentEditor.Pipelines.RenderContentEditorHeader;

namespace DowntimeNotification.Pipelines.RenderContentEditorHeader
{
    public class GetDowntimeNotificationProcessor
    {
        public void Process(RenderContentEditorHeaderArgs args)
        {
            Assert.ArgumentNotNull(args, nameof(args));

            var notificationHelper = new NotificationHelper(args.Item.Database);
            if (!notificationHelper.ShowNotification)
                return;

            using (HtmlTextWriter htmlTextWriter = new HtmlTextWriter((TextWriter) new StringWriter()))
            {                
                htmlTextWriter.Write("<script src=\"/sitecore/shell/Applications/Content Manager/notification.js\"></script>");
                var message = $"<div id=\"downtimeNotification\" style=\"padding: 5px 7px; background-color: red; color: white; font-weight: 700; font-size: 16px;\"><marquee>{notificationHelper.GetNotificationMessage()}</marquee></div>";
                htmlTextWriter.Write($"<script>showNotification('{message}');</script>");
                args.EditorFormatter.AddLiteralControl(args.Parent, htmlTextWriter.InnerWriter.ToString());
            }
        }
    }
}
