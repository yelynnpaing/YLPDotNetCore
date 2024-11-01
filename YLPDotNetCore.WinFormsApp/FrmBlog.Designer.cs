namespace YLPDotNetCore.WinFormsApp
{
    partial class FrmBlog
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
            label1 = new Label();
            txtTitle = new TextBox();
            btnSave = new Button();
            label2 = new Label();
            label3 = new Label();
            txtAuthor = new TextBox();
            txtContent = new TextBox();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(235, 70);
            label1.Name = "label1";
            label1.Size = new Size(56, 23);
            label1.TabIndex = 0;
            label1.Text = "Title : ";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(235, 96);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(466, 30);
            txtTitle.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.LimeGreen;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(235, 294);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(106, 33);
            btnSave.TabIndex = 2;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(235, 129);
            label2.Name = "label2";
            label2.Size = new Size(77, 23);
            label2.TabIndex = 3;
            label2.Text = "Author : ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(235, 188);
            label3.Name = "label3";
            label3.Size = new Size(86, 23);
            label3.TabIndex = 4;
            label3.Text = "Content : ";
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(235, 155);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(466, 30);
            txtAuthor.TabIndex = 5;
            // 
            // txtContent
            // 
            txtContent.Location = new Point(235, 214);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(466, 74);
            txtContent.TabIndex = 6;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(144, 164, 174);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(347, 294);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(106, 33);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // FrmBlog
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 518);
            Controls.Add(btnCancel);
            Controls.Add(txtContent);
            Controls.Add(txtAuthor);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnSave);
            Controls.Add(txtTitle);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "FrmBlog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = " Blog";
            Load += FrmBlog_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtTitle;
        private Button btnSave;
        private Label label2;
        private Label label3;
        private TextBox txtAuthor;
        private TextBox txtContent;
        private Button btnCancel;
    }
}
