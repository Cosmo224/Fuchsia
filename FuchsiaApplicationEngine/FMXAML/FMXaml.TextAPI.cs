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

        internal Paragraph FMXAML_TextAPI_AddText(Paragraph BlockToAdd, string Content, double FontSize = Double.NaN, string FontFamily = null, string FontStyle = null, int FontWght = Int32.MaxValue)
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

            BlockToAdd.Inlines.Add(_tempblock);

            return BlockToAdd;
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
            FontStyleConverter _FontStyleConverter = new FontStyleConverter();
            FontStyle _FinalFontStyle = (FontStyle)_FontStyleConverter.ConvertFromString(FontStyle);
            FBlockToSet.FontStyle = _FinalFontStyle;
            return FBlockToSet;
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

        internal Inline FMXAML_TextAPI_SetFontWeight(Inline FBlockToSet, int FontWght) // Sets the font weight.
        {
            FBlockToSet.FontWeight = FontWeight.FromOpenTypeWeight(FontWght);
            return FBlockToSet;
        }

        internal Block FMXAML_TextAPI_SetFontFgColour(Block FBlockToSet, Color FontColour)
        {
            throw new NotImplementedException();
        }

        internal Block FMXAML_TextAPI_SetFontBgColour(Block FBlockToSet, Color FontColour)
        {
            throw new NotImplementedException();
        }

        internal Block FMXAML_TextAPI_SetBlockPosition(Block FBlockToSet, Color FontColour)
        {
            throw new NotImplementedException();
        }
        //todo: more functions
    }
}
