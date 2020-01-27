using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fuchsia.InformationEngine
{
    /// <summary>
    /// Interaction logic for FuchsiaAbout.xaml
    /// </summary>
    public partial class FuchsiaAbout : Window
    {
        public FuchsiaAbout()
        {
            InitializeComponent();
            FAboutInit(); 
        }

        internal void FAboutInit()
        {
            FuchsiaVersionInformation.Text = $"{FVersion.Version.Major}.{FVersion.Version.Minor} (build {FVersion.Version.Build}.{FVersion.Version.Revision})";
            FuchsiaVersionInformation_BuildDate.Text = FVersion.BuildTime.ToString();
            FuchsiaVersionInformation_Status.Text = FVersion.Status;
            FuchsiaVersionInformation_Debug.Text = FVersion.DebugStatus.ToString();
            FuchsiaVersionInformation_UpdateAvailable.Visibility = Visibility.Hidden;
        }
    }

    public static class FVersion
    {
        public static readonly Version Version = Assembly.GetExecutingAssembly().GetName().Version;
        public static readonly DateTime BuildTime = File.GetLastWriteTime(Assembly.GetExecutingAssembly().Location);
        public static readonly string Status = "Alpha";
        public static readonly bool DebugStatus = true; // temp code.
    }
}
