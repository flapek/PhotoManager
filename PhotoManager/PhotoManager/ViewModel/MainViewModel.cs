using PhotoManager.Model;
using PhotoManager.Workers;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace PhotoManager.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel(ImageEntities entities)
        {
            IQueryable<ImageInfo> data = entities.ImageInfo;
            ObservableCollection<ImageModel> imageData = new ObservableCollection<ImageModel>();
            foreach (ImageInfo imageInfo in data)
            {
                imageData.Add(new ImageModel()
                {
                    Name = imageInfo.Name,
                    ShortName = imageInfo.ShortName,
                    ImageSource = ImageConverter.ConvertByteArrayToBitmapImage(imageInfo.Image),
                    Text = imageInfo.Text
                });
            }
            FolderOrImageDAB = imageData;
            SelectedFolderOrImage = FolderOrImageDAB[0];
        }

        private ObservableCollection<ImageModel> _folderOrImageDAB;
        public ObservableCollection<ImageModel> FolderOrImageDAB
        {
            get => _folderOrImageDAB;
            set
            {
                _folderOrImageDAB = value;
                NotifyPropertyChanged("FolderOrImageDAB");
            }
        }

        private ImageModel _selectedFolderOrImage;
        public ImageModel SelectedFolderOrImage
        {
            get => _selectedFolderOrImage;
            set
            {
                _selectedFolderOrImage = value;
                NotifyPropertyChanged("SelectedFolderOrImage");
            }
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged
    }
}
