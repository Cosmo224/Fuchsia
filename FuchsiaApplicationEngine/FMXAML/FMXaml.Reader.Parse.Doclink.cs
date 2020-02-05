using Fuchsia.InformationEngine.FuchsiaUX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Fuchsia.InformationEngine
{
    public partial class FMXamlReader
    {
        internal Paragraph FMXAML_Parse_Doclink(XmlNode FPageContentElement, Paragraph FParagraphToPopulate)
        {
            FUXDoclink FUXDoc = new FUXDoclink();
            XmlAttributeCollection FContentElementAttributes = FPageContentElement.Attributes;



            foreach (XmlAttribute FContentElementAttribute in FContentElementAttributes)
            {
                switch (FContentElementAttribute.Name)
                {
                    case "Content": //TEMP
                        FUXDoc = FMXAML_TextAPI_AddDoclink(FParagraphToPopulate, FContentElementAttribute.Value);
                        continue;
                    case "Destination":
                        FUXDoc.Destination = FContentElementAttribute.Value; //Destinations
                        continue;
                }
            }

            FParagraphToPopulate = FMXAML_TextAPI_AddDoclinkToParagraph(FParagraphToPopulate, FUXDoc);
            return FParagraphToPopulate;
        }
    }
}
