using PhotoManager.Model;
using PhotoManager.ViewModel;
using PhotoManager.Workers.Open;
using System.Windows;
using System.Windows.Input;

namespace PhotoManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ImageEntities entities = new ImageEntities();

        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel(entities);

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

            viewModel.SelectedFolderOrImage = selectedElement.DataContext as ImageModel;
        }

        private void ButtonLeftArrow_Click(object sender, RoutedEventArgs e)
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

        private void ButtonRightArrow_Click(object sender, RoutedEventArgs e)
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

        #region Menu Tab Control

        private void ButtonOpenMenuTab_Click(object sender, RoutedEventArgs e) => GridEmptyMenu.Visibility = Visibility.Visible;

        private void GridEmptyMenu_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GridEmptyMenu.Visibility = Visibility.Collapsed;
        }


        #region Button in menu

        private async void ListViewItem_MouseDoubleClickAsync(object sender, MouseButtonEventArgs e)
        {
            await OpenEditingProgram.Open();        // obsłużyć dodawanie zdjęcia
        }

        #endregion

        #endregion
    }
}
