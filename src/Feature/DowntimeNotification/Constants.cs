﻿using Sitecore.Data;

namespace DowntimeNotification
{
    public static class Constants
    {
        public static readonly ID DownNotificationSettingsId = new ID("{3AE921A8-FAA1-4C83-B883-727864931727}");
    }
    public static class Templates
    {
        public struct DowntimeNotificationItem
        {
            public static readonly ID Id = new ID("{29786CA7-8DBE-41DE-880D-77B649C0F98B}");

            public struct Fields
            {
                public static ID Title = ID.Parse("{9864B191-1FF5-4CB0-B10E-D14B70F4AAFA}");
                public static ID StartTime = ID.Parse("{20ECF499-45DB-445C-8654-8614B8B8A51B}");
                public static ID EndTime = ID.Parse("{B9AE1D45-C72B-4F2E-9D66-1E4D4C03808E}");
                public static ID IsEnabled = ID.Parse("{C52538DD-30AE-47C5-B290-D636EAA05DC1}");
            }
        }
    }
}