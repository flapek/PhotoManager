using Microsoft.Win32;
using System;

namespace PhotoManager.Workers.Open
{
    class FileExplorer
    {
        private OpenFileDialog openFileDialog = new OpenFileDialog();
        internal bool verificate = false;

        public FileExplorer(string openFileDialogFilter, bool openFileDialogMultiselect)
        {
            openFileDialog.Filter = openFileDialogFilter;
            openFileDialog.Multiselect = openFileDialogMultiselect;
        }

        public OpenFileDialog Open(Environment.SpecialFolder specialFolder)
        {
            openFileDialog.InitialDirectory = @"C:\";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(specialFolder);
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;

            if (openFileDialog.ShowDialog() == true)
            {
                verificate = true;
                return openFileDialog;
            }
            else return null;
        }

    }
}
