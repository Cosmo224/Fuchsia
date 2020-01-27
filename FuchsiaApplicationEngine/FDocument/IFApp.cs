using Fuchsia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Fuchsia.InformationEngine
{
    public interface IFApp //IFAppversion coming soon
    {
        string AppAuthor { get; set; } // Author of the FApp.
        string AppDescription { get; set; } // Description of the FApp.
        string AppDeveloper { get; set; } // Developer of the FApp.
        XmlDocument AppPage { get; set; } // INTERNAL ONLY.
        string AppPath { get; set; } // Path to the folder containing the app folder. REQUIRED.
        string AppName { get; set; } // name of the FApp.
        string AppPurpose { get; set; } // purpose ofthe FApp.
        List<IFDocument> Documents { get; set; } //All documents in the FApp.
        IFDocument TitlePage { get; set; } //The titlepage of the FApp.

    }
}
