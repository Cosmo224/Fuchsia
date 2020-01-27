using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

/// <summary>
/// 
/// Fuchsia Information Engine
/// 
/// Main App class.
/// 
/// Fuchsia runs one app at a time. For now.
/// 
/// </summary>

namespace Fuchsia.InformationEngine
{
    public class FApp : IFApp
    {
        public string AppAuthor { get; set; } // The author of the app. OPTIONAL.
        public string AppDescription { get; set; } // The description of the app. OPTIONAL.
        public string AppDeveloper { get; set; } // The developer of the app. OPTIONAL.
        public string AppName { get; set; } // The name of the app. REQUIRED.
        public XmlDocument AppPage { get; set; } // Internal use only. 
        public string AppPath { get; set; } // Path to the folder containing the app folder. REQUIRED.
        public string AppPurpose { get; set; } // The purpose of the app. OPTIONAL.
        public List<IFDocument> Documents { get; set; } // Internal use only.
        public IFDocument TitlePage { get; set; } // Title page of the app. Always /Title.xml.
    }
}
