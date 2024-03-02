using DowntimeNotification.Helpers;
using Sitecore.Diagnostics;
using Sitecore.Pipelines.GetPageEditorNotifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DowntimeNotification.Pipelines.GetPageEditorNotifications
{
    public class GetDowntimeNotification : GetPageEditorNotificationsProcessor
    {
        public override void Process(GetPageEditorNotificationsArgs args)
        {
            Assert.ArgumentNotNull((object)args, nameof(args));

            var notificationHelper = new NotificationHelper(args.ContextItem.Database);

            if (!notificationHelper.ShowNotification)
                return;

            PageEditorNotification editorNotification = new PageEditorNotification(notificationHelper.GetNotificationMessage(), PageEditorNotificationType.Error);
            args.Notifications.Add(editorNotification);
        }
    }
}
