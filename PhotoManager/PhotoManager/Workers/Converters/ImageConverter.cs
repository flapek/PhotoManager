using System.IO;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PhotoManager.Workers
{
    class ImageConverter
    {
        public static async Task<byte[]> ConvertImageToByteArray(BitmapImage bitmapImage)
        {
            MemoryStream memoryStream = new MemoryStream();
            JpegBitmapEncoder jpggBitmapEncoder = new JpegBitmapEncoder();
            jpggBitmapEncoder.Frames.Add(BitmapFrame.Create(bitmapImage));
            jpggBitmapEncoder.Save(memoryStream);
            return memoryStream.ToArray();
        }

        public static async Task<BitmapImage> ConvertByteArrayToBitmapImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            BitmapImage bitmapImage = new BitmapImage();
            using (MemoryStream memoryStream = new MemoryStream(imageData))
            {
                memoryStream.Position = 0;
                bitmapImage.BeginInit();
                bitmapImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.UriSource = null;
                bitmapImage.StreamSource = memoryStream;
                bitmapImage.EndInit();
            }
            bitmapImage.Freeze();
            return bitmapImage;
        }
    }
}
