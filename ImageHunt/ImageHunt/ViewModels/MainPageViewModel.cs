using ImageHunt.Interfaces;
using ImageHunt.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using Xamarin.Forms;
using ImageHunt.Constants;

namespace ImageHunt.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        #region Services
        private readonly IToastService _toastService;
        #endregion

        #region Constructors
        public MainPageViewModel(IToastService toastService) : base(toastService)
        {
            _toastService = toastService;
        }
        #endregion

        #region Fields
        private string _imageToSearch = string.Empty;
        private IList<FlickrImage> _images;
        private ICommand _searchCommand;
        #endregion

        #region Properties
        public string ImageToSearch
        {
            get => _imageToSearch;
            set { _imageToSearch = value; OnPropertyChanged(); }
        }

        public IList<FlickrImage> Images
        {
            get => _images;
            set { _images = value; OnPropertyChanged(); }
        }

        public ICommand SearchCommand => _searchCommand ??
            (_searchCommand = new Command(HuntImages));
        #endregion

        #region Methods
        private async void HuntImages()
        {
            var result = await SearchResultsAsync().ConfigureAwait(false);
            if (result != null)
            {
                Images = GetImages(result);
            }
            GetToastMessage();
        }

        public async Task<string> SearchResultsAsync()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(string.Format(AppConstants.SearchUrl, AppConstants.Flickrkey, ImageToSearch)).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            return null;
        }

        public IList<FlickrImage> GetImages(string serialized)
        {
            if (string.IsNullOrEmpty(serialized))
            {
                return null;
            }
            var doc = XDocument.Parse(serialized);
            var allPhotos = from results in doc.Descendants("photo")
                            select new FlickrImage
                            {
                                PhotosId = results.Attribute("id").Value,
                                ImageTitle = results.Attribute("title").Value,
                                Secret = results.Attribute("secret").Value,
                                FarmeId = results.Attribute("farm").Value,
                                ServerId = results.Attribute("server").Value
                            };
            return Images = allPhotos.ToList();
        }

        public void GetToastMessage()
        {
            string toastMessage = string.Empty;
            if (string.IsNullOrEmpty(ImageToSearch))
            {
                toastMessage = "At least type something before searching 😠";
            }
            else
            {
                toastMessage = $"Here we have {ImageToSearch} from Flicker Library 😉";
            }
            _toastService.ShowToast(toastMessage);
        }
        #endregion
    }
}