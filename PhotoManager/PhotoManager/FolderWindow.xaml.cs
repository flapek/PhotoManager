using PhotoManager.Model;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PhotoManager
{
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CreateTreeView();
        }

        #endregion

        #region Button control

        private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            FolderView.Items.Clear();
            CreateTreeView();
        }

        private void ButtonAddFolder_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Window_AddFolder windowAddFolder = new Window_AddFolder();
            windowAddFolder.ShowDialog();
        }
        
        //usuwanie folderu nie działa 
        private void ButtonDeleteFolder_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem tvi = (TreeViewItem)FolderView.ItemContainerGenerator.ContainerFromItem(FolderView.SelectedItem);
            int folderId = Convert.ToInt32(tvi.Tag.ToString());

            if (MessageBox.Show(Constants.MessageBoxFolderClose, Constants.CaptionNameWarning,
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Folders folders = new Folders
                {
                    Id = folderId
                };

                managerDBEntities.Folders.Attach(folders);
                managerDBEntities.Folders.Remove(folders);
                FolderView.Items.Remove(FolderView.SelectedItem);
            }
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

                    item.MouseDoubleClick += Item_MouseDoubleClick;
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

        #region TreeView interaction

        private void Item_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //throw new NotImplementedException();
        }

        #endregion


    }
}
