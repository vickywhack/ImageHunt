﻿using Foundation;
using ImageHunt.Interfaces;
using UIKit;

namespace ImageHunt.iOS.Services
{
    internal class ToastService : IToastService
    {
        private const double DelayLong = 5d;
        private const double DelayShort = 2d;

        public void ShowToast(string message, bool isLongToast = false)
        {
            var duration = isLongToast ? DelayLong : DelayShort;

            var alertController = UIAlertController.Create(null, message, UIAlertControllerStyle.Alert);

            NSTimer.CreateScheduledTimer(duration, alertTimer =>
            {
                DismissToast(alertController, alertTimer);
            });

            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alertController, true, null);
        }

        private void DismissToast(UIAlertController alertController, NSTimer alertTimer)
        {
            alertController?.DismissViewController(true, null);
            alertTimer?.Dispose();
        }
    }
}