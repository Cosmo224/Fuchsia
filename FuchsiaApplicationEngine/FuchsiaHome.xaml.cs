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

namespace Fuchsia.InformationEngine
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class FuchsiaHome : Window
    {
        public FuchsiaHome(RichTextBox TextBoxToInitHomeWindowWith)
        {
            InitializeComponent();
            FDispDoc(TextBoxToInitHomeWindowWith);
        }

        public void FDispDoc(RichTextBox TextBoxToInit)
        {
            TextBoxToInit.Margin = new Thickness(0, 50, 0, 0);
            TextBoxToInit.BorderThickness = new Thickness(0, 0, 0, 0);
            TextBoxToInit.Height = this.Height;
            TextBoxToInit.Width = this.Width;
            FuchsiaHomeCore.Children.Add(TextBoxToInit);
            
        }

        private void FuchsiaExit__Temporary_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //lazy event handler...
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F9 & (Keyboard.IsKeyDown(Key.LeftShift) | Keyboard.IsKeyDown(Key.RightShift))) 
            {
                FuchsiaAbout FuchsiaAbout = new FuchsiaAbout();
                FuchsiaAbout.Owner = this;
                FuchsiaAbout.Show(); 
            }
        }
    }
}
