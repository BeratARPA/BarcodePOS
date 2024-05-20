using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
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
            buttonAddMoneySymbol.Text = GlobalVariables.CultureHelper.GetText("MoneySymbol");
            buttonAddLabel.Text = GlobalVariables.CultureHelper.GetText("Label");
            buttonAddImage.Text = GlobalVariables.CultureHelper.GetText("Image");
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
            if (selectedElement != null && e.Button == MouseButtons.Left)
            {
                int newLeft = selectedElement.Left + (e.X - offset.X);
                int newTop = selectedElement.Top + (e.Y - offset.Y);

                // Panel sınırlarını kontrol et
                if (newLeft >= 0 && newLeft + selectedElement.Width <= panelMain.Width)
                {
                    selectedElement.Left = newLeft;
                }
                if (newTop >= 0 && newTop + selectedElement.Height <= panelMain.Height)
                {
                    selectedElement.Top = newTop;
                }
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
                return;
            }

            Bitmap barcodeBitmap = BarcodeHelper.GenerateEAN13Barcode(barcodeText);

            string fileLocation = Path.Combine(FolderLocations.resourcesFolderPath, barcodeText + ".png");
            if (!File.Exists(fileLocation))
                barcodeBitmap.Save(fileLocation);

            PictureBox barcodePictureBox = new PictureBox
            {
                Image = barcodeBitmap,
                ImageLocation = fileLocation,
                Width = 100,
                Height = 50,
                AllowDrop = true,
            };

            barcodePictureBox.MouseDown += Element_MouseDown;
            barcodePictureBox.MouseMove += Element_MouseMove;
            barcodePictureBox.MouseUp += Element_MouseUp;
            barcodePictureBox.MouseClick += Element_MouseClick;

            barcodePictureBox.Location = new Point(10, 10);
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

        private void buttonAddMoneySymbol_Click(object sender, EventArgs e)
        {
            Label label = new Label
            {
                Text = GlobalVariables.CultureHelper.GetMoneySymbol(),
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

            label.Location = new Point(10, 10);
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

            label.Location = new Point(10, 10);
            panelMain.Controls.Add(label);
        }

        private void buttonAddImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileLocation = Path.Combine(FolderLocations.resourcesFolderPath, openFileDialog.SafeFileName);
                if (!File.Exists(fileLocation))
                    File.Copy(openFileDialog.FileName, fileLocation);

                PictureBox image = new PictureBox
                {
                    Image = Image.FromFile(fileLocation),
                    ImageLocation = fileLocation,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Width = 100,
                    Height = 100,
                    AllowDrop = true,
                };

                image.MouseDown += Element_MouseDown;
                image.MouseMove += Element_MouseMove;
                image.MouseUp += Element_MouseUp;
                image.MouseClick += Element_MouseClick;

                image.Location = new Point(10, 10);
                panelMain.Controls.Add(image);
            }
        }

        private void buttonAddLocalProductionSymbol_Click(object sender, EventArgs e)
        {
            string fileLocation = Path.Combine(FolderLocations.resourcesFolderPath, "YerliUretim.jpg");

            PictureBox pictureBox = new PictureBox
            {
                Image = Image.FromFile(fileLocation),
                ImageLocation = fileLocation,
                Width = 100,
                Height = 50,
                SizeMode = PictureBoxSizeMode.StretchImage,
                AllowDrop = true,
            };

            pictureBox.MouseDown += Element_MouseDown;
            pictureBox.MouseMove += Element_MouseMove;
            pictureBox.MouseUp += Element_MouseUp;
            pictureBox.MouseClick += Element_MouseClick;

            pictureBox.Location = new Point(10, 10);
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
            saveFileDialog.Filter = "TXT files (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                {
                    foreach (Control control in panelMain.Controls)
                    {
                        string type = control.GetType().Name;
                        string location = $"{control.Location.X},{control.Location.Y}";
                        string widthHeight = $"{control.Width},{control.Height}";
                        string font = $"{control.Font.Name},{control.Font.Size},{(int)control.Font.Style}";

                        if (control is Label lbl)
                        {
                            sw.WriteLine($"{type},{location},{lbl.Text},{font},{lbl.ForeColor.ToArgb()}");
                        }
                        else if (control is PictureBox pb)
                        {
                            sw.WriteLine($"{type},{location},{pb.ImageLocation},{widthHeight}");
                        }
                    }
                }
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "TXT files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                panelMain.Controls.Clear();

                using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        var parts = line.Split(',');

                        if (parts[0] == "Label")
                        {
                            Label lbl = new Label
                            {
                                Location = new Point(int.Parse(parts[1]), int.Parse(parts[2])),
                                Text = parts[3],
                                Font = new Font(parts[4], float.Parse(parts[5]), (FontStyle)int.Parse(parts[6])),
                                ForeColor = Color.FromArgb(int.Parse(parts[7])),
                                TextAlign = ContentAlignment.MiddleCenter,
                                AllowDrop = true,
                                AutoSize = true
                            };

                            lbl.MouseDown += Element_MouseDown;
                            lbl.MouseMove += Element_MouseMove;
                            lbl.MouseUp += Element_MouseUp;
                            lbl.MouseClick += Element_MouseClick;

                            panelMain.Controls.Add(lbl);
                        }
                        else if (parts[0] == "PictureBox")
                        {
                            Image image = File.Exists(parts[3]) ? Image.FromFile(parts[3]) : null;

                            PictureBox pb = new PictureBox
                            {
                                Location = new Point(int.Parse(parts[1]), int.Parse(parts[2])),
                                Image = image,
                                ImageLocation = parts[3],
                                Width = int.Parse(parts[4]),
                                Height = int.Parse(parts[5]),
                                SizeMode = PictureBoxSizeMode.StretchImage,
                                AllowDrop = true
                            };

                            pb.MouseDown += Element_MouseDown;
                            pb.MouseMove += Element_MouseMove;
                            pb.MouseUp += Element_MouseUp;
                            pb.MouseClick += Element_MouseClick;

                            panelMain.Controls.Add(pb);
                        }
                    }
                }
            }
        }
    }
}
