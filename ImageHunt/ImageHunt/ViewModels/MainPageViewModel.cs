using ImageHunt.Interfaces;
using ImageHunt.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using Xamarin.Forms;

namespace ImageHunt.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        #region Services
        private readonly IToastService _toastService;
        #endregion

        #region Constants
        private const string Flickerkey = "4c29a23216ee0f7a2854621cfa57af4a";
        private const string SearchUrl = "http://api.flickr.com/services/rest/?method=flickr.photos.search&api_key={0}&text={1}";
        #endregion

        #region Constructors
        public MainPageViewModel(IToastService toastService) : base(toastService)
        {
            _toastService = toastService;
        }
        #endregion

        #region Fields
        private string _imageToSearch = string.Empty;
        private IList<FlikarImage> _images;
        private ICommand _searchCommand;
        #endregion

        #region Properties
        public string ImageToSearch
        {
            get => _imageToSearch;
            set { _imageToSearch = value; OnPropertyChanged(); }
        }

        public IList<FlikarImage> Images
        {
            get => _images;
            set { _images = value; OnPropertyChanged(); }
        }

        public ICommand SearchCommand => _searchCommand ??
            (_searchCommand = new Command(async () => await SearchResultsAsync().ConfigureAwait(false)));
        #endregion

        #region Private Methods
        private async Task SearchResultsAsync()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(string.Format(SearchUrl, Flickerkey, ImageToSearch)).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                Images = await GetImagesAsync(response).ConfigureAwait(false);
                GetToastMessage();
            }
        }

        private async Task<IList<FlikarImage>> GetImagesAsync(HttpResponseMessage responseMsg)
        {
            var Doc = XDocument.Parse(await responseMsg.Content.ReadAsStringAsync().ConfigureAwait(false));
            var myphotos = (from results in Doc.Descendants("photo")
                            select new FlikarImage
                            {
                                PhotosId = results.Attribute("id").Value,
                                ImageTitle = results.Attribute("title").Value,
                                Secret = results.Attribute("secret").Value,
                                FarmeId = results.Attribute("farm").Value,
                                ServerId = results.Attribute("server").Value
                            });
            return Images = myphotos.ToList();
        }

        private void GetToastMessage()
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