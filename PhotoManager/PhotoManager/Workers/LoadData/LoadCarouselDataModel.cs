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
            ObservableCollection<DataModel> dataModel = new ObservableCollection<DataModel>();

            await Task.Run(async () =>
            {
                foreach (Folders folder in folders)
                {
                    if (folder.ParentFolder == null)
                    {
                        dataModel.Add(new DataModel()
                        {
                            Id = folder.Id,
                            Name = folder.Name,
                            ImageSource = await ImageConverter.ConvertByteArrayToBitmapImage(folder.MetaDataPicture),
                            Description = folder.Description,
                            ParentFolder = folder.ParentFolder,
                            IsFolder = true,
                        });
                    }
                }
            });

            return dataModel;
        }

        public static async Task<ObservableCollection<DataModel>> LoadCarouselModel(DbSet<Folders> folders, int? id)
        {
            ObservableCollection<DataModel> dataModel = new ObservableCollection<DataModel>();

            await Task.Run(async () =>
            {
                foreach (Folders folder in folders.Where(x => x.ParentFolder == id))
                {
                    dataModel.Add(new DataModel()
                    {
                        Id = folder.Id,
                        Name = folder.Name,
                        ImageSource = await ImageConverter.ConvertByteArrayToBitmapImage(folder.MetaDataPicture),
                        Description = folder.Description,
                        ParentFolder = folder.ParentFolder,
                        IsFolder = true
                    });
                }
            });


            return dataModel;
        }

        public static async Task<ObservableCollection<DataModel>> LoadCarouselModel(DbSet<Images> imageses, int? id)
        {
            ObservableCollection<DataModel> dataModel = new ObservableCollection<DataModel>();

            await Task.Run(async () =>
            {
                foreach (Images images in imageses.Where(x => x.FolderId == id))
                {
                    dataModel.Add(new DataModel()
                    {
                        Id = images.Id,
                        Name = images.Name,
                        ImageSource = await ImageConverter.ConvertByteArrayToBitmapImage(images.MetaDataPicture),
                        Description = images.Description,
                        ParentFolder = images.FolderId,
                        IsFolder = false
                    });
                }
            });


            return dataModel;
        }
    }
}
