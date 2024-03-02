using Sitecore.Data;
using Sitecore.Data.Items;
using System;

namespace DowntimeNotification.Helpers
{
    public static class ItemHelper
    {
        public static void CreateNotificationItem(Database db, Item parentItem, string itemName, string title, string startTimeNotificationMessage, string endTimeNotificationMessage, string startTimeMaintenance, string endTimeMaintenance, string isDisabled)
        {
            var template = db.GetTemplate(Templates.DowntimeNotificationItem.Id);
            using (new Sitecore.SecurityModel.SecurityDisabler())
            {
                try
                {
                    Item notificationItem = parentItem.Add(itemName, template);
                    UpdateNotificationItem(notificationItem, title, startTimeNotificationMessage, endTimeNotificationMessage, startTimeMaintenance, endTimeMaintenance, isDisabled);
                }
                catch (Exception ex)
                {
                    Sitecore.Diagnostics.Log.Error("Exception During  Notification Item", ex, ex);
                }
            }
        }
        public static void UpdateNotificationItem(Item notificationItem, string title, string startTimeNotificationMessage, string endTimeNotificationMessage, string startTimeMaintenance, string endTimeMaintenance, string isDisabled)
        {
            using (new Sitecore.SecurityModel.SecurityDisabler())
            {
                try
                {
                    notificationItem.Editing.BeginEdit();
                    if (!string.IsNullOrEmpty(title))
                    {
                        notificationItem["Title"] = title;
                    }
                    if (!string.IsNullOrEmpty(startTimeNotificationMessage))
                    {
                        notificationItem["StartTimeNotificationMessage"] = startTimeNotificationMessage;
                    }
                    if (!string.IsNullOrEmpty(endTimeNotificationMessage))
                    {
                        notificationItem["EndTimeNotificationMessage"] = endTimeNotificationMessage;
                    }
                    if (!string.IsNullOrEmpty(startTimeMaintenance))
                    {
                        notificationItem["StartTimeMaintenance"] = startTimeMaintenance;
                    }
                    if (!string.IsNullOrEmpty(endTimeMaintenance))
                    {
                        notificationItem["EndTimeMaintenance"] = endTimeMaintenance;
                    }
                    if (!string.IsNullOrEmpty(isDisabled))
                    {
                        notificationItem["IsEnabled"] = isDisabled;
                    }
                    notificationItem.Editing.EndEdit();
                }
                catch (Exception ex)
                {
                    Sitecore.Diagnostics.Log.Error("Exception During Updating Notification Item", ex, ex);
                }
            }
        }
    }
}
