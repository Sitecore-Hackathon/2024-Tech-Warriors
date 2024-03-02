using DowntimeNotification.Helpers;
using Sitecore.Diagnostics;
using Sitecore.Pipelines.GetPageEditorNotifications;

namespace DowntimeNotification.Pipelines.GetPageEditorNotifications
{
    public class GetDowntimeNotification : GetPageEditorNotificationsProcessor
    {
        /// <summary>
        /// Handles notification in Experience Editor
        /// </summary>
        /// <param name="args">GetPageEditorNotificationsArgs</param>
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
