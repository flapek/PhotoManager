using PhotoManager.Model;
using PhotoManager.ViewModel;
using PhotoManager.Workers.LoadData;
using PhotoManager.Workers.Open;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace PhotoManager
{
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

        private void _checkBoxVerticalCarousel_Click(object sender, RoutedEventArgs e)
        {
            CarouselFolderOrImage.VerticalOrientation = _checkBoxVerticalCarousel.IsChecked ?? false;
        }

        #endregion

        #region Window Button Control

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

        private async void ButtonBack_MouseDoubleClickAsync(object sender, MouseButtonEventArgs e)
        {
            MainViewModel viewModel = DataContext as MainViewModel;

            int? currentId = await GetId.GetCurrentFolderId(managerDBEntities.Folders, viewModel.SelectedFolderOrImage.Id);

            if (currentId == 0)
            {
                MessageBox.Show(Constants.MessageBoxCantBack, Constants.CaptionNameInformation, MessageBoxButton.OK,
                    MessageBoxImage.Information);
                return;
            }

            viewModel.FolderOrImageDAB.Clear();

            ObservableCollection<DataModel> dataModel = await LoadCarouselDataModel.LoadCarouselModel(managerDBEntities.Folders, currentId);

            DataContext = new MainViewModel(dataModel);
        }

        private async void ButtonNext_OnClick(object sender, RoutedEventArgs e)
        {
            MainViewModel viewModel = DataContext as MainViewModel;

            int id = viewModel.SelectedFolderOrImage.Id;

            viewModel.ClearData();

            ObservableCollection<DataModel> dataModel = await LoadCarouselDataModel.LoadCarouselModel(managerDBEntities.Folders, id);

            if (dataModel.Count == 0)
            {
                MessageBox.Show(Constants.MessageBoxNoMoreDate, Constants.CaptionNameInformation, MessageBoxButton.OK,
                    MessageBoxImage.Information);
                return;
            }

            DataContext = new MainViewModel(dataModel);
        }

        #endregion

        #region Window Loaded

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;

            ObservableCollection<DataModel> dataModel = await LoadCarouselDataModel.LoadCarouselModel(managerDBEntities.Folders);

            DataContext = new MainViewModel(dataModel);
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
            folderWindow.Closing += FolderWindow_ClosingAsync;
            folderWindow.ShowDialog();
        }

        private async void FolderWindow_ClosingAsync(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ObservableCollection<DataModel> dataModel = await LoadCarouselDataModel.LoadCarouselModel(managerDBEntities.Folders);

            DataContext = new MainViewModel(dataModel);
        }

        private void ListViewItemPhoto_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            PhotoWindow photoWindow = new PhotoWindow();
            photoWindow.ShowDialog();
        }

        private void ListViewItemTag_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TagWindow tagWindow = new TagWindow();
            tagWindow.ShowDialog();
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

        #endregion

    }
}
