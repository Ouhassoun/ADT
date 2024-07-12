using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Modern_Dashboard_Design
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        SQLiteConnection cnx = new SQLiteConnection(@"URI=file:" + Application.StartupPath + "\\ADTDB.db;PRAGMA journal_mode = WAL;");

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != "" && txtUsername.Text != "")
            {
                int Regen = 0;
                bool found = false;
                SQLiteCommand cmd = new SQLiteCommand("select * from users where username=@username and user_password=@password", cnx);
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                cnx.Open();
                SQLiteDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    found = true;
                    while (dr.Read())
                    {
                        if ((int)dr["is_Regen_Password"] == 1)
                            Regen = 1;
                    }
                }
                else
                    found = false;
                cnx.Close();
                if (found)
                {
                    SQLiteCommand cmdlogs = new SQLiteCommand("update users set last_login_date=@date where username=@username", cnx);
                    
                    DateTime date = DateTime.Now;
                    cmdlogs.Parameters.AddWithValue("@date", date);
                    cmdlogs.Parameters.AddWithValue("@username", txtUsername.Text);
                    cnx.Open();
                    cmdlogs.ExecuteNonQuery();
                    cnx.Close();
                    Success(txtUsername.Text, Regen);
                }
                else
                {
                    txtUsername.Text = txtPassword.Text = "";
                    lblError.Text = "You have entered an invalid username or password";
                    lblError.ForeColor = Color.Red;
                    lblError.Font = new Font("Century Gothic", 9, FontStyle.Regular);
                }
            }
        }
        

        public void Success(string username, int Regen)
        {
            
                MainForm frmMain = new MainForm();
                this.Hide();
                frmMain.Show();
            
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
