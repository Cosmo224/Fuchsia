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
            FuchsiaVersionInformation.Text = $"Version {FVersion.Version.Major}.{FVersion.Version.Minor} (build {FVersion.Version.Build}.{FVersion.Version.Revision}; {FVersion.Status})";
            FuchsiaVersionInformation_BuildDate.Text = $"Build date: {FVersion.BuildTime.ToString()}";
            FuchsiaVersionInformation_Status.Text = $"Status: {FVersion.Status}";
            FuchsiaVersionInformation_Debug.Text = $"Debug mode: {FVersion.DebugStatus.ToString()}";
        }

        private void FuchsiaExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
