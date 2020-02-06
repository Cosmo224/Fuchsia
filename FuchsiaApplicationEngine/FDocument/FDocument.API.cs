using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuchsia.InformationEngine
{
    public partial class FInfoEngine
    {
        public void FLoadDocument(IFDocument DocumentToLoad)
        {
            DocumentToLoad.DocumentXML = FLoadXml(DocumentToLoad.DocumentPath);
            DocumentToLoad.DocumentRTB = FParseDocument(DocumentToLoad);
            FuchsiaHome FuchsiaHome = new FuchsiaHome(DocumentToLoad.DocumentRTB); //tempcode.
            FuchsiaHome.Show();
        }
        public void FLoadDocumentByName(IFApp AppToSearchForDocumentIn, string DocumentName)
        {
            foreach (IFDocument FDocumentToSearch in AppToSearchForDocumentIn.Documents)
            {
                if (FDocumentToSearch.DocumentName == DocumentName)
                {
                    FLoadDocument(FDocumentToSearch);
                }
            }
        }
    }
}
