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

        /// <summary>
        /// Internal API for parsing textblocks. (OVERLOAD)
        /// </summary>
        /// <param name="NodeToParse">The node to parse.</param>
        /// <param name="BoxToPopulate">The richtextbox to populate. </param>
        /// <returns></returns>
        internal Paragraph FMXAML_Parse_TextBlock(XmlNode NodeToParse, Paragraph ParaToPopulate)
        {
            XmlAttributeCollection FXmlNodeAttributes = NodeToParse.Attributes; // should be verified by now.

            Inline TextToAdd = new Run();

            foreach (XmlAttribute FXmlAttribute in FXmlNodeAttributes)
            {

                switch (FXmlAttribute.Name) // TEMP, Pre-Factory Class code.
                {
                    case "content":
                    case "Content":
                        try
                        {  //TEMPCODE
                            TextToAdd = FMXAML_TextAPI_AddText(ParaToPopulate, FXmlAttribute.Value, 18);
                            
                        }
                        catch (NotImplementedException)
                        {
                            FError.ThrowError(12, $"API call not implemented", FErrorSeverity.FatalError);
                        }
                        continue;
                    case "fontstyle":
                    case "FontStyle":
                        string FXmlAttributeValue = FXmlAttribute.Value;

                        if (FXmlAttributeValue.Contains("bold"))
                        {
                            TextToAdd = FMXAML_TextAPI_SetFontWeight(TextToAdd, 500); //temp
                        }
                        else if (FXmlAttributeValue.Contains("italic"))
                        {
                            TextToAdd = FMXAML_TextAPI_SetFontStyle(TextToAdd, "Italic");
                        }
                        else if (FXmlAttributeValue.Contains("oblique"))
                        {
                            TextToAdd = FMXAML_TextAPI_SetFontStyle(TextToAdd, "Oblique");
                        }

                        continue;
                    case "fontweight":
                    case "FontWeight":
                        try
                        {
                            int FFontWeight = Convert.ToInt32(FXmlAttribute.Value);

                            TextToAdd = FMXAML_TextAPI_SetFontWeight(TextToAdd, FFontWeight);
                        }
                        catch (FormatException err)
                        {
                            FError.ThrowError(16, "Invalid font weight supplied", FErrorSeverity.FatalError, err);
                        }
                        continue;
                    case "fontsize":
                    case "FontSize":
                        try
                        {
                            double FFontSize = Convert.ToInt32(FXmlAttribute.Value);

                            TextToAdd = FMXAML_TextAPI_SetFontSize(TextToAdd, FFontSize);
                        }
                        catch (FormatException err)
                        {
                            FError.ThrowError(17, "Invalid font size supplied", FErrorSeverity.FatalError, err);
                        }
                        continue;
                }
            }

            ParaToPopulate = FMXAML_TextAPI_AddTextToParagraph(ParaToPopulate, TextToAdd);

            return ParaToPopulate;
        }
    }
}
