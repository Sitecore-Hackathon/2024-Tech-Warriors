using DowntimeNotification.Models;
using Sitecore.Diagnostics;
using System.Linq;
using System.Xml.Linq;

namespace DowntimeNotification.Helpers
{
    public static class DialogFormHelper
    {
        public static DowntimeNotificationFormModel Parse(string result)
        {
            Assert.ArgumentNotNull((object)result, nameof(result));
            DowntimeNotificationFormModel downtimeNotificationFormModel = new DowntimeNotificationFormModel();
            XElement root = XDocument.Parse(result).Root;

            var title = root.Elements().Where(x => x.Name == "Title")?.FirstOrDefault();
            if (title != null)
            {
                downtimeNotificationFormModel.Title = title.FirstNode.ToString();
            }

            var startTime = root.Elements().Where(x => x.Name == "StartTime")?.FirstOrDefault();
            if (startTime != null)
            {
                downtimeNotificationFormModel.StartTime = startTime.FirstNode.ToString();
            }

            var endTime = root.Elements().Where(x => x.Name == "EndTime")?.FirstOrDefault();
            if (endTime != null)
            {
                downtimeNotificationFormModel.EndTime = endTime.FirstNode.ToString();
            }

            return downtimeNotificationFormModel;
        }
    }
}
