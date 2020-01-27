using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Controls;

namespace Fuchsia.InformationEngine
{
    public partial class FMXamlReader
    {
        /// <summary>
        /// Internal API for loading text. Parses the Paragraph node. UNDER CONSTRUCTION - SUBJECT TO CHANGE AT ANY POINT..
        /// </summary>
        /// <param name="BoxToPopulate">The box to populate </param>
        /// <param name="FPageContentElement">The xmlnode to use to parse the subnodes of the Paragraph.</param>
        /// <returns></returns>
        internal RichTextBox FMXAML_Parse_Paragraph(XmlNode FPageContentElement, RichTextBox BoxToPopulate) // Parses a paragraph.
        {
            XmlNodeList FParagraphChildren = FPageContentElement.ChildNodes;

            foreach (XmlNode FParagraphChild in FParagraphChildren)
            {
                if (FParagraphChild.Name == "#comment") continue;

                MxamlNode MXamlChild_Parse = (MxamlNode)Enum.Parse(typeof(MxamlNode), FParagraphChild.Name);

                switch (MXamlChild_Parse)
                {
                    case MxamlNode.TextBlock:
                        BoxToPopulate = FMXAML_Parse_TextBlock(FParagraphChild, BoxToPopulate);
                        continue;
                }
            }
            return BoxToPopulate;
        }
    }
}
