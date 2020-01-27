using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Controls;

namespace Fuchsia.InformationEngine
{
    public class FDocument : IFDocument
    {
        public virtual string DocumentDescription { get; set; } // The description of the FDocument.
        public virtual string DocumentName { get; set; } // The name of the FDocument.
        public virtual string DocumentPath { get; set; } // The relative (to the FApp) path to the FDocument.
        public virtual string DocumentTitle { get; set; } // The title of the FDocument. REQUIRED?
        public virtual string DocumentVersion { get; set; } // The version of the FDocument. OPTIONAL.
        public virtual XmlDocument DocumentXML { get; set; } // The XML of the FDocument.
        public virtual RichTextBox DocumentRTB { get; set; }
    }

    public class FDocumentTitlePage : FDocument
    {
        public override string DocumentDescription { get; set; } // The description of the FDocument.
        public override string DocumentName { get; set; } // The name of the FDocument.
        public override string DocumentPath { get; set; } // The relative (to the FApp) path to the FDocument.
        public override string DocumentTitle { get; set; } // The title of the FDocument. REQUIRED?
        public override string DocumentVersion { get; set; } // The version of the FDocument. OPTIONAL.
        public override XmlDocument DocumentXML { get; set; } // The XML of the FDocument.
        public IFDocument ContentsPage { get; set; } // optional contents page.
        public string DocumentSummary { get; set; } // summary.
        public override RichTextBox DocumentRTB { get; set; }
    }
}
