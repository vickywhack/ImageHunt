using CommonServiceLocator;
using ImageHunt.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ImageHunt.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = ServiceLocator.Current.GetInstance<MainPageViewModel>();
        }
    }
}
