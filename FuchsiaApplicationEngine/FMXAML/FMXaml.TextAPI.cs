using Fuchsia.InformationEngine.FuchsiaUX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Fuchsia.InformationEngine
{
    partial class FMXamlReader
    { 
        /// <summary>
        /// Internal API for loading text. Creates a Block.
        /// </summary>
        /// <param name="Content">The content.</param>
        /// <returns></returns>
        internal Block FMXAML_TextAPI_CreateTextBlock(string Content)
        {
            Block _textblock = new Paragraph(new Run(Content));
            return _textblock;
        }

        /// <summary>
        /// Internal API for loading text.
        /// </summary>
        /// <returns>A paragraph object.</returns>
        internal Paragraph FMXAML_TextAPI_CreateParagraph()
        {
            Paragraph _temppara = new Paragraph();
            return _temppara;
        }

        /// <summary>
        /// 
        /// Internal API for loading text.
        /// 
        /// </summary>
        /// <param name="FTextBox">The RichTextBox to add the text to</param>
        /// <param name="Content">The text to add to the RichTextBox.</param>
        /// <param name="FontSize">The size to set the text to.</param>
        /// <param name="FontFamily">The fontfamily to set the text to.</param>
        /// <param name="FontStyle">The style to set the text to.</param>
        /// <param name="FontWght">The font weight to set the text to.</param>
        internal RichTextBox FMXAML_TextAPI_AddText(RichTextBox FTextBox, string Content, double FontSize = Double.NaN, string FontFamily = null, string FontStyle = null, int FontWght = Int32.MaxValue)
        {
            Block _tempblock = new Paragraph(new Run(Content));

            if (FontFamily != null)
            {
                _tempblock = FMXAML_TextAPI_SetFontFamily(_tempblock, FontFamily); // CALL THE TEXTAPI to set the font family.
            }

            if (FontStyle != null)
            {
                _tempblock = FMXAML_TextAPI_SetFontStyle(_tempblock, FontStyle);
            }

            if (FontSize != Double.NaN)
            {
                _tempblock = FMXAML_TextAPI_SetFontSize(_tempblock, FontSize);
            }

            if (FontWght != Int32.MaxValue)
            {
                _tempblock = FMXAML_TextAPI_SetFontWeight(_tempblock, FontWght);
            }

            FTextBox.Document.Blocks.Add(_tempblock);

            return FTextBox;
        }

        internal Inline FMXAML_TextAPI_AddText(Paragraph BlockToAdd, string Content, double FontSize = Double.NaN, string FontFamily = null, string FontStyle = null, int FontWght = Int32.MaxValue)
        {
            Inline _tempblock = new Run(Content);

            if (FontFamily != null)
            {
                _tempblock = FMXAML_TextAPI_SetFontFamily(_tempblock, FontFamily); // CALL THE TEXTAPI to set the font family.
            }

            if (FontStyle != null)
            {
                _tempblock = FMXAML_TextAPI_SetFontStyle(_tempblock, FontStyle);
            }

            if (FontSize != Double.NaN)
            {
                _tempblock = FMXAML_TextAPI_SetFontSize(_tempblock, FontSize);
            }

            if (FontWght != Int32.MaxValue)
            {
                _tempblock = FMXAML_TextAPI_SetFontWeight(_tempblock, FontWght);
            }

            return _tempblock;
        }

        internal Paragraph FMXAML_TextAPI_AddTextToParagraph(Paragraph BlockToAdd, Inline TextToAdd)
        {
            BlockToAdd.Inlines.Add(TextToAdd);

            return BlockToAdd;
        }

        /// <summary>
        /// Internal API for loading text. Adds text to a textbox.
        /// </summary>
        /// <param name="FRichTextBoxToAdd"></param>
        /// <param name="FParagraphToAdd"></param>
        /// <returns></returns>
        internal RichTextBox FMXAML_TextAPI_AddParagraphToTextBox(RichTextBox FRichTextBoxToAdd, Paragraph FParagraphToAdd)
        {
            FRichTextBoxToAdd.Document.Blocks.Add(FParagraphToAdd);
            return FRichTextBoxToAdd;
        }

        /// <summary>
        /// Internal API for loading text. Sets a text block's font family.
        /// </summary>
        /// <param name="FBlockToSet">The Block to set the fontfamily of.</param>
        /// <param name="FontFamily">The font family in string form to set the Block's font family to.</param>
        /// <returns>A Block with the font family set.</returns>
        internal Block FMXAML_TextAPI_SetFontFamily(Block FBlockToSet, string FontFamily) // Sets the font family.
        {
            FontFamilyConverter _FontFamilyConverter = new FontFamilyConverter();
            FontFamily _FinalFontFamily = (FontFamily)_FontFamilyConverter.ConvertFromString(FontFamily);
            FBlockToSet.FontFamily = _FinalFontFamily;
            return FBlockToSet;
        }

        /// <summary>
        /// Internal API for loading text. Sets a text block's font family. (INLINE OVERLOAD)
        /// </summary>
        /// <param name="FBlockToSet">The Block to set the fontfamily of.</param>
        /// <param name="FontFamily">The font family in string form to set the Block's font family to.</param>
        /// <returns>An Inline with the font family set.</returns>
        internal Inline FMXAML_TextAPI_SetFontFamily(Inline FBlockToSet, string FontFamily) // Sets the font family.
        {
            FontFamilyConverter _FontFamilyConverter = new FontFamilyConverter();
            FontFamily _FinalFontFamily = (FontFamily)_FontFamilyConverter.ConvertFromString(FontFamily);
            FBlockToSet.FontFamily = _FinalFontFamily;
            return FBlockToSet;
        }

        /// <summary>
        /// Internal API for loading text. Sets a text block's font style.
        /// </summary>
        /// <param name="FBlockToSet">The Block to set the font style of.</param>
        /// <param name="FontStyle">The font family in string form to set the Block's font style to.</param>
        /// <returns>A Block with the font style set.</returns>
        internal Block FMXAML_TextAPI_SetFontStyle(Block FBlockToSet, string FontStyle) // Sets the font style.
        {
            FontStyleConverter _FontStyleConverter = new FontStyleConverter();
            FontStyle _FinalFontStyle = (FontStyle)_FontStyleConverter.ConvertFromString(FontStyle);
            FBlockToSet.FontStyle = _FinalFontStyle;
            return FBlockToSet;
        }

        /// <summary>
        /// Internal API for loading text. Sets a text block's font style. (INLINE OVERLOAD)
        /// </summary>
        /// <param name="FBlockToSet">The Block to set the font style of.</param>
        /// <param name="FontStyle">The font family in string form to set the Block's font style to.</param>
        /// <returns>An Inline with the font style set.</returns>
        internal Inline FMXAML_TextAPI_SetFontStyle(Inline FBlockToSet, string FontStyle) // Sets the font style.
        {
            try
            {
                FontStyleConverter _FontStyleConverter = new FontStyleConverter();
                FontStyle _FinalFontStyle = (FontStyle)_FontStyleConverter.ConvertFromString(FontStyle);
                FBlockToSet.FontStyle = _FinalFontStyle;
                return FBlockToSet;
            }
            catch (FormatException err)
            {
                FError.ThrowError(15, "An invalid string was supplied.", FErrorSeverity.FatalError, err);
                return null; 
            }
        }

        /// <summary>
        /// Internal API for loading text. Sets a text block's font size.
        /// </summary>
        /// <param name="FBlockToSet">The Block to set the font size of.</param>
        /// <param name="FontSize">The font family in string form to set the Block's font size to.</param>
        /// <returns>A Block with the font size set.</returns>
        internal Block FMXAML_TextAPI_SetFontSize(Block FBlockToSet, double FontSize) // Sets the font size.
        {
            FBlockToSet.FontSize = FontSize;
            return FBlockToSet;
        }

        /// <summary>
        /// Internal API for loading text. Sets a text block's font size. (INLINE OVERLOAD)
        /// </summary>
        /// <param name="FBlockToSet">The Block to set the font size of.</param>
        /// <param name="FontSize">The font family in string form to set the Block's font size to.</param>
        /// <returns>An Inline with the font size set.</returns>
        internal Inline FMXAML_TextAPI_SetFontSize(Inline FBlockToSet, double FontSize) // Sets the font size.
        {
            FBlockToSet.FontSize = FontSize;
            return FBlockToSet;
        }

        /// <summary>
        /// Internal API for loading text. Sets a text block's font weight.
        /// </summary>
        /// <param name="FBlockToSet">The Block to set the font weight of.</param>
        /// <param name="FontWght">The font family in string form to set the Block's font weight to.</param>
        /// <returns>A Block with the font weight set.</returns>
        internal Block FMXAML_TextAPI_SetFontWeight(Block FBlockToSet, int FontWght) // Sets the font weight.
        {
            FBlockToSet.FontWeight = FontWeight.FromOpenTypeWeight(FontWght);
            return FBlockToSet;
        }

        /// <summary>
        /// Internal API for loading text. Sets a text block's font weight. (INLINE OVERLOAD)
        /// </summary>
        /// <param name="FBlockToSet">The Block to set the font weight of.</param>
        /// <param name="FontWght">The font family in string form to set the Block's font weight to.</param>
        /// <returns>A Block with the font weight set.</returns>
        internal Inline FMXAML_TextAPI_SetFontWeight(Inline FBlockToSet, int FontWght) // Sets the font weight.
        {

            if (FontWght < 1 | FontWght > 999)
            {
                FError.ThrowError(17, "The font weight must be between 1 and 999. The font weight has not been set.", FErrorSeverity.Warning);
                return FBlockToSet;
                
            } 

            FBlockToSet.FontWeight = FontWeight.FromOpenTypeWeight(FontWght);

            return FBlockToSet;
        }

        /// <summary>
        /// Internal API for loading text. Sets the foreground colour of text.
        /// </summary>
        /// <param name="FBlockToSet">The Inline to set the foreground colour of.</param>
        /// <param name="FontColour">The Inline to set the foreground colour of.</param>
        /// <returns>An Inline with the foreground colour set</returns>
        internal Inline FMXAML_TextAPI_SetFontFgColour(Inline FBlockToSet, Color FontColour)
        {
            FBlockToSet.Foreground = new SolidColorBrush(FontColour);
            return FBlockToSet;
        }

        /// <summary>
        /// Internal API for loading text. Sets the foreground colour of text.
        /// </summary>
        /// <param name="FBlockToSet">The Inline to set the background colour of.</param>
        /// <param name="FontColour">The Inline to set the background colour of.</param>
        /// <returns>An Inline with the background colour set</returns>
        internal Inline FMXAML_TextAPI_SetFontBgColour(Inline FBlockToSet, Color FontColour)
        {
            FBlockToSet.Background = new SolidColorBrush(FontColour);
            return FBlockToSet;
        }

        internal Block FMXAML_TextAPI_SetBlockPosition(Block FBlockToSet, Thickness FPosition)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets colour from a string. 
        /// </summary>
        /// <param name="Content">The string to determine an RGB(A) colour.</param>
        /// <returns>An RGBA colour.</returns>
        internal Color FMXAML_TextAPI_GetColourFromXMLValue(string Content)
        {
            byte[] FColours = Array.ConvertAll<string, byte>(Content.Split(','), Byte.Parse);


            if (FColours.Length < 3 | FColours.Length > 4)
            {
                FError.ThrowError(19, "Invalid colour supplied - not all or too many values present", FErrorSeverity.FatalError);
            }


            Color FForegroundColour = new Color { R = FColours[0], G = FColours[1], B = FColours[2] };

            if (FColours.Length > 3)
            {
                FForegroundColour.A = FColours[3];
            }
            else
            {
                FForegroundColour.A = 255; //otherwise stuff appears as invisible by default
            }

            return FForegroundColour; 
        }

        public FUXDoclink FMXAML_TextAPI_AddDoclink(Paragraph FParaToAdd, string FSetContent) // Adds a paragraph.
        {
            FUXDoclink FUXDoclink = new FUXDoclink();
            FUXDoclink.DocLinkContent = FSetContent;
            return FUXDoclink;
        }

        public Paragraph FMXAML_TextAPI_AddDoclinkToParagraph(Paragraph FParaToModify, FUXDoclink FDoclinkToAdd)
        {
            InlineUIContainer FInlineUIContainer = new InlineUIContainer();
            FDoclinkToAdd.Height = 35;
            FInlineUIContainer.Child = FDoclinkToAdd;
            FParaToModify.Inlines.Add(FInlineUIContainer);
            return FParaToModify;
        }

        //todo: more functions
    }
}
