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
        DatePicker StartTime;
        DatePicker EndTime;
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
            model.StartTime = StartTime.Value;
            model.EndTime = EndTime.Value;
            return model.ToString();
        }
    }
}

