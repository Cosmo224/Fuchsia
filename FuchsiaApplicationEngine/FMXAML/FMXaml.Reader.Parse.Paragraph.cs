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
        /// <summary>
        /// Internal API for loading text. Parses the Paragraph node. UNDER CONSTRUCTION - SUBJECT TO CHANGE AT ANY POINT..
        /// </summary>
        /// <param name="BoxToPopulate">The box to populate </param>
        /// <param name="FPageContentElement">The xmlnode to use to parse the subnodes of the Paragraph.</param>
        /// <param name="ParagraphMode">DEPRECATED - DO NOT USE - ***WILL BE REMOVED!***</param>
        /// <returns></returns>
        internal RichTextBox FMXAML_Parse_Paragraph(XmlNode FPageContentElement, RichTextBox BoxToPopulate, bool ParagraphMode = true) // Parses a paragraph.
        {
            Paragraph TheParagraph = new Paragraph();
            XmlNodeList FParagraphChildren = FPageContentElement.ChildNodes;

            TheParagraph = FMXAML_TextAPI_CreateParagraph();

            foreach (XmlNode FParagraphChild in FParagraphChildren)
            {
                if (FParagraphChild.Name == "#comment") continue;



                MxamlNode MXamlChild_Parse = (MxamlNode)Enum.Parse(typeof(MxamlNode), FParagraphChild.Name);

                switch (MXamlChild_Parse)
                {
                    case MxamlNode.TextBlock:
                        switch (ParagraphMode)
                        {
                            case false:
                                BoxToPopulate = FMXAML_Parse_TextBlock(FParagraphChild, BoxToPopulate);
                                continue;
                            case true:
                                TheParagraph = FMXAML_Parse_TextBlock(FParagraphChild, TheParagraph);
                                continue; 
                        }
                        continue;
                    default:
                        FError.ThrowError(14, "An invalid mXAML node was found.", FErrorSeverity.FatalError);
                        continue; 
                }

                
            }

            if (TheParagraph.Inlines.Count > 0)
            {
                BoxToPopulate = FMXAML_TextAPI_AddParagraphToTextBox(BoxToPopulate, TheParagraph);
            }

            return BoxToPopulate;
        }
    }
}
