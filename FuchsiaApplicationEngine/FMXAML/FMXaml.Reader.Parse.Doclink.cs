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
        internal RichTextBox FMXAML_Parse_Doclink(XmlNode FPageContentElement, RichTextBox BoxToPopulate)
        {
            Inline FInline = new Run(); 
            XmlAttributeCollection FContentElementAttributes = FPageContentElement.Attributes;

            foreach (XmlAttribute FContentElementAttribute in FContentElementAttributes)
            {
                switch (FContentElementAttribute.Name)
                {
                    case "destination":


                        continue;
                }
            }
        }
    }
}
