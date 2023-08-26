using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.Forms
{
    public enum MessageButton
    {
        YesNo,
        OKCancel,
        OK
    }

    public enum MessageIcon
    {
        Information,
        Warning,
        Error
    }

    public partial class MessageBoxForm : Form
    {
        public MessageBoxForm()
        {
            InitializeComponent();
        }

        public MessageButton Button;
        SoundPlayer simpleSound = new SoundPlayer(Application.StartupPath + "\\Data\\Sounds\\MessageBoxSound.wav");

        public DialogResult ShowMessage(string description, string title, MessageButton button, MessageIcon icon)
        {
            //simpleSound.Play();

            button1.Visible = true;
            button2.Focus();

            this.labelDescription.Text = description;
            this.labelTitle.Text = title;

            switch (button)
            {
                case MessageButton.YesNo:
                    this.button1.Text = GlobalVariables.CultureHelper.GetText("Yes");
                    this.button2.Text = GlobalVariables.CultureHelper.GetText("No");
                    Button = MessageButton.YesNo;
                    break;
                case MessageButton.OKCancel:
                    this.button1.Text = GlobalVariables.CultureHelper.GetText("Ok");
                    this.button2.Text = GlobalVariables.CultureHelper.GetText("Cancel");
                    Button = MessageButton.OKCancel;
                    break;
                case MessageButton.OK:
                    this.button1.Visible = false;
                    this.button2.Text = GlobalVariables.CultureHelper.GetText("Ok");
                    Button = MessageButton.OK;
                    break;
                default:
                    break;
            }

            switch (icon)
            {
                case MessageIcon.Information:
                    var InformationImage = new Bitmap(Properties.Resources.Information);
                    this.pictureBoxLogo.Image = InformationImage;
                    break;
                case MessageIcon.Warning:
                    var WarningImage = new Bitmap(Properties.Resources.Warning);
                    this.pictureBoxLogo.Image = WarningImage;
                    break;
                case MessageIcon.Error:
                    var ErrorImage = new Bitmap(Properties.Resources.Error);
                    this.pictureBoxLogo.Image = ErrorImage;
                    break;
                default:
                    break;
            }

            this.TopMost = true;
            this.ShowDialog();

            return this.DialogResult;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Button == MessageButton.YesNo)
            {
                this.DialogResult = DialogResult.Yes;
            }
            else if (Button == MessageButton.OKCancel)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Button == MessageButton.YesNo)
            {
                this.DialogResult = DialogResult.No;
            }
            else if (Button == MessageButton.OK)
            {
                this.DialogResult = DialogResult.OK;
            }
            else if (Button == MessageButton.OKCancel)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}