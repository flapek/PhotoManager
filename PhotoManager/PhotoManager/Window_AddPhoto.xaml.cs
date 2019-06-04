using PhotoManager.Model;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using PhotoManager.Workers.Open;
using Microsoft.Win32;
using PhotoManager.Workers.String;
using PhotoManager.Workers.String.BuildString;

namespace PhotoManager
{
    public partial class Window_AddPhoto : Window
    {
        private PhotoManagerDBEntities managerDBEntities = new PhotoManagerDBEntities();
        private bool isDataDirty = false;
        private string fileExplorerFilter = @"JPG(*.jpg/*.jpeg)|*.jpg|PNG(*.png)|*.png|TIFF(*.tif/*.tiff)|*.tif|GIF(*.gif)|*.gif";


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
        }

        #endregion

        #region Button click

        private async void ButtonBrowser_OnClickAsync(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Skoncz to kurwa!!!"); //do wywalenia

            FileExplorer fileExplorer = new FileExplorer(fileExplorerFilter, true);
            OpenFileDialog file = fileExplorer.Open(Environment.SpecialFolder.Desktop);
            if (fileExplorer.verificate)
            {
                foreach (string fileName in file.FileNames)
                {
                    Image image = await CreateImage(fileName);
                    StackPanel stack = new StackPanel();
                    Grid grid = await CreateGrid(await GetStringFromPath.OneStringTask(fileName));

                    stack.Children.Add(image);
                    stack.Children.Add(grid);

                    StackPanelPhotoContainer.Children.Add(stack);
                }

                TextBoxPathToPhoto.Text = await CreateString.StringManyPhotoName(file.FileNames);
                TextBoxPhotoName.Text =
                    await CreateString.StringManyPhotoName(await GetStringFromPath.StringListTask(file.FileNames));
            }
        }

        private void ButtonSavePhoto_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
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

        #endregion


    }
}
