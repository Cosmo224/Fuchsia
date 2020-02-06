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

namespace Fuchsia.InformationEngine.FuchsiaUX
{
    /// <summary>
    /// Interaction logic for FUXDoclink.xaml
    /// </summary>
    public partial class FUXDoclink : UserControl
    {
        public string Destination { get; set; }
        public string DocLinkContent { get => FuchsiaUXInternal_FUXDoclink_FUXDoclinkText.Text; set => FuchsiaUXInternal_FUXDoclink_FUXDoclinkText.Text = value; }
        public FUXDoclink()
        {
            InitializeComponent();
        }

        private void FuchsiaUXInternal_FUXDoclink_FUXDoclinkText_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //handle click
        }
    }
}
