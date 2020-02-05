using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Controls;
using Fuchsia.InformationEngine.FuchsiaUX;

namespace Fuchsia.InformationEngine
{
    internal enum MxamlNode { Paragraph, TextBlock, Rectangle, Doclink }
    public partial class FMXamlReader
    {

        /// <summary>
        /// 
        /// Parses MXaml in an arbitrary XmlNode.
        /// 
        /// </summary>
        public RichTextBox FReadMXamlXml(XmlNode FXmlNode, RichTextBox BoxToPopulate)
        {
            try
            {
                XmlNodeList FXmlNodeList = FXmlNode.ChildNodes;

                foreach (XmlNode FPageContentElement in FXmlNodeList)
                {
                    // LAZY UGLY BAD HACK

                    MxamlNode MXaml_Parse = (MxamlNode)Enum.Parse(typeof(MxamlNode), FPageContentElement.Name);
                    switch (MXaml_Parse)
                    {
                        case MxamlNode.Paragraph: // Temporary code for development of FMXAML_Parse_Paragraph
                            BoxToPopulate = FMXAML_Parse_Paragraph(FPageContentElement, BoxToPopulate);
                            continue;

                        case MxamlNode.TextBlock:
                            BoxToPopulate = FMXAML_Parse_TextBlock(FPageContentElement, BoxToPopulate);
                            continue;

                    }

                }

                return BoxToPopulate;
            }
            catch (ArgumentException err)
            {
                FError.ThrowError(14, "An invalid mXAML node was found.", FErrorSeverity.FatalError, err);
                return null; 
            }
        }
    }
}
