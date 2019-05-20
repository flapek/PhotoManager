using Microsoft.Win32;
using PhotoManager.Settings;
using PhotoManager.Workers.Open;
using System;
using System.Windows;
using System.Windows.Input;

namespace PhotoManager
{
    public partial class SettingsWindow : Window
    {
        private UserSettings userSettings = new UserSettings();
        private bool isDataDirty = false;

        public SettingsWindow()
        {
            InitializeComponent();
            SourcePathToEditingProgramTextBox.Text = userSettings.PathToEditingProgram;
            HintOpenProgramTextBlock.Text = Constants.OptionHintForOpenEditingProgram;
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

        #region Choose option

        /// <summary>
        /// Which option user want change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
    
        private void ListViewItemChooseProgram_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OptionPanelChooseProgram.Visibility = Visibility.Visible;
            TestPanel.Visibility = Visibility.Collapsed;
        }

        #endregion

        //delete later
        private void Test_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OptionPanelChooseProgram.Visibility = Visibility.Collapsed;
            TestPanel.Visibility = Visibility.Visible;
        }

        #region Button interaction

        private void SaveOptionButton_Click(object sender, RoutedEventArgs e)
        {
            if (isDataDirty)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show(Constants.MessageBoxStringWarningSaveOption, Constants.CaptionNameWarning, MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (MessageBoxResult.Yes == messageBoxResult)
                {
                    userSettings.PathToEditingProgram = SourcePathToEditingProgramTextBox.Text;
                    userSettings.Save();
                    SaveOptionButton.IsEnabled = false;
                    isDataDirty = false;
                }
            }
        }         

        private void DefaultOptionButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show(Constants.MessageBoxStringDefaultOption, Constants.CaptionNameOption, MessageBoxButton.YesNo);

            if (MessageBoxResult.Yes == messageBoxResult)
            {
                userSettings.Reset();
                SourcePathToEditingProgramTextBox.Text = userSettings.PathToEditingProgram;
            }
        }

        private void SourcePathToEditingProgramTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!(userSettings.PathToEditingProgram == SourcePathToEditingProgramTextBox.Text))
            {
                SaveOptionButton.IsEnabled = true;
                isDataDirty = true;
            }
            else
            {
                SaveOptionButton.IsEnabled = false;
                isDataDirty = false;
            }
        }   //do poprawy

        private void SearchProgramPathButton_Click(object sender, RoutedEventArgs e)
        {
            FileExplorer file = new FileExplorer("EXE (*.exe)|*.exe", false);
            OpenFileDialog filename = file.Open(Environment.SpecialFolder.Desktop);
            if (file.verificate)
            {
                isDataDirty = true;
                SaveOptionButton.IsEnabled = true;
                SourcePathToEditingProgramTextBox.Text = filename.FileName;
            }
        }

        #endregion



    }
}
