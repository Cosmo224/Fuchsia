using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
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
/// mXAML (Micro-XAML) Reader
/// 
/// © 2020 Cosmo.
/// 
/// </summary>

namespace Fuchsia.InformationEngine
{ 
    public partial class FInfoEngine
    {
        /// <summary>
        /// 
        /// Fuchsia Internal API. Creates a Fuchsia Textbox containing a parsed mXAML document. Another overload returns a string list.
        /// 
        /// </summary>
        /// <param name="FDocumentToParse">The document to parse.</param>
        /// <returns>A FTextBox containing the parsed text.</returns>
        public RichTextBox FParseDocument(IFDocument FDocumentToParse)
        {
            XmlNode FPageContent = FDocumentToParse.DocumentXML.FirstChild;
            RichTextBox _textbox_temp = new RichTextBox();

            _textbox_temp.Document = new FlowDocument();
            _textbox_temp.IsReadOnly = true;

            _textbox_temp = FMXamlReader.FReadMXamlXml(FPageContent, _textbox_temp);

            return _textbox_temp;
        }

    }
}
