using System.Xml.Linq;

namespace DowntimeNotification.Models
{
    public class DowntimeNotificationFormModel
    {
        public string Title;
        public string StartTimeNotificationMessage;
        public string EndTimeNotificationMessage;
        public string StartTimeMaintenance;
        public string EndTimeMaintenance;
        public override string ToString()
        {
            XElement element = new XElement("DowntimeNotification");
            if (!string.IsNullOrEmpty(this.Title))
                element.Add(new XElement("Title", this.Title));
            if (!string.IsNullOrEmpty(this.StartTimeNotificationMessage))
                element.Add(new XElement("StartTimeNotificationMessage", this.StartTimeNotificationMessage));
            if (!string.IsNullOrEmpty(this.EndTimeNotificationMessage))
                element.Add(new XElement("EndTimeNotificationMessage", this.EndTimeNotificationMessage));
            if (!string.IsNullOrEmpty(this.StartTimeMaintenance))
                element.Add(new XElement("StartTimeMaintenance", this.StartTimeMaintenance));
            if (!string.IsNullOrEmpty(this.EndTimeMaintenance))
                element.Add(new XElement("EndTimeMaintenance", this.EndTimeMaintenance));
            return new XDocument(new object[1]
             {
                (object) element
             }).ToString();
        }
    }
}