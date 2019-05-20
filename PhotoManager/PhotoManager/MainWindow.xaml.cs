using PhotoManager.Model;
using PhotoManager.ViewModel;
using PhotoManager.Workers;
using PhotoManager.Workers.Open;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace PhotoManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PhotoManagerDBEntities managerDBEntities = new PhotoManagerDBEntities();
        private ObservableCollection<DataModel> imageData = new ObservableCollection<DataModel>();
        private string splahImage = "Picture\\SplashScreen.jpg";

        public MainWindow()
        {
            SplashScreen splashScreen = new SplashScreen(splahImage);
            splashScreen.Show(true);
            Thread.Sleep(2500);
            splashScreen.Close(TimeSpan.FromSeconds(5));

            InitializeComponent();

            CarouselFolderOrImage.SelectionChanged += CarouselFolderOrImage_SelectionChanged;
        }

        #region Carousel Control

        /// <summary>
        ///     Control carousel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void CarouselFolderOrImage_SelectionChanged(FrameworkElement selectedElement)
        {
            MainViewModel viewModel = DataContext as MainViewModel;
            if (viewModel == null)
                return;

            viewModel.SelectedFolderOrImage = selectedElement.DataContext as DataModel;
        }

        private void ButtonPreviousPhotoOrFolder_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel viewModel = DataContext as MainViewModel;
            if (viewModel == null)
            {
                return;
            }

            int position = viewModel.SelectedFolderOrImage != null ? viewModel.FolderOrImageDAB.IndexOf(viewModel.SelectedFolderOrImage) : 0;
            if (position > 0)
            {
                viewModel.SelectedFolderOrImage = viewModel.FolderOrImageDAB[position - 1];
            }
            else if (position == 0)
            {
                viewModel.SelectedFolderOrImage = viewModel.FolderOrImageDAB[viewModel.FolderOrImageDAB.Count - 1];
            }
        }

        private void ButtonNextPhotoOrFolder_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel viewModel = DataContext as MainViewModel;
            if (viewModel == null)
            {
                return;
            }

            int position = viewModel.SelectedFolderOrImage != null ? viewModel.FolderOrImageDAB.IndexOf(viewModel.SelectedFolderOrImage) : 0;
            if (position < (viewModel.FolderOrImageDAB.Count - 1))
            {
                viewModel.SelectedFolderOrImage = viewModel.FolderOrImageDAB[position + 1];
            }
            else if (position == (viewModel.FolderOrImageDAB.Count - 1))
            {
                viewModel.SelectedFolderOrImage = viewModel.FolderOrImageDAB[0];
            }
        }

        private void _checkBoxVerticalCarousel_Click(object sender, RoutedEventArgs e)
        {
            CarouselFolderOrImage.VerticalOrientation = _checkBoxVerticalCarousel.IsChecked ?? false;
        }

        #endregion

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

        #region Window Loaded

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;

            foreach (var imageOrFolderInfo in managerDBEntities.Folders)
            {
                imageData.Add(new DataModel()
                {
                    Id = imageOrFolderInfo.Id,
                    Name = imageOrFolderInfo.Name,
                    ImageSource = ImageConverter.ConvertByteArrayToBitmapImage(imageOrFolderInfo.MetaDataPicture),
                    Description = imageOrFolderInfo.Description
                });
            }

            DataContext = new MainViewModel(imageData);
        }

        #endregion

        #region Menu Tab Control

        /// <summary>
        /// Show menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void ButtonOpenMenuTab_Click(object sender, RoutedEventArgs e) => GridEmptyMenu.Visibility = Visibility.Visible;

        private void GridEmptyMenu_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => GridEmptyMenu.Visibility = Visibility.Collapsed;


        #region ListViewItem in Menu click

        /// <summary>
        /// Interact with menu option
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void ListViewItemFolder_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FolderWindow folderWindow = new FolderWindow();
            folderWindow.ShowDialog();
        }

        private void ListViewItemPhoto_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void ListViewItemTag_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private async void ListViewItemEditPhoto_MouseDoubleClickAsync(object sender, MouseButtonEventArgs e) => await OpenEditingProgram.Open();        // obsłużyć dodawanie zdjęcia

        private void ListViewItemSettings_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.ShowDialog();         
        }

        private void ListViewItemCloseApp_MouseDoubleClick(object sender, MouseButtonEventArgs e) => Close();

        private void BaseMainMenuPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => MainMenuPanel.Visibility = Visibility.Visible;

        #endregion

        #region Folder interaction

        /// <summary>
        /// When user interact with folder option
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void AddFolder_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void EditFolder_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void DeleteFolder_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }


        #endregion

        #endregion
    }
}
