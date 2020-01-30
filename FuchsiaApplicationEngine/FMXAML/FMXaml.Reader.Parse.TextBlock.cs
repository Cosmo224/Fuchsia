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
    internal enum FMXamlTextBlockAttributes { Content, FontStyle, FontSize, FontWeight, FontFamily, FontColour } // preparation
    public partial class FMXamlReader
    {
        /// <summary>
        /// Internal API for parsing textblocks.
        /// </summary>
        /// <param name="NodeToParse">The node to parse.</param>
        /// <param name="BoxToPopulate">The richtextbox to populate. </param>
        /// <returns></returns>
        internal RichTextBox FMXAML_Parse_TextBlock(XmlNode NodeToParse, RichTextBox BoxToPopulate)
        {
            XmlAttributeCollection FXmlNodeAttributes = NodeToParse.Attributes; // should be verified by now.

            foreach (XmlAttribute FXmlAttribute in FXmlNodeAttributes)
            {

                switch (FXmlAttribute.Name) // TEMP, Pre-Factory Class code.
                {
                    case "content":
                    case "Content":
                        try
                        {  //TEMPCODE
                            BoxToPopulate = FMXAML_TextAPI_AddText(BoxToPopulate, FXmlAttribute.Value, 18);
                        }
                        catch (NotImplementedException)
                        {
                            FError.ThrowError(12, $"API call not implemented", FErrorSeverity.FatalError);
                        }
                        continue;
                    case "fontstyle":
                    case "FontStyle":
                        continue; 
                }
            }

            return BoxToPopulate;
        }

        internal Paragraph FMXAML_Parse_TextBlock(XmlNode NodeToParse, Paragraph ParaToPopulate)
        {
            XmlAttributeCollection FXmlNodeAttributes = NodeToParse.Attributes; // should be verified by now.

            foreach (XmlAttribute FXmlAttribute in FXmlNodeAttributes)
            {

                switch (FXmlAttribute.Name) // TEMP, Pre-Factory Class code.
                {
                    case "content":
                    case "Content":
        
                        try
                        {  //TEMPCODE
                            ParaToPopulate = FMXAML_TextAPI_AddText(ParaToPopulate, FXmlAttribute.Value, 18);
                        }
                        catch (NotImplementedException)
                        {
                            FError.ThrowError(12, $"API call not implemented", FErrorSeverity.FatalError);
                        }
                        continue;
                    case "fontstyle":
                    case "FontStyle":
                        continue;
                }
            }

            return ParaToPopulate;
        }
    }
}
