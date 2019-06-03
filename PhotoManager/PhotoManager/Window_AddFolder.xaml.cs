using PhotoManager.Model;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using PhotoManager.Workers;

namespace PhotoManager
{
    public partial class Window_AddFolder : Window
    {
        private PhotoManagerDBEntities managerDBEntities = new PhotoManagerDBEntities();
        private bool isDataDirty = false;
        private readonly string folderPath = @"pack://application:,,,/Picture/folder-open.png";

        public Window_AddFolder()
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
            if (isDataDirty == true)
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

        #region Window Loaded

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadFolderFromEntity();   
        }

        #endregion

        #region Button interaction

        /// <summary>
        /// Interaction with button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private async void ButtonSaveFolder_MouseDoubleClickAsync(object sender, MouseButtonEventArgs e)
        {
            string selectedTag = ((ComboBoxItem)ComboBoxParentFolder.SelectedItem).Tag.ToString();

            if (selectedTag == "null")
            {
                managerDBEntities.Folders.Add(new Folders
                {
                    Name = TextBoxFolderName.Text,
                    Description = new TextRange(RichTextBoxFolderDescription.Document.ContentStart, RichTextBoxFolderDescription.Document.ContentEnd).Text,
                    ParentFolder = null,
                    MetaDataPicture = ImageConverter.ConvertImageToByteArray(new BitmapImage(new Uri(folderPath)))
            });
            }
            else
            {
                managerDBEntities.Folders.Add(new Folders
                {
                    Name = TextBoxFolderName.Text,
                    Description = new TextRange(RichTextBoxFolderDescription.Document.ContentStart, RichTextBoxFolderDescription.Document.ContentEnd).Text,
                    ParentFolder = Convert.ToInt32(selectedTag),
                    MetaDataPicture = ImageConverter.ConvertImageToByteArray(new BitmapImage(new Uri(folderPath)))
                });
            }
            int done = await managerDBEntities.SaveChangesAsync();
            if (done == 1)
            {
                MessageBox.Show(Constants.MessageBoxTagIsAdded, Constants.CaptionNameInformation, MessageBoxButton.OK, MessageBoxImage.Information);
            }

            TextBoxFolderName.Text = string.Empty;
            RichTextBoxFolderDescription.Document.Blocks.Clear();
            
            LoadFolderFromEntity();

            ComboBoxParentFolder.SelectedIndex = 0;
        }

        private void ButtonCancelAddingFolder_MouseDoubleClick(object sender, MouseButtonEventArgs e) => Close();

        #endregion 

        #region TextBox control

        private void TextBoxFolderName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!(TextBoxFolderName.Text == string.Empty))
            {
                ButtonSaveFolder.IsEnabled = true;
                isDataDirty = true;
            }
            else
            {
                ButtonSaveFolder.IsEnabled = false;
                isDataDirty = false;
            }
        }

        #endregion

        #region Local Function

        private void LoadFolderFromEntity()
        {
            ComboBoxParentFolder.Items.Clear();
            ComboBoxParentFolder.Items.Add(new ComboBoxItem
            {
                Content = "none",
                Tag = "null"
            });
            foreach (Folders folders in managerDBEntities.Folders)
            {
                ComboBoxParentFolder.Items.Add(new ComboBoxItem
                {
                    Content = folders.Name,
                    Tag = folders.Id.ToString()
                });
            }
        }

        #endregion
    }
}
