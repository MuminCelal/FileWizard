using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace FileWizard
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_List_Click(object sender, RoutedEventArgs e)
        {
            string directory = TextBox_Directory.Text;

            if (!string.IsNullOrWhiteSpace(directory) && Directory.Exists(directory))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(@directory);
                App.Files = directoryInfo.GetFiles().ToList();

                foreach (FileInfo file in App.Files)
                {
                    ListBox_FileList.Items.Add(file);
                }

                Label_FileCount.Content = ListBox_FileList.Items.Count;

                Grid_SubGrid.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Give right directory path");
            }
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            string savingDirectory = TextBox_SavingDirectory.Text;
            string extension = TextBox_Extension.Text;

            if (!string.IsNullOrWhiteSpace(savingDirectory) && Directory.Exists(savingDirectory) && !string.IsNullOrWhiteSpace(extension))
            {
                extension = extension.Trim('.');

                foreach (FileInfo file in App.Files)
                {
                    string destinationFile = Path.Combine(savingDirectory, file.Name);
                    File.Copy(file.FullName, destinationFile, true);

                    if (File.Exists(destinationFile + "." + extension))
                    {
                        File.Delete(destinationFile + "." + extension);
                    }

                    File.Move(destinationFile, Path.ChangeExtension(destinationFile, "." + extension));
                }

                MessageBox.Show("File extension changed and file saved successfully");
            }
            else
            {
                MessageBox.Show("Give saving directory or extension");
            }
        }
    }
}
