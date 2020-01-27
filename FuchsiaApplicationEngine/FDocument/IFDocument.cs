using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Controls;

namespace Fuchsia.InformationEngine
{
    public interface IFDocument
    {
        string DocumentDescription { get; set; } // The description of the FDocument.
        string DocumentName { get; set; } // The name of the FDocument.
        string DocumentPath { get; set; } // The relative (to the FApp) path to the FDocument.
        string DocumentTitle { get; set; } // The title of the FDocument.
        XmlDocument DocumentXML { get; set; } // The XML of the FDocument.
        RichTextBox DocumentRTB { get; set; } // The FDocument itself.
    }

}
