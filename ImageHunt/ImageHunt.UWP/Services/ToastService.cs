using ImageHunt.Interfaces;
using System;
using Windows.UI.Notifications;

namespace ImageHunt.UWP.Services
{
    internal class ToastService : IToastService
    {
        private const double DelayLong = 5d;
        private const double DelayShort = 2d;

        public void ShowToast(string message, bool isLongToast = false)
        {
            var duration = isLongToast ? DelayLong : DelayShort;

            ToastNotifier ToastNotifier = ToastNotificationManager.CreateToastNotifier();
            Windows.Data.Xml.Dom.XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);
            Windows.Data.Xml.Dom.XmlNodeList toastNodeList = toastXml.GetElementsByTagName("text");
            toastNodeList.Item(1).AppendChild(toastXml.CreateTextNode(message));

            ToastNotification toast = new ToastNotification(toastXml)
            {
                ExpirationTime = DateTime.Now.AddSeconds(duration)
            };
            ToastNotifier.Show(toast);
        }
    }
}
