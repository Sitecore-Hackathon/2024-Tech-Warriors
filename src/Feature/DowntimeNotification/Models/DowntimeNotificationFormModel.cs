using System.Xml.Linq;

namespace DowntimeNotification.Models
{
    public class DowntimeNotificationFormModel
    {
        public string Title;
        public string StartTime;
        public string EndTime;
        public override string ToString()
        {
            XElement element = new XElement("DowntimeNotification");
            if (!string.IsNullOrEmpty(this.Title))
                element.Add(new XElement("Title", this.Title));
            if (!string.IsNullOrEmpty(this.StartTime))
                element.Add(new XElement("StartTime", this.StartTime));
            if (!string.IsNullOrEmpty(this.EndTime))
                element.Add(new XElement("EndTime", this.EndTime));
            return new XDocument(new object[1]
             {
                (object) element
             }).ToString();
        }
    }
}