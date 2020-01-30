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
using System.Windows.Shapes;

/// <summary>
/// 
/// Fuchsia Error API
/// 
/// Handles errors in Fuchsia using the FError class.
/// 
/// Last modified 2020-01-16. Please unfuck the constructor.
/// 
/// </summary>

namespace Fuchsia.InformationEngine
{
    /// <summary>
    /// Interaction logic for FuchsiaError.xaml
    /// </summary>
    public partial class FuchsiaError : Window
    {
        internal FErrorSeverity _InternalErrorSeverity;
        public FuchsiaError(int ErrId, string FriendlyDesc, FErrorSeverity ErrorSeverity, Exception UnfriendlyDesc = null)
        {
            InitializeComponent();
            FErrorWindowInit(ErrId, FriendlyDesc, ErrorSeverity, UnfriendlyDesc);


        }

        internal void FErrorWindowInit(int ErrId, string FriendlyDesc, FErrorSeverity ErrorSeverity, Exception UnfriendlyDesc = null)
        {
            _InternalErrorSeverity = ErrorSeverity;

            this.Error_FriendlyDesc.Text = FriendlyDesc;

            if (UnfriendlyDesc != null)
            {
                this.Error_UnfriendlyDesc.Text = $"{UnfriendlyDesc.ToString()} (Error # {ErrId})";
            }

            // Final stage of constructor: Error Window Setup based on ErrorSeverity
            switch (_InternalErrorSeverity)
            {
                case FErrorSeverity.Notification:
                    this.Height = 195;
                    Error_Error.Text = "Notification";
                    Error_OKButton.Margin = new Thickness(532, 108, 0, 0);
                    Error_OKButton.Content = "Continue";
                    this.Grid.Children.Remove(Error_UnfriendlyDesc);
                    return;
                case FErrorSeverity.Warning:
                    this.Height = 195;
                    Error_Error.Text = "Warning";
                    Error_OKButton.Margin = new Thickness(532, 108, 0, 0);
                    Error_OKButton.Content = "Continue";
                    this.Grid.Children.Remove(Error_UnfriendlyDesc);
                    return;
                case FErrorSeverity.Error:
                    this.Height = 195;
                    Error_Error.Text = "Error";
                    Error_OKButton.Margin = new Thickness(532, 108, 0, 0);
                    Error_OKButton.Content = "Continue";
                    this.Grid.Children.Remove(Error_UnfriendlyDesc);
                    return;
                case FErrorSeverity.FatalError:
                    this.Title = "Fuchsia has crashed.";
                    Error_Error.Text = "Fuchsia has crashed.";
                    Error_Error.FontSize = 48;
                    Error_Occurred.Text = "We're sorry! Please report the detailed .NET exception information below.";
                    Error_Occurred.Width = this.Width;
                    Error_OKButton.Content = "Exit";
                    return;
            }
        }

        private void Error_OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (_InternalErrorSeverity == FErrorSeverity.FatalError)
            {
                Application.Current.Shutdown(); //Shutdown Application
            }
            else
            {
                this.Close();
            }
        }
    }

    public enum FErrorSeverity { Notification, Warning, Error, FatalError }
    public static class FError
    {
        public static void ThrowError(int ErrId, string FriendlyDesc, FErrorSeverity ErrorSeverity, Exception UnfriendlyDesc = null)
        {
            FuchsiaError FuchsiaError = new FuchsiaError(ErrId, FriendlyDesc, ErrorSeverity, UnfriendlyDesc);
            FuchsiaError.ShowDialog();
        }
    }
}
