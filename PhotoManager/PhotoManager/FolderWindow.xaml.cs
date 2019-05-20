using PhotoManager.Model;
using System;
using System.IO;
using System.Linq;
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
            TreeViewItem selectedFolder = (TreeViewItem)FolderView.ItemContainerGenerator.ContainerFromItem(FolderView.SelectedItem);
            int folderId = Convert.ToInt32(selectedFolder.Tag.ToString());

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

        #endregion

        #region TreeView interaction
        //dodać wyświetlnie comboboxu odpowiedniego 
        private void Item_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)sender;
            int folderID = Convert.ToInt32(item.Tag.ToString());
            IQueryable<string> foldersDescription = managerDBEntities.Folders.Where(x => x.Id == folderID).Select(x => x.Description);

            TextBoxFolderName.Text = item.Header.ToString();
            TextBoxFolderName.Tag = item.Header.ToString();
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

        #region Data change

        private void RichTextBoxFolderDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            TreeViewItem selectedFolder = (TreeViewItem)FolderView.ItemContainerGenerator.ContainerFromItem(FolderView.SelectedItem);
            int folderID = Convert.ToInt32(selectedFolder.Tag.ToString());
            string foldersDescription = managerDBEntities.Folders.Where(x => x.Id == folderID).Select(x => x.Description).First();

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
            TreeViewItem selectedFolder = (TreeViewItem)FolderView.ItemContainerGenerator.ContainerFromItem(FolderView.SelectedItem);
            int folderID = Convert.ToInt32(selectedFolder.Tag.ToString());
            string folderName = managerDBEntities.Folders.Where(x => x.Id == folderID).Select(x => x.Name).First();

            if (folderName == TextBoxFolderName.Text)
            {
                ButtonSaveChanges.IsEnabled = false;
                isDataDirty = false;
            }
            else
            {
                ButtonSaveChanges.IsEnabled = false;
                isDataDirty = false;
            }


        }

        //dodać obsługe sprawdzającą czy nie zmienił się comboBox

        #endregion
    }
}
