using PhotoManager.Model;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoManager.Workers.LoadData
{
    class LoadCarouselDataModel
    {
        public static async Task<ObservableCollection<DataModel>> LoadCarouselModel(DbSet<Folders> folders)
        {
            ObservableCollection<DataModel> dataModels = new ObservableCollection<DataModel>();
            await Task.Run(() => 
            {
                foreach (Folders folder in folders)
                {
                    if (folder.ParentFolder == null)
                    {
                        dataModels.Add(new DataModel()
                        {
                            Id = folder.Id,
                            Name = folder.Name,
                            ImageSource = ImageConverter.ConvertByteArrayToBitmapImage(folder.MetaDataPicture),
                            Description = folder.Description,
                            IsFolder = true,
                        });
                    }
                }
            });

            return dataModels;
        }

        public static async Task<ObservableCollection<DataModel>> LoadCarouselModel(DbSet<Folders> folders, int id)
        {
            ObservableCollection<DataModel> dataModels = new ObservableCollection<DataModel>();
            await Task.Run(() =>
            {
                 foreach (Folders folder in folders.Where(x => x.ParentFolder == id))
                 {
                     dataModels.Add(new DataModel()
                     {
                         Id = folder.Id,
                         Name = folder.Name,
                         ImageSource = ImageConverter.ConvertByteArrayToBitmapImage(folder.MetaDataPicture),
                         Description = folder.Description,
                         IsFolder = true
                     });
                 }
            });
            

            return dataModels;
        }
    }
}
