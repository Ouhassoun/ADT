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
    public partial class LoadingScreenForm : Form
    {
        private int incrementAmount;
        public LoadingScreenForm()
        {
            InitializeComponent();
            timer1.Interval = 100;
            incrementAmount = 80;
        }
        bool finish = false;
        SQLiteConnection cnx = new SQLiteConnection(@"URI=file:" + Application.StartupPath + "\\ADTDB.db;PRAGMA journal_mode = WAL;");
        private void LoadingScreenForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
            CreateDataBase();
        }
        void CreateDataBase()
        {
            string path = "ADTDB.db";
            if (!System.IO.File.Exists(path))
            {
                SQLiteConnection.CreateFile(path);
                SQLiteCommand cmdUserAR = new SQLiteCommand("create table userAR(Numero varchar(255),NomEtPrenom varchar(255),CIN varchar(255),Matricule varchar(255),DateDeRecru varchar(255),Grade varchar(255),Fonction varchar(255),Affectation varchar(255))", cnx);
                SQLiteCommand cmdUserFR = new SQLiteCommand("create table userFR(Numero varchar(255),NomEtPrenom varchar(255),CIN varchar(255),Matricule varchar(255),DateDeRecru varchar(255),Grade varchar(255),Fonction varchar(255),Affectation varchar(255))", cnx);
                SQLiteCommand cmdusers = new SQLiteCommand("create table users(username nvarchar(30),user_password nvarchar(120),user_role nvarchar(30),creation_date date,last_login_date date,is_regen_password int,primary key(username))", cnx);
                SQLiteCommand cmdCreateMasterUser = new SQLiteCommand("insert into users values('meow','meow','Admin',DATE('2023-07-07'),DATE('2023-07-07'),'0')", cnx);
                SQLiteCommand cmdCreateUser = new SQLiteCommand("insert into users values('lhaja','0662020426','Admin',DATE('2023-07-07'),DATE('2023-07-07'),'0')", cnx);
                cnx.Open();
                using (SQLiteCommand pragmaCommand = new SQLiteCommand("PRAGMA journal_mode=WAL;", cnx))
                {
                    pragmaCommand.ExecuteNonQuery();
                }
                cmdUserAR.ExecuteNonQuery();
                cmdUserFR.ExecuteNonQuery();
                cmdusers.ExecuteNonQuery();
                cmdCreateUser.ExecuteNonQuery();
                cmdCreateMasterUser.ExecuteNonQuery();
                cnx.Close();
                finish = true;
            }
            else
                finish = true;
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            incrementAmount++;
            if (finish && incrementAmount>=100)
            {
                timer1.Stop();
                LoginForm frmLogin = new LoginForm();
                this.Hide();
                frmLogin.Show();
            }
        }
    }
}
