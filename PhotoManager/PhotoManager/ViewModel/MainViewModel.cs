using PhotoManager.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PhotoManager.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel(ObservableCollection<DataModel> imageData)
        {             
            if (imageData.Count != 0)
            {
                FolderOrImageDAB = imageData;
                SelectedFolderOrImage = FolderOrImageDAB[0];
            }
        }

        private ObservableCollection<DataModel> _folderOrImageDAB;
        public ObservableCollection<DataModel> FolderOrImageDAB
        {
            get => _folderOrImageDAB;
            set
            {
                _folderOrImageDAB = value;
                NotifyPropertyChanged("FolderOrImageDAB");
            }
        }

        private DataModel _selectedFolderOrImage;
        public DataModel SelectedFolderOrImage
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
