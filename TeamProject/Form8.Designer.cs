namespace TeamProject
{
    partial class Form8
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
            this.재고관리 = new System.Windows.Forms.DataGridView();
            this.판매 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.재고관리)).BeginInit();
            this.SuspendLayout();
            // 
            // 재고관리
            // 
            this.재고관리.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.재고관리.Location = new System.Drawing.Point(271, 44);
            this.재고관리.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.재고관리.Name = "재고관리";
            this.재고관리.RowHeadersWidth = 62;
            this.재고관리.RowTemplate.Height = 30;
            this.재고관리.Size = new System.Drawing.Size(894, 416);
            this.재고관리.TabIndex = 0;
            // 
            // 판매
            // 
            this.판매.Location = new System.Drawing.Point(1084, 519);
            this.판매.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.판매.Name = "판매";
            this.판매.Size = new System.Drawing.Size(82, 66);
            this.판매.TabIndex = 1;
            this.판매.Text = "판매";
            this.판매.UseVisualStyleBackColor = true;
            this.판매.Click += new System.EventHandler(this.판매_Click);
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 635);
            this.Controls.Add(this.판매);
            this.Controls.Add(this.재고관리);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form8";
            this.Text = "Form8";
            this.Load += new System.EventHandler(this.Form8_Load);
            ((System.ComponentModel.ISupportInitialize)(this.재고관리)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView 재고관리;
        private System.Windows.Forms.Button 판매;
    }
}