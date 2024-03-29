﻿using System.Xml.Linq;

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
            XElement element = new XElement(Constants.RootXMLElement);
            if (!string.IsNullOrEmpty(this.Title))
                element.Add(new XElement(Constants.TitleXMLElement, this.Title));
            if (!string.IsNullOrEmpty(this.StartTimeNotificationMessage))
                element.Add(new XElement(Constants.StartTimeNotificationMessageXMLElement, this.StartTimeNotificationMessage));
            if (!string.IsNullOrEmpty(this.EndTimeNotificationMessage))
                element.Add(new XElement(Constants.EndTimeNotificationMessageXMLElement, this.EndTimeNotificationMessage));
            if (!string.IsNullOrEmpty(this.StartTimeMaintenance))
                element.Add(new XElement(Constants.StartTimeMaintenanceXMLElement, this.StartTimeMaintenance));
            if (!string.IsNullOrEmpty(this.EndTimeMaintenance))
                element.Add(new XElement(Constants.EndTimeMaintenanceXMLElement, this.EndTimeMaintenance));
            return new XDocument(new object[1]
             {
                (object) element
             }).ToString();
        }
    }
}