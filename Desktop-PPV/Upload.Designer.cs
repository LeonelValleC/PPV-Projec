
namespace Desktop_PPV
{
    partial class Upload
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
            this.btn_Claer = new System.Windows.Forms.Button();
            this.btn_Ingresar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_Paste = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Claer
            // 
            this.btn_Claer.Location = new System.Drawing.Point(15, 49);
            this.btn_Claer.Name = "btn_Claer";
            this.btn_Claer.Size = new System.Drawing.Size(84, 30);
            this.btn_Claer.TabIndex = 9;
            this.btn_Claer.Text = "Clear";
            this.btn_Claer.UseVisualStyleBackColor = true;
            this.btn_Claer.Click += new System.EventHandler(this.btn_Claer_Click);
            // 
            // btn_Ingresar
            // 
            this.btn_Ingresar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Ingresar.Location = new System.Drawing.Point(845, 49);
            this.btn_Ingresar.Name = "btn_Ingresar";
            this.btn_Ingresar.Size = new System.Drawing.Size(84, 30);
            this.btn_Ingresar.TabIndex = 8;
            this.btn_Ingresar.Text = "Upload";
            this.btn_Ingresar.UseVisualStyleBackColor = true;
            this.btn_Ingresar.Click += new System.EventHandler(this.btn_Ingresar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 85);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(917, 462);
            this.dataGridView1.TabIndex = 7;
            // 
            // btn_Paste
            // 
            this.btn_Paste.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Paste.Location = new System.Drawing.Point(755, 49);
            this.btn_Paste.Name = "btn_Paste";
            this.btn_Paste.Size = new System.Drawing.Size(84, 30);
            this.btn_Paste.TabIndex = 6;
            this.btn_Paste.Text = "Paste";
            this.btn_Paste.UseVisualStyleBackColor = true;
            this.btn_Paste.Click += new System.EventHandler(this.btn_Paste_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "PN",
            "Client",
            "MFG",
            "Vendor"});
            this.comboBox1.Location = new System.Drawing.Point(316, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(245, 32);
            this.comboBox1.TabIndex = 10;
            // 
            // Upload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 559);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btn_Claer);
            this.Controls.Add(this.btn_Ingresar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_Paste);
            this.Name = "Upload";
            this.Text = "Upload";
            this.Load += new System.EventHandler(this.Upload_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Claer;
        private System.Windows.Forms.Button btn_Ingresar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_Paste;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}