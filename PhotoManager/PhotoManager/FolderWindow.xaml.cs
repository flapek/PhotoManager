using PhotoManager.Model;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PhotoManager
{
    public partial class FolderWindow : Window
    {
        private PhotoManagerDBEntities managerDBEntities = new PhotoManagerDBEntities();
        private bool isDataDirty = false;

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

        private void ButtonCloseWindow_Click(object sender, MouseButtonEventArgs e)
        {
            if (isDataDirty)
            {
                if (MessageBox.Show(Constants.MessageBoxStringClose, Constants.CaptionNameWarning,
                    MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    Close();
                }
            }
            else Close();
        }

        #endregion

        #region Window loaded

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadFolderFromEntity();
        }

        #endregion

        #region Button control

        private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            FolderView.Items.Clear();
            LoadFolderFromEntity();
        }

        private void ButtonAddFolder_MouseClick(object sender, RoutedEventArgs e)
        {
            Window_AddFolder windowAddFolder = new Window_AddFolder();
            windowAddFolder.ShowDialog();
        }

        private async void ButtonDeleteFolder_MouseClickAsync(object sender, RoutedEventArgs e)
        {
            TreeViewItem selectedFolder = (TreeViewItem)FolderView.SelectedItem;
            int folderId = Convert.ToInt32(selectedFolder.Tag.ToString());
            Folders folders = managerDBEntities.Folders.Where(x => x.Id == folderId).First();

            if (MessageBox.Show(Constants.MessageBoxDeleteAll, Constants.CaptionNameWarning,
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                if (await DeleteFolderTreeAsync(folders))
                {
                    DataIsSucessfulyDelete();
                }
            }
        }

        private void ButtonCancelChanges_MouseClick(object sender, RoutedEventArgs e) => Close();

        #endregion

        //dodać wyświetlnie comboboxu odpowiedniego 
        #region TreeView interaction

        private void Item_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)sender;
            int folderID = Convert.ToInt32(item.Tag.ToString());
            IQueryable<string> foldersDescription = managerDBEntities.Folders.Where(x => x.Id == folderID).Select(x => x.Description);

            TextBoxFolderName.Text = item.Header.ToString();
            TextBoxFolderName.Tag = item.Tag;

            //if (managerDBEntities.Folders.Where(x => x.Id == folderID && x.ParentFolder != null) != null)
            //{
            //    ComboBoxParentFolder.SelectedValuePath = managerDBEntities.Folders.Where(x => x.ParentFolder == folderID).Select(x => x.Name).First().ToString();
            //}

            foreach (string text in foldersDescription)
            {
                RichTextBoxFolderDescription.Selection.Text = text;
            }
        }

        #endregion

        #region CheckBox click

        private void CheckBoxCanEdit_Checked(object sender, RoutedEventArgs e)
        {
            TextBoxFolderName.IsEnabled = true;
            ComboBoxParentFolder.IsEnabled = true;
            RichTextBoxFolderDescription.IsEnabled = true;
        }

        private void CheckBoxCanEdit_Unchecked(object sender, RoutedEventArgs e)
        {
            TextBoxFolderName.IsEnabled = false;
            ComboBoxParentFolder.IsEnabled = false;
            RichTextBoxFolderDescription.IsEnabled = false;
        }

        #endregion

        //do poprawy całe
        #region Data change

        private void RichTextBoxFolderDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            TreeViewItem selectedFolder = (TreeViewItem)FolderView.SelectedItem;
            int folderID = Convert.ToInt32(selectedFolder.Tag.ToString());
            string foldersDescription = string.Empty;
            try
            {
                foldersDescription = managerDBEntities.Folders.Where(x => x.Id == folderID).Select(x => x.Description).First();
            }
            catch (Exception)
            {
                //ignore
            }


            if (foldersDescription == RichTextBoxFolderDescription.Selection.Text)
            {
                ButtonSaveChanges.IsEnabled = false;
                isDataDirty = false;
            }
            else
            {
                ButtonSaveChanges.IsEnabled = true;
                isDataDirty = true;
            }

        }

        private void TextBoxFolderName_TextChanged(object sender, TextChangedEventArgs e)
        {
            TreeViewItem selectedFolder = (TreeViewItem)FolderView.SelectedItem;

            if (selectedFolder.Name == TextBoxFolderName.Text)
            {
                ButtonSaveChanges.IsEnabled = false;
                isDataDirty = false;
            }
            else
            {
                ButtonSaveChanges.IsEnabled = true;
                isDataDirty = true;
            }


        }

        //dodać obsługe sprawdzającą czy nie zmienił się comboBox

        #endregion

        #region Local function

        private void DataIsSucessfulyDelete()
        {
            MessageBox.Show(Constants.MessageBoxDataDelete, Constants.CaptionNameInformation, MessageBoxButton.OK, MessageBoxImage.Information);
            TextBoxFolderName.Text = string.Empty;
            RichTextBoxFolderDescription.Selection.Text = string.Empty;

            LoadFolderFromEntity();
        }

        private void LoadFolderFromEntity()
        {
            FolderView.Items.Clear();

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

            foreach (Folders folders in managerDBEntities.Folders)
            {
                ComboBoxParentFolder.Items.Add(new ComboBoxItem
                {
                    Content = folders.Name,
                    Tag = folders.Id.ToString()
                });
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

        private async Task<bool> DeleteFolderTreeAsync(Folders folder)
        {
            int done;
            if (folder == null)
                return false;

            await DeleteFolderAndPhotoAsync(folder);
            done = await managerDBEntities.SaveChangesAsync();

            return done != 0 ? true : false;
        }

        private async Task DeleteFolderAndPhotoAsync(Folders folder)
        {
            IQueryable<Folders> folders = managerDBEntities.Folders.Where(x => x.ParentFolder == folder.Id);

            if (folders != null)
            {
                foreach (Folders subFolder in folders)
                {
                    await DeleteFolderAndPhotoAsync(subFolder);
                }
            }

            IQueryable<Images> imageses = managerDBEntities.Images.Where(x => x.FolderId == folder.Id);
            if (imageses != null)
            {
                foreach (Images image in imageses)
                {
                    managerDBEntities.Images.Remove(image);
                }
            }

            managerDBEntities.Folders.Remove(folder);
        }

        #endregion
    }
}
