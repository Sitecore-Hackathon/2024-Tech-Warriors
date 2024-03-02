using DowntimeNotification.Models;
using Sitecore.Diagnostics;
using System.Linq;
using System.Xml.Linq;

namespace DowntimeNotification.Helpers
{
    public static class DialogFormHelper
    {
        /// <summary>
        /// Parse the XML response
        /// </summary>
        /// <param name="result">string</param>
        /// <returns>DowntimeNotificationFormModel</returns>
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

            var startTimeNotifcationMessage = root.Elements().Where(x => x.Name == "StartTimeNotificationMessage")?.FirstOrDefault();
            if (startTimeNotifcationMessage != null)
            {
                downtimeNotificationFormModel.StartTimeNotificationMessage = startTimeNotifcationMessage.FirstNode.ToString();
            }

            var endTimeNotificationMessage = root.Elements().Where(x => x.Name == "EndTimeNotificationMessage")?.FirstOrDefault();
            if (endTimeNotificationMessage != null)
            {
                downtimeNotificationFormModel.EndTimeNotificationMessage = endTimeNotificationMessage.FirstNode.ToString();
            }

            var startTimeMaintenance = root.Elements().Where(x => x.Name == "StartTimeMaintenance")?.FirstOrDefault();
            if (endTimeNotificationMessage != null)
            {
                downtimeNotificationFormModel.StartTimeMaintenance = startTimeMaintenance.FirstNode.ToString();
            }

            var endTimeMaintenance = root.Elements().Where(x => x.Name == "EndTimeMaintenance")?.FirstOrDefault();
            if (endTimeNotificationMessage != null)
            {
                downtimeNotificationFormModel.EndTimeMaintenance = endTimeMaintenance.FirstNode.ToString();
            }

            return downtimeNotificationFormModel;
        }
    }
}
