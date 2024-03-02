using Sitecore.Data;

namespace DowntimeNotification
{
    public static class Constants
    {
        public static readonly ID DownNotificationSettingsId = new ID("{3AE921A8-FAA1-4C83-B883-727864931727}");
        public const string DowntimeNotificationItemName = "DownTimeNofication";
        public const string DowntimeNotificationDialogControl = "control:DowntimeNotification";
        public const string DowntimeNotificationDisableConfirmMessage = "Are you sure you would like to disable notification message";
        public const string DowntimeNotificationEnabled = "Downtime Notification has been enabled";
        public const string DowntimeNotificationDisabled = "Downtime Notification has been disabled";
        public const string DowntimeNotificationItemCheck = "Downtime Notification must be enabled before to disable the notification";
        public const string TitleXMLElement = "Title";
        public const string StartTimeNotificationMessageXMLElement = "StartTimeNotificationMessage";
        public const string EndTimeNotificationMessageXMLElement = "EndTimeNotificationMessage";
        public const string StartTimeMaintenanceXMLElement = "StartTimeMaintenance";
        public const string EndTimeMaintenanceXMLElement = "EndTimeMaintenance";
    }
    public static class Templates
    {
        public struct DowntimeNotificationItem
        {
            public static readonly ID Id = new ID("{29786CA7-8DBE-41DE-880D-77B649C0F98B}");

            public struct Fields
            {
                public const string TitleFieldName = "Title";
                public static ID TitleFieldID = ID.Parse("{9864B191-1FF5-4CB0-B10E-D14B70F4AAFA}");
                public const string StartTimeNotificationMessageFieldName = "StartTimeNotificationMessage";
                public static ID StartTimeNotificationMessageFieldID = ID.Parse("{20ECF499-45DB-445C-8654-8614B8B8A51B}");
                public const string EndTimeNotificationMessageFieldName = "EndTimeNotificationMessage";
                public static ID EndTimeNotificationMessageFieldID = ID.Parse("{B9AE1D45-C72B-4F2E-9D66-1E4D4C03808E}");
                public const string StartTimeMaintenanceFieldName = "StartTimeMaintenance";
                public static ID StartTimeMaintenanceFieldID = ID.Parse("{A4CE50E1-2980-475C-92D3-C00A0DF7F293}");
                public const string EndTimeMaintenanceFieldName = "EndTimeMaintenance";
                public static ID EndTimeMaintenanceFieldID = ID.Parse("{8270526C-20BD-4611-A456-68A2896946F8}");
                public const string IsEnabledFieldName = "IsEnabled";
                public static ID IsEnabledFieldID = ID.Parse("{C52538DD-30AE-47C5-B290-D636EAA05DC1}");
            }
        }
    }
}
