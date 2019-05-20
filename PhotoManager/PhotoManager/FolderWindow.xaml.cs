using PhotoManager.Model;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PhotoManager
{
    /// <summary>
    /// Interaction logic for FolderWindow.xaml
    /// </summary>
    public partial class FolderWindow : Window
    {
        private PhotoManagerDBEntities managerDBEntities = new PhotoManagerDBEntities();

        public FolderWindow()
        {
            InitializeComponent();
        }

        #region Window Control

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void ButtonMinimizeWindow_Click(object sender, MouseButtonEventArgs e) => WindowState = WindowState.Minimized;

        private void ButtonCloseWindow_Click(object sender, MouseButtonEventArgs e) => Close();

        #endregion

        #region Window loaded

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CreateTreeView();
        }

        #endregion

        #region Button control

        private void ButtonAddFolder_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Window_AddFolder windowAddFolder = new Window_AddFolder();
            windowAddFolder.ShowDialog();
        }

        private void ButtonCancelChanges_MouseDoubleClick(object sender, MouseButtonEventArgs e) => Close();

        #endregion

        #region Local function

        private void CreateTreeView()
        {
            foreach (Folders folder in managerDBEntities.Folders)
            {
                if (folder.ParentFolder == null)
                {
                    TreeViewItem item = new TreeViewItem
                    {
                        Header = folder.Name,
                        Tag = folder.Id.ToString()
                    };

                    item.Items.Add(null);

                    item.Expanded += Item_Expanded;

                    FolderView.Items.Add(item);
                }
            }
        }

        private void Item_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)sender;

            if (item.Items.Count != 1 || item.Items[0] != null)
                return;

            item.Items.Clear();
            int folderId = Convert.ToInt32(item.Tag.ToString());
            foreach (Folders folder in managerDBEntities.Folders)
            {
                if (folder.ParentFolder == folderId)
                {
                    TreeViewItem subItem = new TreeViewItem
                    {
                        Header = folder.Name,
                        Tag = folder.Id.ToString()
                    };

                    subItem.Items.Add(null);

                    subItem.Expanded += Item_Expanded;

                    item.Items.Add(subItem);
                }
            }

        }

        #endregion
    }
}
