using System;

namespace ImageHunt.Models
{
    public class FlickrImage
    {
        public string PhotosId { get; set; }
        public string ImageTitle { get; set; }
        public string Secret { get; set; }
        public string FarmeId { get; set; }
        public string ServerId { get; set; }

        public Uri ImageUrl
        {
            get => new Uri(string.Format("http://farm{0}.static.flickr.com/{1}/{2}_{3}.jpg", FarmeId, ServerId, PhotosId, Secret));
        }
    }
}
