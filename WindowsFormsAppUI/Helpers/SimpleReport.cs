using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;

namespace WindowsFormsAppUI.Helpers
{
    public class SimpleReport
    {
        private readonly Graphics graphics;
        private readonly int paperWidth;
        private readonly PrintType printType;
        public int PaperHeight;

        public SimpleReport(PrintPageEventArgs e, int paperWidth, PrintType printType)
        {
            this.paperWidth = paperWidth;
            this.printType = printType;

            graphics = e.Graphics;
            PaperHeight = 0;
        }

        private Font GetTextFont(bool bold = false, bool isTitle = false)
        {
            int fontSize = 8;

            if (printType == PrintType.MM80)
            {
                fontSize += 2;
            }

            if (isTitle)
            {
                fontSize += 2;
            }
         
            return (bold) ? new Font("Arial", fontSize, FontStyle.Bold) : new Font("Arial", fontSize);            
        }

        public void DrawText(string text, bool bold = false, StringAlignment alignment = StringAlignment.Near)
        {
            Font drawFont = GetTextFont(bold);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = alignment;

            RectangleF rectangle = new RectangleF(10, PaperHeight, paperWidth - 20, drawFont.GetHeight());

            graphics.DrawString(text, drawFont, drawBrush, rectangle, stringFormat);
            PaperHeight += (int)drawFont.GetHeight();
        }

        public void DrawText(string leftText, string rightText, bool bold = false)
        {
            Font drawFont = GetTextFont(bold);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            float rightWidth = graphics.MeasureString(rightText, drawFont).Width;

            float leftX = 10;
            float rightX = paperWidth - 10 - rightWidth;

            graphics.DrawString(leftText, drawFont, drawBrush, new PointF(leftX, PaperHeight));
            graphics.DrawString(rightText, drawFont, drawBrush, new PointF(rightX, PaperHeight));

            PaperHeight += (int)drawFont.GetHeight();
        }

        public void DrawTable(List<List<string>> tableData, List<string> columnHeaders)
        {
            Font headerFont = GetTextFont(true, true);
            Font dataFont = GetTextFont();
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            float columnWidth = (paperWidth - 20) / tableData[0].Count; 

            for (int i = 0; i < columnHeaders.Count; i++)
            {
                graphics.DrawString(columnHeaders[i], headerFont, drawBrush, 20 + i * columnWidth, PaperHeight);
            }

            PaperHeight += 15;

            DrawLine();

            foreach (var data in tableData)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    graphics.DrawString(data[i], dataFont, drawBrush, 20 + i * columnWidth, PaperHeight);
                }

                PaperHeight += 20;
            }
        }

        public void DrawEmptyLine(int height)
        {
            PaperHeight += height;
        }

        public void DrawLine()
        {
            DrawEmptyLine(10);
            Pen pen = new Pen(Color.Black, 1);
            graphics.DrawLine(pen, 10, PaperHeight, paperWidth - 10, PaperHeight);
            PaperHeight += 5;
            DrawEmptyLine(10);
        }

        public void DrawRectangle(int width, int height)
        {
            Pen pen = new Pen(Color.Black, 1);
            graphics.DrawRectangle(pen, 10, PaperHeight, width, height);
            PaperHeight += height + 5;
        }
    }
}