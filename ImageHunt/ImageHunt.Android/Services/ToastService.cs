using Android.Widget;
using ImageHunt.Interfaces;
using Xamarin.Forms;

namespace ImageHunt.Droid.Services
{
    internal class ToastService : IToastService
    {
        private static Toast _toastInstance;

        public void ShowToast(string message, bool isLongToast = false)
        {
            var toastLength = isLongToast ? ToastLength.Long : ToastLength.Short;

            Device.BeginInvokeOnMainThread(() =>
            {
                _toastInstance?.Cancel();
                _toastInstance = Toast.MakeText(Android.App.Application.Context, message, toastLength);
                _toastInstance?.Show();
            });
        }
    }
}