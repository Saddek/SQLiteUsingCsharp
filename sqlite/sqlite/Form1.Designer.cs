namespace sqlite
{
    partial class Form1
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
            this.btngo = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.CreateDB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // btngo
            // 
            this.btngo.Location = new System.Drawing.Point(70, 386);
            this.btngo.Name = "btngo";
            this.btngo.Size = new System.Drawing.Size(75, 23);
            this.btngo.TabIndex = 0;
            this.btngo.Text = "Go";
            this.btngo.UseVisualStyleBackColor = true;
            this.btngo.Click += new System.EventHandler(this.btngo_Click);
            // 
            // grid
            // 
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(70, 30);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(498, 325);
            this.grid.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(493, 386);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // CreateDB
            // 
            this.CreateDB.Location = new System.Drawing.Point(320, 414);
            this.CreateDB.Name = "CreateDB";
            this.CreateDB.Size = new System.Drawing.Size(75, 23);
            this.CreateDB.TabIndex = 3;
            this.CreateDB.Text = "CreateDB";
            this.CreateDB.UseVisualStyleBackColor = true;
            this.CreateDB.Click += new System.EventHandler(this.CreateDB_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 505);
            this.Controls.Add(this.CreateDB);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.btngo);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btngo;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button CreateDB;
    }
}

