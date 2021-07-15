using ImageHunt.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ImageHunt.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private readonly IToastService _toastService;
        private string _toastMessage = "This is a toast message.";

        public string ToastMessage
        {
            get => _toastMessage;
            set { _toastMessage = value; OnPropertyChanged(); }
        }

        public BaseViewModel(IToastService toastService)
        {
            _toastService = toastService;
        }

        private ICommand _showShortToastCommand;
        public ICommand ShowShortToastCommand => _showShortToastCommand ?? (_showShortToastCommand = new Command(ShowShortToast));

        private ICommand _showLongToastCommand;
        public ICommand ShowLongToastCommand => _showLongToastCommand ?? (_showLongToastCommand = new Command(ShowLongToast));

        private void ShowShortToast()
        {
            ShowToast(false);
        }
        private void ShowLongToast()
        {
            ShowToast(true);
        }
        private void ShowToast(bool isLongToast)
        {
            var message = string.IsNullOrEmpty(ToastMessage) ? "This is a toast message" : ToastMessage;
            _toastService.ShowToast(message, isLongToast);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
