using ImageHunt.Interfaces;

namespace ImageHunt.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel(IToastService toastService) : base(toastService)
        {
        }
    }
}