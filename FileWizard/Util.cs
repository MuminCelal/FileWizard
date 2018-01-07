using System.IO;
using Microsoft.Win32;

namespace FileWizard
{
    public class Util
    {
        public string Directory()
        {
            string directoryPath = null;

            OpenFileDialog fileDialog = new OpenFileDialog();
            bool? dialogResult = fileDialog.ShowDialog();

            if (dialogResult != null && dialogResult == true)
            {
                directoryPath = Path.GetDirectoryName(fileDialog.FileName);
            }

            return directoryPath;
        }
    }
}
