using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private Sitecore.Data.Fields.DateField StartTime;
        private Sitecore.Data.Fields.DateField EndTime;

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
                StartTime = (Sitecore.Data.Fields.DateField)NotificationItem.Fields[Templates.DowntimeNotificationItem.Fields.StartTime];
                EndTime = (Sitecore.Data.Fields.DateField)NotificationItem.Fields[Templates.DowntimeNotificationItem.Fields.EndTime];

                var currentDateTime = Sitecore.DateUtil.ToUniversalTime(DateTime.Now);

                if (currentDateTime < StartTime.DateTime || currentDateTime > EndTime.DateTime)
                {
                    return false;
                }

                return true;
            }
        }

        public String GetNotificationMessage()
        {            
            var title = Sitecore.StringUtil.GetString(NotificationItem[Templates.DowntimeNotificationItem.Fields.Title], string.Empty);
            return $"{title}: Start time: {StartTime} UTC, End time: {EndTime}";
        }
    }
}
