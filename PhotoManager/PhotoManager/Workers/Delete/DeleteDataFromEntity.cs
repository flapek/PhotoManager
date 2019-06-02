using PhotoManager.Model;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoManager.Workers.Delete
{
    class DeleteDataFromEntity
    {
        private PhotoManagerDBEntities managerDBEntities = new PhotoManagerDBEntities();

        internal async Task<bool> DeleteFolderTreeAsync(Folders folder)
        {
            int done;
            if (folder == null)
                return false;

            DeleteFolderAsync(folder);

            done = await managerDBEntities.SaveChangesAsync();

            return done != 0 ? true : false;
        }

        private void DeleteFolderAsync(Folders folder)
        {
            IQueryable<Folders> folders = managerDBEntities.Folders.Where(x => x.ParentFolder == folder.Id);

            if (folders != null)
            {
                foreach (Folders subFolder in folders)
                {
                    DeleteFolderAsync(subFolder);
                }
            }
            managerDBEntities.Folders.Remove(folder);
        }
    }
}
