namespace WinForm
{
    partial class PackageTreatments
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
            this.button1 = new System.Windows.Forms.Button();
            this.dgMappedData = new System.Windows.Forms.DataGridView();
            this.dgPackages = new System.Windows.Forms.DataGridView();
            this.dgTreatments = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgMappedData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPackages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTreatments)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(93, 395);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Get All Data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgMappedData
            // 
            this.dgMappedData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMappedData.Location = new System.Drawing.Point(12, 35);
            this.dgMappedData.Name = "dgMappedData";
            this.dgMappedData.Size = new System.Drawing.Size(328, 335);
            this.dgMappedData.TabIndex = 1;
            // 
            // dgPackages
            // 
            this.dgPackages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPackages.Location = new System.Drawing.Point(358, 35);
            this.dgPackages.Name = "dgPackages";
            this.dgPackages.Size = new System.Drawing.Size(246, 335);
            this.dgPackages.TabIndex = 2;
            // 
            // dgTreatments
            // 
            this.dgTreatments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTreatments.Location = new System.Drawing.Point(624, 35);
            this.dgTreatments.Name = "dgTreatments";
            this.dgTreatments.Size = new System.Drawing.Size(249, 335);
            this.dgTreatments.TabIndex = 3;
            this.dgTreatments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Package and Treatment Mappings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(452, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Packages";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(723, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Treatments";
            // 
            // PackageTreatments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 449);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgTreatments);
            this.Controls.Add(this.dgPackages);
            this.Controls.Add(this.dgMappedData);
            this.Controls.Add(this.button1);
            this.Name = "PackageTreatments";
            this.Text = "PackageTreatments";
            ((System.ComponentModel.ISupportInitialize)(this.dgMappedData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPackages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTreatments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgMappedData;
        private System.Windows.Forms.DataGridView dgPackages;
        private System.Windows.Forms.DataGridView dgTreatments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}