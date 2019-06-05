using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PhotoManager.Model;
using PhotoManager.Workers;

namespace PhotoManager
{
    public partial class Window_PhotoView : Window
    {
        private PhotoManagerDBEntities managerDBEntities = new PhotoManagerDBEntities();

        private DataModel dataModel { get; set; }

        public Window_PhotoView(DataModel data)
        {
            InitializeComponent();

            dataModel = data;
        }

        private async void Window_PhotoView_OnLoadedAsync(object sender, RoutedEventArgs e)
        {
            Images image = managerDBEntities.Images.Where(x => x.Id == dataModel.Id).First();

            ImageHandler.Source = await ImageConverter.ConvertByteArrayToBitmapImage(image.MetaDataPicture);
        }
    }
}
