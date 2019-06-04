using PhotoManager.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using PhotoManager.Workers.Open;
using Microsoft.Win32;
using PhotoManager.Workers;
using PhotoManager.Workers.String;
using PhotoManager.Workers.String.BuildString;
using System.Windows.Documents;

namespace PhotoManager
{
    public partial class Window_AddPhoto : Window
    {
        #region Object

        private PhotoManagerDBEntities managerDBEntities = new PhotoManagerDBEntities();

        #endregion

        #region Property

        public OpenFileDialog OpenFile { get; set; }

        #endregion

        #region Variables

        private bool isDataDirty = false;
        private string fileExplorerFilter =
            @"JPG(*.jpg/*.jpeg)|*.jpg|PNG(*.png)|*.png|TIFF(*.tif/*.tiff)|*.tif|GIF(*.gif)|*.gif";

        #endregion

        public Window_AddPhoto()
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
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;

            LoadFolderFromEntity();
        }

        #endregion

        #region Button Click

        private async void ButtonBrowser_OnClickAsync(object sender, RoutedEventArgs e)
        {
            FileExplorer fileExplorer = new FileExplorer(fileExplorerFilter, true);
            OpenFile = fileExplorer.Open(Environment.SpecialFolder.Desktop);
            if (fileExplorer.verificate)
            {
                isDataDirty = true;
                TextBoxPathToPhoto.Text = string.Empty;
                TextBoxPhotoName.Text = string.Empty;
                StackPanelPhotoContainer.Children.Clear();

                foreach (string fileName in OpenFile.FileNames)
                {
                    Image image = await CreateImage(fileName);
                    StackPanel stack = new StackPanel();
                    Grid grid = await CreateGrid(GetString.OneStringFromPath(fileName));

                    stack.Children.Add(image);
                    stack.Children.Add(grid);

                    StackPanelPhotoContainer.Children.Add(stack);
                }

                TextBoxPathToPhoto.Text = await CreateString.StringManyPhotoName(OpenFile.FileNames);
                TextBoxPhotoName.Text =
                    await CreateString.StringManyPhotoName(await GetString.StringListFromPathListTask(OpenFile.FileNames));
            }
        }

        /*foreach pownninen pobierac dane z textboxa poprzez metode ktora wykonuje splita*/
        private async void ButtonAddPhoto_OnClickAsync(object sender, RoutedEventArgs e)
        {
            string selectedTag;
            List<Images> imageses = new List<Images>();
            foreach (string fileName in OpenFile.FileNames)
            {
                if (File.Exists(fileName) && ComboBoxParentFolder.SelectedIndex != -1)
                {
                    selectedTag = ((ComboBoxItem)ComboBoxParentFolder.SelectedItem).Tag.ToString();
                    Images image = new Images
                    {
                        Name = GetString.OneStringFromPath(fileName),
                        MetaDataPicture =
                            await ImageConverter.ConvertImageToByteArray(new BitmapImage(new Uri(fileName))),
                        Description = new TextRange(RichTextBoxPhotoDescription.Document.ContentStart,
                            RichTextBoxPhotoDescription.Document.ContentEnd).Text,
                        FolderId = Convert.ToInt32(selectedTag),
                        Tags = null
                    };

                    imageses.Add(image);
                }
                else
                {
                    MessageBox.Show(Constants.MessageBoxWarningIncorectData, Constants.CaptionNameWarning, MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    return;
                }
            }
            managerDBEntities.Images.AddRange(imageses);
            int done = await managerDBEntities.SaveChangesAsync();
            if (done != 0)
                MessageBox.Show(Constants.MessageBoxPhotosIsAdded, Constants.CaptionNameInformation, MessageBoxButton.OK, MessageBoxImage.Information);

            TextBoxPathToPhoto.Text = string.Empty;
            TextBoxPhotoName.Text = string.Empty;
            RichTextBoxPhotoDescription.Selection.Text = string.Empty;
        }

        private void ButtonCancel_OnMouseClick(object sender, RoutedEventArgs e) => Close();

        #endregion

        #region Local function

        #region Slider element

        /// <summary>
        /// Return photo element 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>

        private async Task<Image> CreateImage(string fileName)
        {
            Image image = new Image
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(5),
                Stretch = Stretch.Uniform,
                StretchDirection = StretchDirection.Both,
                Source = new BitmapImage(new Uri(fileName)),
                Height = 200,
                Width = 200,
            };

            RenderOptions.SetBitmapScalingMode(image, BitmapScalingMode.Fant);

            return image;
        }

        private async Task<Grid> CreateGrid(string fileName)
        {
            Grid grid = new Grid
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(5),
            };

            Label label = new Label
            {
                Content = fileName,
            };

            grid.Children.Add(label);

            return grid;
        }


        #endregion

        private void LoadFolderFromEntity()
        {
            ComboBoxParentFolder.Items.Clear();

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

        #region TextBox textChanged

        private void TextBoxPathToPhoto_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBoxPathToPhoto.Text != string.Empty)
            {
                isDataDirty = true;
                ButtonAddPhoto.IsEnabled = true;
            }
            else
            {
                isDataDirty = false;
                ButtonAddPhoto.IsEnabled = false;
            }
        }

        #endregion

    }
}
