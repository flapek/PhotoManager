using PhotoManager.Model;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoManager.Workers.Delete
{
    class DeleteDataFromEntity
    {
        private PhotoManagerDBEntities managerDBEntities = new PhotoManagerDBEntities();

        internal async Task<bool> DeleteFolderTreeAsync(IQueryable<Folders> folders, int folderId)
        {
            int done;
            try
            {
                if (folders.Count() != 0)
                {
                    foreach (Folders folder in folders)
                    {
                        await DeleteFolderTreeAsync(folder);
                    }
                }
            }
            finally
            {
                Folders folder = managerDBEntities.Folders.First(x => x.Id == folderId);
                managerDBEntities.Folders.Remove(folder);
                done = await managerDBEntities.SaveChangesAsync();
            }

            return done != 0 ? true : false;
        }

        private async Task DeleteFolderTreeAsync(Folders folder)
        {
            IQueryable<Folders> folders = managerDBEntities.Folders.Where(x => x.ParentFolder == folder.Id);
            foreach (Folders subFolder in folders)
            {
                await DeleteFolderTreeAsync(subFolder);
            }
            managerDBEntities.Folders.Remove(folder);
        }
    }
}
