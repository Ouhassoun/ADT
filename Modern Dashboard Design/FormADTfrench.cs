using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace Modern_Dashboard_Design
{
    public partial class FormADTfrench : Form
    {
        SQLiteConnection cnx = new SQLiteConnection(@"URI=file:" + Application.StartupPath + "\\ADTDB.db;PRAGMA journal_mode = WAL;");
        private DataView dataView;
        public FormADTfrench()
        {
            InitializeComponent();
        }
        private void FormADTfrench_Load(object sender, EventArgs e)
        {
            DGVUpdate();
        }
        void AlertBoxShow(string Type, string text)
        {
            FormAlertBox frm = new FormAlertBox();
            if (Type == "success")
            {
                frm.BackColor = Color.LightGreen;
                frm.ColorAlertBox = Color.SeaGreen;
                frm.TitleAlertBox = "Success";
                frm.IconAlertBox = Properties.Resources.success;
            }
            else if (Type == "error")
            {
                frm.BackColor = Color.LightPink;
                frm.ColorAlertBox = Color.DarkRed;
                frm.TitleAlertBox = "Error";
                frm.IconAlertBox = Properties.Resources.error;
            }
            else if (Type == "warrning")
            {
                frm.BackColor = Color.LightGoldenrodYellow;
                frm.ColorAlertBox = Color.Goldenrod;
                frm.TitleAlertBox = "Warrning";
                frm.IconAlertBox = Properties.Resources.warning;
            }
            else
            {
                frm.BackColor = Color.LightBlue;
                frm.ColorAlertBox = Color.DodgerBlue;
                frm.TitleAlertBox = "Information";
                frm.IconAlertBox = Properties.Resources.information;
            }

            frm.TextAlertBox = text;
            frm.Show();
        }

        public bool Exists(string cin)
        {
            bool meow;

            SQLiteCommand cmd = new SQLiteCommand("select * from userFR where CIN=@cin", cnx);
            cmd.Parameters.AddWithValue("@cin", cin);
            cnx.Open();
            SQLiteDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
                meow = true;
            else
                meow = false;
            cnx.Close();
            return meow;
        }
        public bool IsEmpty()
        {
            bool isNull = false;
            foreach (Control c in this.Controls)
            {
                if (c is TextBox && c.Text == "")
                {
                    isNull = true;
                    return isNull;
                }
            }
            if (comboGrade.Text == "")
                isNull = true;
            return isNull;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            AttestationDuTravail attestationDuTravail = new AttestationDuTravail();
            TextObject TextNum = (TextObject)attestationDuTravail.ReportDefinition.Sections["Section3"].ReportObjects["txtnum"];
            TextObject TextName = (TextObject)attestationDuTravail.ReportDefinition.Sections["Section3"].ReportObjects["txtname"];
            TextObject TextCin = (TextObject)attestationDuTravail.ReportDefinition.Sections["Section3"].ReportObjects["txtcin"];
            TextObject TextMatricule = (TextObject)attestationDuTravail.ReportDefinition.Sections["Section3"].ReportObjects["txtmatricule"];
            TextObject TextDateReq = (TextObject)attestationDuTravail.ReportDefinition.Sections["Section3"].ReportObjects["txtdatereq"];
            TextObject TextGrade = (TextObject)attestationDuTravail.ReportDefinition.Sections["Section3"].ReportObjects["txtgrade"];
            TextObject TextFonction = (TextObject)attestationDuTravail.ReportDefinition.Sections["Section3"].ReportObjects["txtfonction"];
            TextObject TextAffectation = (TextObject)attestationDuTravail.ReportDefinition.Sections["Section3"].ReportObjects["txtaffectation"];
            TextObject TextDate = (TextObject)attestationDuTravail.ReportDefinition.Sections["Section4"].ReportObjects["txtDate"];

            TextNum.Text = txtnum.Text;
            TextName.Text = txtname.Text;
            TextCin.Text = txtcin.Text;
            TextMatricule.Text = txtmat.Text;
            TextDateReq.Text = txtdatereq.Text;
            TextGrade.Text = comboGrade.Text;
            TextFonction.Text = txtfonction.Text;
            TextAffectation.Text = txtaffec.Text;
            TextDate.Text = dateTimePicker1.Value.ToString("dd/MM/yyyy");

            // Bind the Crystal Reports viewer control to the report document
            crystalreportviewer crystalreportviewer = new crystalreportviewer();
            ((CrystalDecisions.Windows.Forms.CrystalReportViewer)crystalreportviewer.Controls[0]).ReportSource = attestationDuTravail;
            crystalreportviewer.Show();
        }
        void DGVUpdate()
        {
            SQLiteCommand cmd = new SQLiteCommand("select * from userFR", cnx);
            cnx.Open();
            SQLiteDataReader dr = cmd.ExecuteReader();

            dgv.DataSource = null;
            if (dr.HasRows)
            {
                dgv.ColumnHeadersHeight = 30;
                dgv.RowsDefaultCellStyle.Font = new System.Drawing.Font("Century Gothic", 10, FontStyle.Bold);
                dgv.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Century Gothic", 10, FontStyle.Bold);
                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                System.Data.DataTable dataTable = new System.Data.DataTable();
                dataTable.Load(dr);
                dataView = new DataView(dataTable);
                dgv.DataSource = dataView;
                dgv.Columns["Numero"].HeaderText = "Numéro";
                dgv.Columns["NomEtPrenom"].HeaderText = "Nom et Prenom";
                dgv.Columns["CIN"].HeaderText = "C I N";
                dgv.Columns["Matricule"].HeaderText = "Matricule";
                dgv.Columns["DateDeRecru"].HeaderText = "Date de recrutement";
                dgv.Columns["Grade"].HeaderText = "Grade";
                dgv.Columns["Fonction"].HeaderText = "Fonction";
                dgv.Columns["Affectation"].HeaderText = "Affectation";


            }
            cnx.Close();
        }
        //void DGVUpdate()
        //{
        //    
        //    SQLiteCommand cmd = new SQLiteCommand("select * from userFR", cnx);
        //    cnx.Open();
        //    SQLiteDataReader dr = cmd.ExecuteReader();

        //    dgv.DataSource = null;
        //    if (dr.HasRows)
        //    {
        //        BindingSource bs = new BindingSource();
        //        bs.DataSource = dr;
        //        dgv.DataSource = bs;
        //        dgv.Columns[0].HeaderText = "Numéro";
        //        dgv.Columns[1].HeaderText = "Nom et Prenom";
        //        dgv.Columns[2].HeaderText = "C I N";
        //        dgv.Columns[3].HeaderText = "Matricule";
        //        dgv.Columns[4].HeaderText = "Grade";
        //        dgv.Columns[5].HeaderText = "Fonction";
        //        dgv.Columns[6].HeaderText = "Affectation";
        //    }
        //    cnx.Close();
        //}
        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Check if a row is actually clicked
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];

                // Retrieve data from the selected row and display in the textboxes
                txtnum.Text = row.Cells["Numero"].Value.ToString();
                txtname.Text = row.Cells["NomEtPrenom"].Value.ToString();
                txtcin.Text = row.Cells["CIN"].Value.ToString();
                txtmat.Text = row.Cells["Matricule"].Value.ToString();
                txtdatereq.Text = row.Cells["DateDeRecru"].Value.ToString();
                comboGrade.Text = row.Cells["Grade"].Value.ToString();
                txtfonction.Text = row.Cells["Fonction"].Value.ToString();
                txtaffec.Text = row.Cells["Affectation"].Value.ToString();
                txtcin.Enabled = false;
            }
        }

        private void btnempty_Click(object sender, EventArgs e)
        {
            txtcin.Enabled = true;
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                    c.Text = "";
                else if (c is ComboBox)
                    c.Text = "";
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsEmpty() && !Exists(txtcin.Text))
            {
                SQLiteCommand cmd = new SQLiteCommand("insert into userFR values(@num,@nometprenom,@cin,@matricule,@dateRec,@grade,@fonction,@affectation)", cnx);
                cmd.Parameters.AddWithValue("@num", txtnum.Text);
                cmd.Parameters.AddWithValue("@nometprenom", txtname.Text);
                cmd.Parameters.AddWithValue("@cin", txtcin.Text);
                cmd.Parameters.AddWithValue("@dateRec", txtdatereq.Text);
                cmd.Parameters.AddWithValue("@matricule", txtmat.Text);
                cmd.Parameters.AddWithValue("@grade", comboGrade.Text);
                cmd.Parameters.AddWithValue("@fonction", txtfonction.Text);
                cmd.Parameters.AddWithValue("@affectation", txtaffec.Text);
                cnx.Open();
                cmd.ExecuteNonQuery();
                cnx.Close();
                DGVUpdate();
                AlertBoxShow("success", "The user has been added successfully");
            }
            else if (IsEmpty())
            {
                AlertBoxShow("error", "The fields are empty");
            }
            else if (Exists(txtcin.Text))
            {
                AlertBoxShow("warrning", "This CIN already exists");
            }

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtcin.Text != "")
            {

                SQLiteCommand cmd = new SQLiteCommand("select * from userFR where upper(CIN) = upper(@cin)", cnx);
                cmd.Parameters.AddWithValue("@cin", txtcin.Text);
                cnx.Open();
                SQLiteDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtnum.Text = dr["Numero"].ToString();
                        txtname.Text = dr["NomEtPrenom"].ToString();
                        txtcin.Text = dr["CIN"].ToString();
                        txtmat.Text = dr["Matricule"].ToString();
                        txtdatereq.Text = dr["DateDeRecru"].ToString();
                        comboGrade.Text = dr["Grade"].ToString();
                        txtfonction.Text = dr["Fonction"].ToString();
                        txtaffec.Text = dr["Affectation"].ToString();
                    }
                    txtcin.Enabled = false;
                    AlertBoxShow("success", "User has been found");
                }
                else
                {
                    AlertBoxShow("information", "No user with this CIN: " + txtcin.Text);
                }
                cnx.Close();

            }
            else
            {
                AlertBoxShow("warrning", "Enter a CIN");
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!IsEmpty() && Exists(txtcin.Text))
            {

                SQLiteCommand cmd = new SQLiteCommand("delete from userFR where CIN=@cin", cnx);
                cmd.Parameters.AddWithValue("@cin", txtcin.Text);
                cnx.Open();
                cmd.ExecuteNonQuery();
                cnx.Close();
                DGVUpdate();
                AlertBoxShow("success", "The user has been deleted successfully");
                btnempty_Click(null, null);
            }
            else if (txtcin.Text == "")
            {
                AlertBoxShow("error", "The CIN field is empty");
            }
            else if (!Exists(txtcin.Text))
            {
                AlertBoxShow("error", "The user you are trying to delete doesn't exists");
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!IsEmpty())
            {

                SQLiteCommand cmd = new SQLiteCommand("update userFR set set Numero=@num,Nometprenom=@nometprenom,Matricule=@matricule,DateDeRecru=@dateRec,Grade=@grade,Fonction=@fonction,Affectation=@affectation where CIN=@cin", cnx);
                cmd.Parameters.AddWithValue("@num", txtnum.Text);
                cmd.Parameters.AddWithValue("@cin", txtcin.Text);
                cmd.Parameters.AddWithValue("@nometprenom", txtname.Text);
                cmd.Parameters.AddWithValue("@matricule", txtmat.Text);
                cmd.Parameters.AddWithValue("@dateRec", txtdatereq.Text);
                cmd.Parameters.AddWithValue("@grade", comboGrade.Text);
                cmd.Parameters.AddWithValue("@fonction", txtfonction.Text);
                cmd.Parameters.AddWithValue("@affectation", txtaffec.Text);
                cnx.Open();
                cmd.ExecuteNonQuery();
                cnx.Close();
                DGVUpdate();
                AlertBoxShow("success", "The user has been updated successfully");
            }
            else
            {
                AlertBoxShow("error", "The fields are empty");
            }
        }
        private void MaxChar_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Get the TextBox control that raised the event
            TextBox textBox = (TextBox)sender;

            // Check if the control already has maximum length
            if (!char.IsControl(e.KeyChar) && textBox.Text.Length >= 255 &&
       !(e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete))
            {
                e.Handled = true;
            }
        }
    }
}
