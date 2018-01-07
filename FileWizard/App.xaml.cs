using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace FileWizard
{
    public partial class App : Application
    {
        public static List<FileInfo> Files { get; set; }
        public static string Directory { get; set; }
    }
}
