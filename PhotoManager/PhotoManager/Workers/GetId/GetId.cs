using PhotoManager.Model;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoManager
{
    public class GetId
    {
        public static Task<int?> GetCurrentFolderId(DbSet<Folders> folders, int id) => Task.Run(() =>
         {
             int? result = null;
             int? parentId = null;
             int? nextParentId = null;

             if (folders.Where(x => x.Id == id) != null)
             {
                 parentId = folders.Where(x => x.Id == id).Select(x => x.ParentFolder).First();
             }
             if (parentId != null)
             {
                 nextParentId = folders.Where(x => x.Id == parentId).Select(x => x.ParentFolder).First();
             }
             if (nextParentId != null)
             {
                 result = Convert.ToInt32(nextParentId);
             }

             return result;
         });
    }
}