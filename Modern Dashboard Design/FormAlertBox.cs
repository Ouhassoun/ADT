using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modern_Dashboard_Design
{
    public partial class FormAlertBox : Form
    {
        public FormAlertBox()
        {
            InitializeComponent();
        }
        public Color BackColorAlertBox
        {
            get { return this.BackColor; }
            set { this.BackColor = value; }
        }
        public Color ColorAlertBox
        {
            get { return this.LinAlertBox.BackColor; }
            set { this.LinAlertBox.BackColor = lblTitleAlertBox.ForeColor = lblTextAlertBox.ForeColor = value; }
        }
        public Image IconAlertBox
        {
            get { return PicAlertBox.Image; }
            set { PicAlertBox.Image = value; }
        }
        public string TitleAlertBox
        {
            get { return lblTitleAlertBox.Text; }
            set { lblTitleAlertBox.Text = value; }
        }
        public string TextAlertBox
        {
            get { return lblTextAlertBox.Text; }
            set { lblTextAlertBox.Text = value; }
        }
        private void PositionAlertBox()
        {
            int xPos = 0;
            int yPos = 0;
            xPos = Screen.GetWorkingArea(this).Width;
            yPos = Screen.GetWorkingArea(this).Height;
            this.Location = new Point(xPos - this.Width, yPos - this.Height);
        }
        private void TimerAnimation_Tick(object sender, EventArgs e)
        {
            LinAlertBox.Width = LinAlertBox.Width + 2;
            if (LinAlertBox.Width == 500)
            {
                this.Close();
            }
        }

        private void FormAlertBox_Load(object sender, EventArgs e)
        {
            PositionAlertBox();
            for (int i = 0; i < 500; i++)
            {
                TimerAnimation.Start();
            }
        }
    }
}
