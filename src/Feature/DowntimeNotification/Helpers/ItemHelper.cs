using Sitecore.Data;
using Sitecore.Data.Items;
using System;
using static DowntimeNotification.Templates.DowntimeNotificationItem;

namespace DowntimeNotification.Helpers
{
    public static class ItemHelper
    {
        /// <summary>
        /// Creates the Notification Item
        /// </summary>
        /// <param name="db"></param>
        /// <param name="parentItem">Item</param>
        /// <param name="itemName">string</param>
        /// <param name="title">string</param>
        /// <param name="startTimeNotificationMessage">string</param>
        /// <param name="endTimeNotificationMessage">string</param>
        /// <param name="startTimeMaintenance">string</param>
        /// <param name="endTimeMaintenance">string</param>
        /// <param name="isDisabled">string</param>
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
        /// <summary>
        /// Updates the Notification Item
        /// </summary>
        /// <param name="notificationItem">Item</param>
        /// <param name="title">string</param>
        /// <param name="startTimeNotificationMessage">string</param>
        /// <param name="endTimeNotificationMessage">string</param>
        /// <param name="startTimeMaintenance">string</param>
        /// <param name="endTimeMaintenance">string</param>
        /// <param name="isDisabled">string</param>
        public static void UpdateNotificationItem(Item notificationItem, string title, string startTimeNotificationMessage, string endTimeNotificationMessage, string startTimeMaintenance, string endTimeMaintenance, string isDisabled)
        {
            using (new Sitecore.SecurityModel.SecurityDisabler())
            {
                try
                {
                    notificationItem.Editing.BeginEdit();
                    if (!string.IsNullOrEmpty(title))
                    {
                        notificationItem[Fields.TitleFieldName] = title;
                    }
                    if (!string.IsNullOrEmpty(startTimeNotificationMessage))
                    {
                        notificationItem[Fields.StartTimeNotificationMessageFieldName] = startTimeNotificationMessage;
                    }
                    if (!string.IsNullOrEmpty(endTimeNotificationMessage))
                    {
                        notificationItem[Fields.EndTimeNotificationMessageFieldName] = endTimeNotificationMessage;
                    }
                    if (!string.IsNullOrEmpty(startTimeMaintenance))
                    {
                        notificationItem[Fields.StartTimeMaintenanceFieldName] = startTimeMaintenance;
                    }
                    if (!string.IsNullOrEmpty(endTimeMaintenance))
                    {
                        notificationItem[Fields.EndTimeMaintenanceFieldName] = endTimeMaintenance;
                    }
                    if (!string.IsNullOrEmpty(isDisabled))
                    {
                        notificationItem[Fields.IsEnabledFieldName] = isDisabled;
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
