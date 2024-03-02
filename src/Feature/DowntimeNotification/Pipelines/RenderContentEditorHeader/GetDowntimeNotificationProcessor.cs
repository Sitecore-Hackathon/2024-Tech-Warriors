using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Shell.Applications.ContentEditor.Pipelines.RenderContentEditorHeader;

namespace DowntimeNotification.Pipelines.RenderContentEditorHeader
{
    public class GetDowntimeNotificationProcessor
    {
        public void Process(RenderContentEditorHeaderArgs args)
        {
            Assert.ArgumentNotNull(args, nameof(args));

            Item obj = args.Item;

            using(HtmlTextWriter htmlTextWriter = new HtmlTextWriter((TextWriter) new StringWriter()))
            {                
                htmlTextWriter.Write("<script src=\"/scripts/notification.js\"></script>");
                htmlTextWriter.Write("<script>showNotification('This is editor downtime message');</script>");
                args.EditorFormatter.AddLiteralControl(args.Parent, htmlTextWriter.InnerWriter.ToString());
            }
        }
    }
}
