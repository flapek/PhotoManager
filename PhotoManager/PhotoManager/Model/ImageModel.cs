using System.Windows.Media.Imaging;

namespace PhotoManager.Model
{
    public class ImageModel
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public BitmapImage ImageSource { get; set; }
        public string Text { get; set; }
    }
}
