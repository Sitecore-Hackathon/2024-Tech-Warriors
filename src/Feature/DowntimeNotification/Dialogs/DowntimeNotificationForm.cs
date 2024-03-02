using DowntimeNotification.Models;
using Sitecore.Diagnostics;
using Sitecore.Web.UI.HtmlControls;
using Sitecore.Web.UI.Pages;
using Sitecore.Web.UI.Sheer;
using System;

namespace DowntimeNotification.Dialogs
{
    public class DowntimeNotificationForm : DialogForm
    {
        Edit Title;
        DateTimePicker StartTimeNotificationMessage;
        DateTimePicker EndTimeNotificationMessage;
        DateTimePicker StartTimeMaintenance;
        DateTimePicker EndTimeMaintenance;
        protected override void OnLoad(EventArgs e)
        {
            Assert.ArgumentNotNull((object)e, nameof(e));
            base.OnLoad(e);
        }
        protected override void OnOK(object sender, EventArgs args)
        {
            Assert.ArgumentNotNull(sender, nameof(sender));
            Assert.ArgumentNotNull((object)args, nameof(args));
            SheerResponse.SetDialogValue(this.GetDialogResult());
            base.OnOK(sender, args);
        }
        protected string GetDialogResult()
        {
            DowntimeNotificationFormModel model = new DowntimeNotificationFormModel();
            model.Title = Title.Value;
            model.StartTimeNotificationMessage = StartTimeNotificationMessage.Value;
            model.EndTimeNotificationMessage = EndTimeNotificationMessage.Value;
            model.StartTimeMaintenance = StartTimeMaintenance.Value;
            model.EndTimeMaintenance = EndTimeMaintenance.Value;
            return model.ToString();
        }
    }
}

