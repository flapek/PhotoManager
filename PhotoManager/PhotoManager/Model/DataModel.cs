using System.Windows.Media.Imaging;

namespace PhotoManager.Model
{
    public class DataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BitmapImage ImageSource { get; set; }
        public string Description { get; set; }
        public int? ParentFolder { get; set; }
        public bool IsFolder { get; set; }
    }
}
