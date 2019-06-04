using PhotoManager.Model;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;

namespace PhotoManager
{
    public partial class TagWindow : Window
    {
        private PhotoManagerDBEntities managerDBEntities = new PhotoManagerDBEntities();
        private bool isDataDirty = false;

        private bool IsTagChoosen = false;

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

        private void ButtonCloseWindow_Click(object sender, MouseButtonEventArgs e)
        {
            if (isDataDirty)
            {
                if (MessageBox.Show(Constants.MessageBoxStringClose, Constants.CaptionNameWarning, MessageBoxButton.YesNo,
                    MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    Close();
                }
            }
            else Close();
        }

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

        private async void ButtonDeleteTag_MouseDoubleClickAsync(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem item = (ListBoxItem)ListBoxTag.SelectedItem;

            if (MessageBox.Show(Constants.MessageBoxDelete, Constants.CaptionNameWarning,
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Tags tags = managerDBEntities.Tags.First(x => x.TagName == item.Tag.ToString());
                managerDBEntities.Tags.Remove(tags);

                int done = await managerDBEntities.SaveChangesAsync();
                if (done == 1)
                {
                    MessageBox.Show(Constants.MessageBoxDataDelete, Constants.CaptionNameInformation, MessageBoxButton.OK, MessageBoxImage.Information);
                    TextBoxTagName.Text = string.Empty;

                    LoadTagsFromEntity();
                }
            }
        }

        private void ButtonCancel_MouseDoubleClick(object sender, MouseButtonEventArgs e) => Close();

        #endregion
 
        #region TextBox control

        private void TextBoxTagName_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListBoxItem item = (ListBoxItem)ListBoxTag.SelectedItem;

            if (IsTagChoosen)
            {
                if (TextBoxTagName.Text != item.Content)
                {
                    ButtonAddTag.IsEnabled = true;
                    ButtonDeleteTag.IsEnabled = true;
                    isDataDirty = true;
                }
                else
                {
                    ButtonAddTag.IsEnabled = false;
                    ButtonDeleteTag.IsEnabled = true;
                    isDataDirty = false;
                }
            }
            else
            {
                if (TextBoxTagName.Text != item.Content)
                {
                    ButtonAddTag.IsEnabled = true;
                    ButtonDeleteTag.IsEnabled = false;
                    isDataDirty = true;
                }
                else
                {
                    ButtonAddTag.IsEnabled = false;
                    ButtonDeleteTag.IsEnabled = false;
                    isDataDirty = false;
                }
            }
        }

        #endregion

        #region Window loaded

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;

            LoadTagsFromEntity();
        }

        #endregion

        #region Local fuction

        private void LoadTagsFromEntity()
        {
            ListBoxTag.Items.Clear();
            foreach (Tags item in managerDBEntities.Tags)
            {
                ListBoxItem listBoxItem = new ListBoxItem
                {
                    Content = item.TagName,
                    Tag = item.TagName
                };

                ListBoxTag.Items.Add(listBoxItem);

                listBoxItem.MouseDoubleClick += ListBoxItem_MouseDoubleClick;
            }
        }

        #endregion

        #region ListBoxItem interaction

        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem listBoxItem = (ListBoxItem)sender;

            IsTagChoosen = true;

            TextBoxTagName.Text = listBoxItem.Tag.ToString();
        }

        #endregion


    }
}
