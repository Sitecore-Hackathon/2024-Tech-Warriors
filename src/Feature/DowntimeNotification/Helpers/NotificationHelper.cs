using System;
using System.Linq;

namespace DowntimeNotification.Helpers
{
    public class NotificationHelper
    {
        private readonly Sitecore.Data.Database Database;
        private readonly Sitecore.Data.Items.Item SettingItem;
        private readonly Sitecore.Data.Items.Item NotificationItem;

        public NotificationHelper(Sitecore.Data.Database database) { 
            this.Database = database;
            this.SettingItem = Database.GetItem(Constants.DownNotificationSettingsId);
            if(this.SettingItem != null && this.SettingItem.HasChildren)
            {
                NotificationItem = SettingItem.Children.FirstOrDefault();
            }
        }

        private Sitecore.Data.Fields.DateField StartTimeNotificationMessage;
        private Sitecore.Data.Fields.DateField EndTimeNotificationMessage;
        private Sitecore.Data.Fields.DateField StartTimeMaintenance;
        private Sitecore.Data.Fields.DateField EndTimeMaintenance;

        public bool ShowNotification
        {
            get
            {
                if (SettingItem == null || NotificationItem == null)
                {
                    return false;
                }

                var enabled = Sitecore.MainUtil.GetBool(NotificationItem[Templates.DowntimeNotificationItem.Fields.IsEnabled], false);
                if (!enabled)
                {
                    return false;
                }
                StartTimeNotificationMessage = NotificationItem.Fields[Templates.DowntimeNotificationItem.Fields.StartTimeNotificationMessage];
                EndTimeNotificationMessage = NotificationItem.Fields[Templates.DowntimeNotificationItem.Fields.EndTimeNotificationMessage];
                StartTimeMaintenance = NotificationItem.Fields[Templates.DowntimeNotificationItem.Fields.StartTimeMaintenance];
                EndTimeMaintenance = NotificationItem.Fields[Templates.DowntimeNotificationItem.Fields.EndTimeMaintenance];

                var currentDateTime = Sitecore.DateUtil.ToUniversalTime(DateTime.Now);

                if (currentDateTime < StartTimeNotificationMessage.DateTime || currentDateTime > EndTimeNotificationMessage.DateTime)
                {
                    return false;
                }

                return true;
            }
        }

        public String GetNotificationMessage()
        {            
            var title = Sitecore.StringUtil.GetString(NotificationItem[Templates.DowntimeNotificationItem.Fields.Title], string.Empty);
            return $"{title}: Start time: {StartTimeMaintenance} UTC, End time: {EndTimeMaintenance}";
        }
    }
}
