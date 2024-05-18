using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Xml;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.Forms
{
    public partial class ProductLabelDesignForm : Form
    {
        private PrintDocument printDocument;
        PrintPreviewDialog printPreviewDialog;
        private Control selectedElement = null;
        private double rotationAngle = 0.0;
        private Point offset;
        private int totalPages = 24;
        private int currentPage = 1;

        public ProductLabelDesignForm()
        {
            InitializeComponent();
            UpdateUILanguage();

            printDocument = new PrintDocument();
            printPreviewDialog = new PrintPreviewDialog();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
        }

        private void ProductLabelDesignForm_Load(object sender, EventArgs e)
        {
            double canvasWidthMm = 100;
            double canvasHeightMm = 38;

            tableLayoutPanelMain.RowStyles[1].Height = UnitConvert.MmToPixel(canvasHeightMm);
            tableLayoutPanelMain.ColumnStyles[1].Width = UnitConvert.MmToPixel(canvasWidthMm);

            PaperSize paperSize = new PaperSize("Ürün Raf Etiketi", UnitConvert.MmToPixel(100), UnitConvert.MmToPixel(38));
            printDocument.DefaultPageSettings.PaperSize = paperSize;

            PrintController printController = new StandardPrintController();
            printDocument.PrintController = printController;
        }

        public void UpdateUILanguage()
        {
            label1.Text = GlobalVariables.CultureHelper.GetText("Barcode");
            buttonCreateBarcode.Text = GlobalVariables.CultureHelper.GetText("CreateBarcode");
            buttonAddTLSymbol.Text = GlobalVariables.CultureHelper.GetText("MoneySymbol");
            buttonAddLabel.Text = GlobalVariables.CultureHelper.GetText("Label");
            buttonAddImage.Text = GlobalVariables.CultureHelper.GetText("Image");
            buttonAddRectangle.Text = GlobalVariables.CultureHelper.GetText("Rectangle");
            buttonAddLocalProductionSymbol.Text = GlobalVariables.CultureHelper.GetText("DomesticProduction");
            buttonPrint.Text = GlobalVariables.CultureHelper.GetText("Print");
            buttonSave.Text = GlobalVariables.CultureHelper.GetText("Save");
            buttonLoad.Text = GlobalVariables.CultureHelper.GetText("Load");
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (currentPage <= totalPages)
            {
                // Panel içeriğini çizdirin
                Bitmap panelImage = new Bitmap(panelMain.Width, panelMain.Height);
                panelMain.DrawToBitmap(panelImage, new Rectangle(0, 0, panelMain.Width, panelMain.Height));
                e.Graphics.DrawImage(panelImage, new Point(0, 0)); // Yazdırma pozisyonu
            }

            if (currentPage <= totalPages)
            {
                e.HasMorePages = true;
                currentPage++;
            }
            else
            {
                e.HasMorePages = false;
                currentPage = 1; // Sayfa sayacını sıfırla
            }
        }

        private void Element_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                selectedElement = (Control)sender;
                ContextMenuStrip contextMenu = CreateContextMenu(selectedElement);
                contextMenu.Show(panelMain, selectedElement.Location);
            }
        }

        private void Element_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                selectedElement = (Control)sender;
                offset = e.Location;
            }
        }

        private void Element_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                selectedElement.Left = e.X + selectedElement.Left - offset.X;
                selectedElement.Top = e.Y + selectedElement.Top - offset.Y;
            }
        }

        private void Element_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                selectedElement.Capture = false;
                selectedElement = null;
            }
        }

        private void buttonCreateBarcode_Click(object sender, EventArgs e)
        {
            string barcodeText = textBoxBarcode.Text.Trim();
            if (string.IsNullOrEmpty(barcodeText))
            {
                MessageBox.Show("Barkod numarası giriniz.");
                return;
            }

            Bitmap barcodeBitmap = BarcodeHelper.GenerateEAN13Barcode(barcodeText);
            PictureBox barcodePictureBox = new PictureBox
            {
                Image = barcodeBitmap,
                Width = 100,
                Height = 100,
                AllowDrop = true,
            };

            barcodePictureBox.MouseDown += Element_MouseDown;
            barcodePictureBox.MouseMove += Element_MouseMove;
            barcodePictureBox.MouseUp += Element_MouseUp;
            barcodePictureBox.MouseClick += Element_MouseClick;

            barcodePictureBox.Location = new Point(50, 50);
            panelMain.Controls.Add(barcodePictureBox);
        }

        private ContextMenuStrip CreateContextMenu(object sender)
        {
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            ToolStripMenuItem removeMenuItem = new ToolStripMenuItem
            {
                Text = GlobalVariables.CultureHelper.GetText("Delete")
            };
            removeMenuItem.Click += MenuItemRemove_Click;
            contextMenu.Items.Add(removeMenuItem);

            ToolStripMenuItem editMenuItem = new ToolStripMenuItem
            {
                Text = GlobalVariables.CultureHelper.GetText("Edit")
            };
            editMenuItem.Click += MenuItemEdit_Click;
            contextMenu.Items.Add(editMenuItem);

            if (sender is PictureBox)
            {
                contextMenu.Items.Remove(editMenuItem);
            }

            return contextMenu;
        }

        private void MenuItemEdit_Click(object sender, EventArgs e)
        {
            if (selectedElement is Label label)
            {
                LabelPropertyForm labelPropertyForm = new LabelPropertyForm(label);
                labelPropertyForm.ShowDialog();
            }

            selectedElement = null;
        }

        private void MenuItemRemove_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Remove(selectedElement);
            selectedElement = null;
        }

        private void buttonAddTLSymbol_Click(object sender, EventArgs e)
        {
            Label label = new Label
            {
                Text = "₺",
                BackColor = Color.Transparent,
                Font = new Font("Arial", 50, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true,
                AllowDrop = true,
            };

            label.MouseDown += Element_MouseDown;
            label.MouseMove += Element_MouseMove;
            label.MouseUp += Element_MouseUp;
            label.MouseClick += Element_MouseClick;

            label.Location = new Point(50, 50);
            panelMain.Controls.Add(label);
        }

        private void buttonAddLabel_Click(object sender, EventArgs e)
        {
            Label label = new Label
            {
                Text = "Etiket",
                BackColor = Color.Transparent,
                Font = new Font("Arial", 10, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true,
                AllowDrop = true,
            };

            label.MouseDown += Element_MouseDown;
            label.MouseMove += Element_MouseMove;
            label.MouseUp += Element_MouseUp;
            label.MouseClick += Element_MouseClick;

            label.Location = new Point(50, 50);
            panelMain.Controls.Add(label);
        }

        private void buttonAddImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                PictureBox image = new PictureBox
                {
                    Image = Image.FromFile(openFileDialog.FileName),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Width = 100,
                    Height = 100,
                    AllowDrop = true,
                };

                image.MouseDown += Element_MouseDown;
                image.MouseMove += Element_MouseMove;
                image.MouseUp += Element_MouseUp;
                image.MouseClick += Element_MouseClick;

                image.Location = new Point(50, 50);
                panelMain.Controls.Add(image);
            }
        }

        private void buttonAddRectangle_Click(object sender, EventArgs e)
        {
            PictureBox rectangle = new PictureBox
            {
                Width = 100,
                Height = 50,
                BackColor = Color.LightBlue,
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.StretchImage,
                AllowDrop = true,
            };

            rectangle.MouseDown += Element_MouseDown;
            rectangle.MouseMove += Element_MouseMove;
            rectangle.MouseUp += Element_MouseUp;
            rectangle.MouseClick += Element_MouseClick;

            rectangle.Location = new Point(50, 50);
            panelMain.Controls.Add(rectangle);
        }

        private void buttonAddLocalProductionSymbol_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = new PictureBox
            {
                Image = Properties.Resources.YerliUretim,
                Width = 100,
                Height = 50,
                SizeMode = PictureBoxSizeMode.StretchImage,
                AllowDrop = true,
            };

            pictureBox.MouseDown += Element_MouseDown;
            pictureBox.MouseMove += Element_MouseMove;
            pictureBox.MouseUp += Element_MouseUp;
            pictureBox.MouseClick += Element_MouseClick;

            pictureBox.Location = new Point(50, 50);
            panelMain.Controls.Add(pictureBox);
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            // printDocument.Print();
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.ShowDialog();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XAML files (*.xaml)|*.xaml";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                {
                    // panelMain içeriğini XAML dosyasına kaydet
                    string xamlContent = XamlWriter.Save(panelMain);
                    sw.Write(xamlContent);
                }
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XAML files (*.xaml)|*.xaml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                {
                    // XAMLReader'ı kullanarak XAML dosyasından Panel içeriğini yükleyin
                    string xamlContent = sr.ReadToEnd();
                    StringReader stringReader = new StringReader(xamlContent);
                    XmlReader xmlReader = XmlReader.Create(stringReader);
                    Panel loadedPanel = null;
                    try
                    {
                        loadedPanel = (Panel)XamlReader.Load(xmlReader);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("XAML dosyası yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // panelMain içeriğini temizleyin
                    panelMain.Controls.Clear();

                    // XAML dosyasından Panel içeriğini kopyalayıp PanelMain'e ekleyin
                    Control[] controlsArray = new Control[loadedPanel.Controls.Count];
                    loadedPanel.Controls.CopyTo(controlsArray, 0);
                    panelMain.Controls.AddRange(controlsArray);                    
                }
            }
        }
    }
}
