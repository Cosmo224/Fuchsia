using Fuchsia.InformationEngine; 
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
using System.Windows.Navigation;
using System.Windows.Shapes;

/// <summary>
/// 
/// Fuchsia
/// 
/// Coming soon...
/// 
/// </summary>

namespace Fuchsia
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IFApp CurrentApp { get; set; } // the currently running app.
        public FInfoEngine InformationEngine { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            InformationEngine = new FInfoEngine();
            ParseCLIArgs();
        }

        internal void ParseCLIArgs()
        {
            string[] CLIArgs = App.CommandLineArgs;

            if (CLIArgs.Length == 0 | CLIArgs == null) return;

            foreach (string CLIArg in CLIArgs)
            {
                switch (CLIArg)
                {
                    case "-loaddemo":
                        CurrentApp = InformationEngine.FStartApp(".\\Apps", "Demo"); //TEMP
                        return;
                }
            }
        }
    }
}
