using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Modern_Dashboard_Design
{
    public partial class MainForm : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
     (
          int nLeftRect,
          int nTopRect,
          int nRightRect,
          int nBottomRect,
          int nWidthEllipse,
         int nHeightEllipse

      );

        public MainForm()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BtnDashboard_Click(null, null);
        }

        private void FlowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            
            pnlNav.Height = btnDashboard.Height;
            pnlNav.Top = btnDashboard.Top;
            pnlNav.Left = btnDashboard.Left;
            btnDashboard.BackColor = Color.FromArgb(46, 51, 73);
            btnWorkCertAR.BackColor = Color.FromArgb(24, 30, 54);
            btnWorkCertFR.BackColor = Color.FromArgb(24, 30, 54);
            btnSettings.BackColor = Color.FromArgb(24, 30, 54);
            lblTitle.Text = "Dashboard";
            this.PnlFormLoader.Controls.Clear();
            DashboardForm FrmDashboard_Vrb = new DashboardForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
            

        }

        private void BtnWorkCertAR_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnWorkCertAR.Height;
            pnlNav.Top = btnWorkCertAR.Top;
            btnWorkCertAR.BackColor = Color.FromArgb(46, 51, 73);
            btnDashboard.BackColor = Color.FromArgb(24, 30, 54);
            btnWorkCertFR.BackColor = Color.FromArgb(24, 30, 54);
            btnSettings.BackColor = Color.FromArgb(24, 30, 54);

            lblTitle.Text = "Work Certificate AR";
            this.PnlFormLoader.Controls.Clear();
            FormADTarabic FrmDashboard_Vrb = new FormADTarabic() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void BtnWorkCertFR_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnWorkCertFR.Height;
            pnlNav.Top = btnWorkCertFR.Top;
            btnWorkCertFR.BackColor = Color.FromArgb(46, 51, 73);
            btnDashboard.BackColor = Color.FromArgb(24, 30, 54);
            btnWorkCertAR.BackColor = Color.FromArgb(24, 30, 54);
            btnSettings.BackColor = Color.FromArgb(24, 30, 54);
            lblTitle.Text = "Work Certificate FR";
            this.PnlFormLoader.Controls.Clear();
            FormADTfrench FrmDashboard_Vrb = new FormADTfrench() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnSettings.Height;
            pnlNav.Top = btnSettings.Top;
            btnSettings.BackColor = Color.FromArgb(46, 51, 73);
            btnDashboard.BackColor = Color.FromArgb(24, 30, 54);
            btnWorkCertAR.BackColor = Color.FromArgb(24, 30, 54);
            btnWorkCertFR.BackColor = Color.FromArgb(24, 30, 54);

            lblTitle.Text = "Settings";
            this.PnlFormLoader.Controls.Clear();
            
        }

        

        

        
        





        private void Label11_Click(object sender, EventArgs e)
        {

        }

        private void Label14_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Label15_Click(object sender, EventArgs e)
        {

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
