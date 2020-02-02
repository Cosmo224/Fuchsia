using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuchsia.InformationEngine
{
    public partial class FInfoEngine
    {
        public void LoadDocument(IFDocument DocumentToLoad)
        {
            DocumentToLoad.DocumentXML = FLoadXml(DocumentToLoad.DocumentPath);
            FParseDocument(DocumentToLoad);
        }
        public void LoadDocumentByName(IFApp AppToSearchForDocumentIn, string DocumentName)
        {
            foreach (IFDocument FDocumentToSearch in AppToSearchForDocumentIn.Documents)
            {
                if (FDocumentToSearch.DocumentName == DocumentName)
                {
                    
                    LoadDocument(FDocumentToSearch);
                }
            }
        }
    }
}
