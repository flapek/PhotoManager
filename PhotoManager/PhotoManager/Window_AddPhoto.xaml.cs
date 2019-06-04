using PhotoManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PhotoManager
{
    public partial class Window_AddPhoto : Window
    {
        private PhotoManagerDBEntities managerDBEntities = new PhotoManagerDBEntities();
        private bool isDataDirty = false;

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

        private void ButtonSavePhoto_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButtonBrowser_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButtonCancel_OnMouseClick(object sender, RoutedEventArgs e) => Close();

        #endregion
       
    }
}
