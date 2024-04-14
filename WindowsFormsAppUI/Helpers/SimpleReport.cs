using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace WindowsFormsAppUI.Helpers
{
    public class SimpleReport
    {
        private readonly GridLengthConverter _gridLengthConverter = new GridLengthConverter();

        public FlowDocument Document { get; set; }
        public Paragraph Header { get; set; }
        public IDictionary<string, Paragraph> Paragraphs { get; set; }
        public IDictionary<string, Table> Tables { get; set; }
        public IDictionary<string, GridLength[]> ColumnLengths { get; set; }
        public IDictionary<string, TextAlignment[]> ColumnTextAlignments { get; set; }

        public SimpleReport()
        {
            Paragraphs = new Dictionary<string, Paragraph>();
            Tables = new Dictionary<string, Table>();
            ColumnLengths = new Dictionary<string, GridLength[]>();
            ColumnTextAlignments = new Dictionary<string, TextAlignment[]>();
            Header = new Paragraph { TextAlignment = TextAlignment.Center, FontSize = 10 };
            Document = new FlowDocument(Header);
        }

        public void AddColumnLength(string tableName, params string[] values)
        {
            if (!ColumnLengths.ContainsKey(tableName))
            {
                ColumnLengths.Add(tableName, new GridLength[0]);
            }

            ColumnLengths[tableName] = values.Select(StringToGridLength).ToArray();
        }

        public void AddColumTextAlignment(string tableName, params TextAlignment[] values)
        {
            if (!ColumnTextAlignments.ContainsKey(tableName))
            {
                ColumnTextAlignments.Add(tableName, new TextAlignment[0]);
            }

            ColumnTextAlignments[tableName] = values;
        }

        public void AddTable(string tableName, params string[] headers)
        {
            var table = new Table();

            Document.Blocks.Add(table);
            Tables.Add(tableName, table);

            var lengths = ColumnLengths.ContainsKey(tableName) ? ColumnLengths[tableName] : new[] { GridLength.Auto, GridLength.Auto, new GridLength(1, GridUnitType.Star) };

            for (var i = 0; i < headers.Count(); i++)
            {
                var c = new TableColumn
                {
                    Width = lengths[i],
                };

                table.Columns.Add(c);
            }

            var rows = new TableRowGroup();
            table.RowGroups.Add(rows);
            rows.Rows.Add(CreateRow(headers, ColumnTextAlignments.ContainsKey(tableName) ? ColumnTextAlignments[tableName] : new[] { TextAlignment.Left }, true, true));
        }

        public void AddHeader(string text)
        {
            AddNewLine(Header, text, true);
        }

        public void AddParagraph(string paragraphName)
        {
            var p = new Paragraph { TextAlignment = TextAlignment.Left, FontSize = 10 };
            Document.Blocks.Add(p);
            Paragraphs.Add(paragraphName, p);
        }

        public void AddParagraphLine(string paragraphName, string line)
        {
            AddParagraphLine(paragraphName, line, false);
        }

        public void AddParagraphLine(string paragraphName, string line, bool bold)
        {
            Paragraphs[paragraphName].Inlines.Add(new Run(line) { FontWeight = bold ? FontWeights.Bold : FontWeights.Normal });
            Paragraphs[paragraphName].Inlines.Add(new LineBreak());
        }

        public void AddRow(string tableName, params string[] values)
        {
            Tables[tableName].RowGroups[0].Rows.Add(CreateRow(values, ColumnTextAlignments.ContainsKey(tableName) ? ColumnTextAlignments[tableName] : new[] { TextAlignment.Left }, false, false));
        }

        public void AddBoldRow(string tableName, params string[] values)
        {
            Tables[tableName].RowGroups[0].Rows.Add(CreateRow(values, ColumnTextAlignments.ContainsKey(tableName) ? ColumnTextAlignments[tableName] : new[] { TextAlignment.Left }, true, false));
        }

        public void AddFooter(string footerName, string line, bool bold)
        {
            var p = new Paragraph { TextAlignment = TextAlignment.Center, FontSize = 10 };
            Document.Blocks.Add(p);
            Paragraphs.Add(footerName, p);

            AddFooterLine(footerName, line, bold);
        }

        public void AddText(string tableName, string leftText, string rightText)
        {
            Tables[tableName].RowGroups[0].Rows.Add(CreateRow(new string[] { leftText, rightText }, new TextAlignment[] { TextAlignment.Left, TextAlignment.Right }, false, false));
        }

        public void AddFooterLine(string footerName, string line, bool bold)
        {
            Paragraphs[footerName].Inlines.Add(new Run(line) { FontWeight = bold ? FontWeights.Bold : FontWeights.Normal });
            Paragraphs[footerName].Inlines.Add(new LineBreak());
        }

        public void AddLine(string name)
        {
            var p = new Paragraph { TextAlignment = TextAlignment.Center, FontSize = 1, BorderBrush = Brushes.Black, BorderThickness = new Thickness(0, 0, 0, 2) };
            Document.Blocks.Add(p);
            Paragraphs.Add(name, p);
        }

        private static void AddNewLine(Paragraph p, string text, bool bold)
        {
            p.Inlines.Add(new Run(text) { FontWeight = bold ? FontWeights.Bold : FontWeights.Normal });
            p.Inlines.Add(new LineBreak());
        }

        public TableRow CreateRow(string[] values, TextAlignment[] alignment, bool bold, bool isTable)
        {
            var row = new TableRow();
            TableCell lastCell = null;
            int index = 0;
            foreach (var value in values)
            {
                var val = value ?? "";
                var r = new Run(val) { FontWeight = bold ? FontWeights.Bold : FontWeights.Normal };

                if (string.IsNullOrEmpty(val) && lastCell != null)
                {
                    lastCell.ColumnSpan++;
                }
                else
                {
                    var p = new Paragraph(r);
                    p.FontSize = 10;
                    p.TextAlignment = alignment.Length <= index ? alignment[alignment.Length - 1] : alignment[index];
                    if (!isTable)
                    {
                        lastCell = new TableCell(p)
                        {
                            BorderBrush = Brushes.Black,
                        };
                    }
                    else
                    {
                        lastCell = new TableCell(p)
                        {
                            BorderBrush = Brushes.Black,
                            BorderThickness = new Thickness(0, 0, 0, 2)
                        };
                    }

                    row.Cells.Add(lastCell);
                }

                index++;
            }

            return row;
        }

        private GridLength StringToGridLength(string value)
        {
            return (GridLength)_gridLengthConverter.ConvertFromString(value);
        }

        public double GetDocumentHeight()
        {
            double totalHeight = 0;

            foreach (var block in Document.Blocks)
            {
                if (block is Paragraph paragraph)
                {
                    totalHeight += MeasureParagraphHeight(paragraph);
                }
                else if (block is Table table)
                {
                    totalHeight += MeasureTableHeight(table);
                }
            }

            return totalHeight + 50;
        }

        private double MeasureParagraphHeight(Paragraph paragraph)
        {
            var textBlock = new TextBlock(new Run(new TextRange(paragraph.ContentStart, paragraph.ContentEnd).Text));
            textBlock.TextWrapping = TextWrapping.Wrap;
            textBlock.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            return textBlock.DesiredSize.Height;
        }

        private double MeasureTableHeight(Table table)
        {
            double height = 0;

            foreach (var row in table.RowGroups[0].Rows)
            {
                height += MeasureTableRowHeight(row);
            }

            return height;
        }

        private double MeasureTableRowHeight(TableRow row)
        {
            double maxHeight = 0;

            foreach (var cell in row.Cells)
            {
                if (cell.Blocks.Count > 0)
                {
                    foreach (var block in cell.Blocks)
                    {
                        if (block is Paragraph paragraph)
                        {
                            double paragraphHeight = MeasureParagraphHeight(paragraph);
                            if (paragraphHeight > maxHeight)
                            {
                                maxHeight = paragraphHeight;
                            }
                        }
                    }
                }
            }

            return maxHeight;
        }
    }
}