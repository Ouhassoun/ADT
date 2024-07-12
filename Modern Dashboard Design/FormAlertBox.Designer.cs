namespace Modern_Dashboard_Design
{
    partial class FormAlertBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAlertBox));
            this.PicAlertBox = new System.Windows.Forms.PictureBox();
            this.lblTitleAlertBox = new System.Windows.Forms.Label();
            this.lblTextAlertBox = new System.Windows.Forms.Label();
            this.LinAlertBox = new System.Windows.Forms.Panel();
            this.TimerAnimation = new System.Windows.Forms.Timer(this.components);
            this.cornerRemoverControl1 = new Modern_Dashboard_Design.CornerRemoverControl();
            ((System.ComponentModel.ISupportInitialize)(this.PicAlertBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PicAlertBox
            // 
            this.PicAlertBox.Location = new System.Drawing.Point(25, 17);
            this.PicAlertBox.Name = "PicAlertBox";
            this.PicAlertBox.Size = new System.Drawing.Size(50, 50);
            this.PicAlertBox.TabIndex = 0;
            this.PicAlertBox.TabStop = false;
            // 
            // lblTitleAlertBox
            // 
            this.lblTitleAlertBox.AutoSize = true;
            this.lblTitleAlertBox.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleAlertBox.Location = new System.Drawing.Point(81, 17);
            this.lblTitleAlertBox.Name = "lblTitleAlertBox";
            this.lblTitleAlertBox.Size = new System.Drawing.Size(134, 25);
            this.lblTitleAlertBox.TabIndex = 1;
            this.lblTitleAlertBox.Text = "TitleAlertBox";
            // 
            // lblTextAlertBox
            // 
            this.lblTextAlertBox.AutoSize = true;
            this.lblTextAlertBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextAlertBox.Location = new System.Drawing.Point(83, 42);
            this.lblTextAlertBox.Name = "lblTextAlertBox";
            this.lblTextAlertBox.Size = new System.Drawing.Size(108, 21);
            this.lblTextAlertBox.TabIndex = 1;
            this.lblTextAlertBox.Text = "TextAlertBox";
            // 
            // LinAlertBox
            // 
            this.LinAlertBox.BackColor = System.Drawing.Color.Black;
            this.LinAlertBox.Location = new System.Drawing.Point(0, 74);
            this.LinAlertBox.Name = "LinAlertBox";
            this.LinAlertBox.Size = new System.Drawing.Size(6, 6);
            this.LinAlertBox.TabIndex = 2;
            // 
            // TimerAnimation
            // 
            this.TimerAnimation.Interval = 10;
            this.TimerAnimation.Tick += new System.EventHandler(this.TimerAnimation_Tick);
            // 
            // cornerRemoverControl1
            // 
            this.cornerRemoverControl1.CornerRedius = 20;
            this.cornerRemoverControl1.TargetControl = this;
            // 
            // FormAlertBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 80);
            this.Controls.Add(this.LinAlertBox);
            this.Controls.Add(this.lblTextAlertBox);
            this.Controls.Add(this.lblTitleAlertBox);
            this.Controls.Add(this.PicAlertBox);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAlertBox";
            this.Text = "Work Certificate";
            this.Load += new System.EventHandler(this.FormAlertBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicAlertBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PicAlertBox;
        private System.Windows.Forms.Label lblTitleAlertBox;
        private System.Windows.Forms.Label lblTextAlertBox;
        private System.Windows.Forms.Panel LinAlertBox;
        private System.Windows.Forms.Timer TimerAnimation;
        private CornerRemoverControl cornerRemoverControl1;
    }
}