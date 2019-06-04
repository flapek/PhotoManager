using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using MaterialDesignThemes.Wpf;
using PhotoManager.Model;
using PhotoManager.ViewModel;
using PhotoManager.Workers;
using PhotoManager.Workers.LoadData;

namespace PhotoManager
{
    public partial class PhotoWindow : Window
    {
        private PhotoManagerDBEntities managerDBEntities = new PhotoManagerDBEntities();

        public PhotoWindow()
        {
            InitializeComponent();
        }

        #region Window Control

        /// <summary>
        ///     Button Window Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void ButtonMinimizeWindow_Click(object sender, MouseButtonEventArgs e) => WindowState = WindowState.Minimized;

        private void ButtonMaximizeWindow_Click(object sender, MouseButtonEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            else WindowState = WindowState.Maximized;
        }

        private void ButtonCloseWindow_Click(object sender, MouseButtonEventArgs e) => Close();

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        #endregion

        #region Check box control

        private void CheckBoxCanEdit_OnChecked(object sender, RoutedEventArgs e)
        {
            ListBoxTag.IsEnabled = true;
            TextBoxPhotoName.IsEnabled = true;
            ComboBoxParentFolder.IsEnabled = true;
            ButtonAddTag.IsEnabled = true;
            ButtonDeleteTag.IsEnabled = true;
        }

        private void CheckBoxCanEdit_OnUnchecked(object sender, RoutedEventArgs e)
        {
            ListBoxTag.IsEnabled = false;
            TextBoxPhotoName.IsEnabled = false;
            ComboBoxParentFolder.IsEnabled = false;
            ButtonAddTag.IsEnabled = false;
            ButtonDeleteTag.IsEnabled = false;
        }

        #endregion

        #region Window Loaded

        private void PhotoWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;

            LoadPhotoFromEntity();
        }

        #endregion

        #region Button click

        private void ButtonCancelChanges_OnMouseDoubleClick(object sender, MouseButtonEventArgs e) => Close();

        private void ButtonAddPhoto_OnClick(object sender, RoutedEventArgs e)
        {
            Window_AddPhoto windowAddPhoto = new Window_AddPhoto();
            windowAddPhoto.Closing += WindowAddPhoto_Closing;
            windowAddPhoto.ShowDialog();
        }

        #endregion

        #region Other window event

        private void WindowAddPhoto_Closing(object sender, System.EventArgs e)
        {
            LoadPhotoFromEntity();
        }

        #endregion

        #region Local Function

        private void LoadPhotoFromEntity()
        {
            ListBoxPhoto.Items.Clear();

            foreach (Images image in managerDBEntities.Images)
            {
                ListBoxItem item = new ListBoxItem
                {
                    Content = image.Name,
                    Tag = image.Id
                };

                ListBoxPhoto.Items.Add(item);

                item.MouseDoubleClick += Item_MouseDoubleClickAsync;
            }
        }

        #endregion

        #region ListBox interaction

        private async void Item_MouseDoubleClickAsync(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem item = (ListBoxItem)sender;
            int id = Convert.ToInt32(item.Tag.ToString());
            byte[] image = managerDBEntities.Images.Where(x => x.Id == id).Select(x => x.MetaDataPicture).First();

            ImageHandler.Source = await ImageConverter.ConvertByteArrayToBitmapImage(image);
            TextBoxPhotoName.Text = item.Content.ToString();
        }

        #endregion
    }
}
