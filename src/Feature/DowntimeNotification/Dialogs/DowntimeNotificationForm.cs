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
        /// <summary>
        /// On Form Load
        /// </summary>
        /// <param name="e">EventArgs</param>
        protected override void OnLoad(EventArgs e)
        {
            Assert.ArgumentNotNull((object)e, nameof(e));
            base.OnLoad(e);
        }

        /// <summary>
        /// OnOk Callback
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="args">EventArgs</param>
        protected override void OnOK(object sender, EventArgs args)
        {
            Assert.ArgumentNotNull(sender, nameof(sender));
            Assert.ArgumentNotNull((object)args, nameof(args));
            SheerResponse.SetDialogValue(this.GetDialogResult());
            base.OnOK(sender, args);
        }

        /// <summary>
        /// Set the Dialog Result as XML
        /// </summary>
        /// <returns></returns>
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

