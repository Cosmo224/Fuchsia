using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

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
        /// <param name="ParaToPopulate">The paragraph to populate. </param>
        /// <returns></returns>
        internal Paragraph FMXAML_Parse_TextBlock(XmlNode NodeToParse, Paragraph ParaToPopulate) // maybe we need to split the code for this up into various fmxamlreader stuff
        {
            XmlAttributeCollection FXmlNodeAttributes = NodeToParse.Attributes; // should be verified by now.

            Inline TextToAdd = new Run();

            foreach (XmlAttribute FXmlAttribute in FXmlNodeAttributes)
            {

                switch (FXmlAttribute.Name) // TODO: FACTORY CLASS? AND ENUM.
                {
                    case "content": // the content of the textblock
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
                    case "fontfamily": // the font family of the textblock
                    case "FontFamily":
                        try
                        {
                            TextToAdd = FMXAML_TextAPI_SetFontFamily(TextToAdd, FXmlAttribute.Value);
                        }
                        catch (ArgumentException err)
                        {
                            FError.ThrowError(18, "Invalid font size supplied", FErrorSeverity.FatalError, err);
                        }
                        continue;
                    case "fontstyle": // the font family of the textblock
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
                    case "fontsize": // the font size of the textblock
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
                    case "fontweight": // the font weight of the textblock
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
                    case "foreground":
                    case "Foreground": // the foreground colour of the textblock
                    case "ForegroundColor":
                    case "ForegroundColour":
                        try
                        {
                            Color FForegroundColour = FMXAML_TextAPI_GetColourFromXMLValue(FXmlAttribute.Value);
                            
                            TextToAdd = FMXAML_TextAPI_SetFontFgColour(TextToAdd, FForegroundColour);
                        }
                        catch (FormatException err)
                        {
                            FError.ThrowError(20, "Invalid foreground colour supplied", FErrorSeverity.FatalError, err);
                        }
                        catch (OverflowException err)
                        {
                            FError.ThrowError(21, "Invalid foreground colour supplied - every RGB(A) component must be between 0 and 255", FErrorSeverity.FatalError, err);
                        }
                        continue;
                    case "background":
                    case "Background":
                    case "BackgroundColor":
                    case "BackgroundColour":
                        try
                        {
                            Color FBackgroundColour = FMXAML_TextAPI_GetColourFromXMLValue(FXmlAttribute.Value);

                            TextToAdd = FMXAML_TextAPI_SetFontBgColour(TextToAdd, FBackgroundColour);
                        }
                        catch (FormatException err)
                        {
                            FError.ThrowError(22, "Invalid background colour supplied", FErrorSeverity.FatalError, err);
                        }
                        catch (OverflowException err)
                        {
                            FError.ThrowError(23, "Invalid background colour supplied - every RGB(A) component must be between 0 and 255", FErrorSeverity.FatalError, err);
                        }
                        continue;
                }
            }

            ParaToPopulate = FMXAML_TextAPI_AddTextToParagraph(ParaToPopulate, TextToAdd);

            return ParaToPopulate;
        }
    }
}
