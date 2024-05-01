namespace AppDepartments
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DGV_departments = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)DGV_departments).BeginInit();
            SuspendLayout();
            // 
            // DGV_departments
            // 
            DGV_departments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_departments.Location = new Point(35, 27);
            DGV_departments.Name = "DGV_departments";
            DGV_departments.RowHeadersWidth = 51;
            DGV_departments.Size = new Size(730, 392);
            DGV_departments.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DGV_departments);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)DGV_departments).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DGV_departments;
    }
}
