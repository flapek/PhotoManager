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
    public partial class TagWindow : Window
    {
        private PhotoManagerDBEntities managerDBEntities = new PhotoManagerDBEntities();
        private bool isDataDirty = false;

        public TagWindow()
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

        private void ButtonCloseWindow_Click(object sender, MouseButtonEventArgs e) => Close();

        #endregion

        #region Button control

        private async void ButtonAddTag_MouseDoubleClickAsync(object sender, MouseButtonEventArgs e)
        {
            try
            {
                managerDBEntities.Tags.Add(new Tags
                {
                    TagName = TextBoxTagName.Text
                });

                int done = await managerDBEntities.SaveChangesAsync();
                if (done == 1)
                {
                    MessageBox.Show(Constants.MessageBoxTagIsAdded, Constants.CaptionNameInformation, MessageBoxButton.OK, MessageBoxImage.Information);
                }

                LoadTagsFromEntity();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Constants.MessageBoxIncorectData + "\n" + ex.Message, Constants.CaptionNameError, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion

        #region TextBox control

        private void TextBoxTagName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!(TextBoxTagName.Text == string.Empty))
            {
                ButtonAddTag.IsEnabled = true;
                isDataDirty = true;
            }
            else
            {
                ButtonAddTag.IsEnabled = false;
                isDataDirty = false;
            }
        }

        #endregion

        #region Window loaded

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadTagsFromEntity();
        }

        #endregion

        #region Local fuction

        private void LoadTagsFromEntity()
        {
            ListBoxTag.Items.Clear();
            foreach (Tags item in managerDBEntities.Tags)
            {
                ListBoxTag.Items.Add(new ListBoxItem
                {
                    Content = item.TagName,
                    Tag = item.TagName
                });
            }
        }

        #endregion
    }
}
