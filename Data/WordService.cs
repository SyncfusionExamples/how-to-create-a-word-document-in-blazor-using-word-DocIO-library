using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;

namespace DocIOBlazor.Data
{
    public class WordService
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public WordService(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public MemoryStream CreateWord()
        {
            WordDocument document = new WordDocument();
            WSection section = document.AddSection() as WSection;
            section.PageSetup.Margins.All = 72;
            section.PageSetup.PageSize = new Syncfusion.Drawing.SizeF(612, 792);

            WParagraphStyle style = document.AddParagraphStyle("Normal") as WParagraphStyle;
            style.CharacterFormat.FontName = "Calibri";
            style.CharacterFormat.FontSize = 11f;
            style.ParagraphFormat.BeforeSpacing = 0;
            style.ParagraphFormat.AfterSpacing = 8;
            style.ParagraphFormat.LineSpacing = 13.8f;


            style = document.AddParagraphStyle("Heading 1") as WParagraphStyle;
            style.ApplyBaseStyle("Normal");
            style.CharacterFormat.FontName = "Calibri Light";
            style.CharacterFormat.FontSize = 16f;
            style.CharacterFormat.TextColor = Syncfusion.Drawing.Color.FromArgb(46, 116, 181);
            style.ParagraphFormat.BeforeSpacing = 12;
            style.ParagraphFormat.AfterSpacing = 0;

            IWParagraph paragraph = section.HeadersFooters.Header.AddParagraph();
            paragraph.ApplyStyle("Normal");
            paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Left;

            string basePath = _hostingEnvironment.WebRootPath + @"/images/word/";
            FileStream imageStream = new FileStream(basePath + @"adventurecycle.jpg", FileMode.Open, FileAccess.Read);
            WPicture picture = paragraph.AppendPicture(imageStream) as WPicture;
            picture.TextWrappingStyle = TextWrappingStyle.InFrontOfText;
            picture.VerticalOrigin = VerticalOrigin.Margin;
            picture.VerticalPosition = -45;
            picture.HorizontalOrigin = HorizontalOrigin.Column;
            picture.HorizontalPosition = 263.5f;
            picture.WidthScale = 20;
            picture.HeightScale = 15;

            WTextRange textRange = paragraph.AppendText("Adventure Work cycles") as WTextRange;
            textRange.CharacterFormat.FontName = "Calibri";
            textRange.CharacterFormat.FontSize = 12f;
            textRange.CharacterFormat.TextColor = Syncfusion.Drawing.Color.Red;

            paragraph = section.AddParagraph();
            paragraph.ApplyStyle("Heading 1");
            paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
            textRange = paragraph.AppendText("Adventure Work cycles") as WTextRange;
            textRange.CharacterFormat.FontName = "Calibri";
            textRange.CharacterFormat.FontSize = 18f;

            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.FirstLineIndent = 36;
            paragraph.BreakCharacterFormat.FontSize = 12f;
            textRange = paragraph.AppendText("Adventure Works Cycles, the fictitious company on which the AdventureWorks sample databases are based, is a large, multinational manufacturing company. The company manufactures and sells metal and composite bicycles to North American, European and Asian commercial markets. While its base operation is in Bothell, Washington with 290 employees, several regional sales teams are located throughout their market base.") as WTextRange;
            textRange.CharacterFormat.FontSize = 12f;

            paragraph = section.AddParagraph();
            paragraph.ApplyStyle("Heading 1");
            paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Left;
            textRange = paragraph.AppendText("Product Overview") as WTextRange;
            textRange.CharacterFormat.FontName = "Calibri";
            textRange.CharacterFormat.FontSize = 18f;

            IWTable table = section.AddTable();
            table.ResetCells(2, 2);
            table.TableFormat.Borders.BorderType = BorderStyle.None;
            table.TableFormat.IsAutoResized = true;

            paragraph = table[0, 0].AddParagraph();
            paragraph.ParagraphFormat.AfterSpacing = 0;
            paragraph.BreakCharacterFormat.FontSize = 12f; 

            imageStream = new FileStream(basePath + @"mountain-200.jpg", FileMode.Open, FileAccess.Read);
            picture = paragraph.AppendPicture(imageStream) as WPicture;
            picture.TextWrappingStyle = TextWrappingStyle.TopAndBottom;
            picture.VerticalOrigin = VerticalOrigin.Paragraph;
            picture.VerticalPosition = 4.5f;
            picture.HorizontalOrigin = HorizontalOrigin.Column;
            picture.HorizontalPosition = -2.15f;
            picture.WidthScale = 79;
            picture.HeightScale = 79;

            paragraph = table[0, 1].AddParagraph();
            paragraph.ApplyStyle("Heading 1");
            paragraph.ParagraphFormat.AfterSpacing = 0;
            paragraph.ParagraphFormat.LineSpacing = 12f;
            paragraph.AppendText("Mountain-200");

            paragraph = table[0, 1].AddParagraph();
            paragraph.ParagraphFormat.AfterSpacing = 0;
            paragraph.ParagraphFormat.LineSpacing = 12f;
            paragraph.BreakCharacterFormat.FontSize = 12f;
            paragraph.BreakCharacterFormat.FontName = "Times New Roman";
            textRange = paragraph.AppendText("Product No: BK-M68B-38\rSize: 38\rWeight: 25\rPrice: $2,294.99\r") as WTextRange;
            textRange.CharacterFormat.FontSize = 12f;
            textRange.CharacterFormat.FontName = "Times New Roman";
            paragraph = table[0, 1].AddParagraph();
            paragraph.ParagraphFormat.AfterSpacing = 0;
            paragraph.ParagraphFormat.LineSpacing = 12f;
            paragraph.BreakCharacterFormat.FontSize = 12f;

            paragraph = table[1, 0].AddParagraph();
            paragraph.ApplyStyle("Heading 1");
            paragraph.ParagraphFormat.AfterSpacing = 0;
            paragraph.ParagraphFormat.LineSpacing = 12f;
            paragraph.AppendText("Mountain-300");

            paragraph = table[1,0].AddParagraph();
            paragraph.ParagraphFormat.AfterSpacing = 0;
            paragraph.ParagraphFormat.LineSpacing = 12f;
            paragraph.BreakCharacterFormat.FontSize = 12f;
            paragraph.BreakCharacterFormat.FontName = "Times New Roman";
            textRange = paragraph.AppendText("Product No: BK-M47B-38\rSize: 35\rWeight: 22\rPrice: $1,079.99\r") as WTextRange;
            textRange.CharacterFormat.FontSize = 12f;
            textRange.CharacterFormat.FontName = "Times New Roman";
            paragraph = table[1,0].AddParagraph();
            paragraph.ParagraphFormat.AfterSpacing = 0;
            paragraph.ParagraphFormat.LineSpacing = 12f;
            paragraph.BreakCharacterFormat.FontSize = 12f;

            paragraph = table[1,1].AddParagraph();
            paragraph.ParagraphFormat.AfterSpacing = 0;
            paragraph.BreakCharacterFormat.FontSize = 12f;

            imageStream = new FileStream(basePath + @"mountain-300.jpg", FileMode.Open, FileAccess.Read);
            picture = paragraph.AppendPicture(imageStream) as WPicture;
            picture.TextWrappingStyle = TextWrappingStyle.TopAndBottom;
            picture.VerticalOrigin = VerticalOrigin.Paragraph;
            picture.VerticalPosition = 8.2f;
            picture.HorizontalOrigin = HorizontalOrigin.Column;
            picture.HorizontalPosition = -14.95f;
            picture.WidthScale = 75;
            picture.HeightScale = 75;

            MemoryStream stream = new MemoryStream();
            document.Save(stream, FormatType.Docx);
            document.Close();
            stream.Position = 0;

            return stream;

        }
    }
}
