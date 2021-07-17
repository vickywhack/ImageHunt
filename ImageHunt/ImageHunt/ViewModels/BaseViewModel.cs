using ImageHunt.Interfaces;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ImageHunt.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Services
        private readonly IToastService _toastService;
        #endregion

        #region Constructors
        public BaseViewModel(IToastService toastService)
        {
            _toastService = toastService;
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Methods
        protected void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
