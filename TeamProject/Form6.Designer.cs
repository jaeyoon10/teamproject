namespace TeamProject
{
    partial class 보고서
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.총판매수량 = new System.Windows.Forms.Label();
            this.총판매금액 = new System.Windows.Forms.Label();
            this.조회 = new System.Windows.Forms.Button();
            this.출력 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintDialog();
            this.Report_text = new System.Windows.Forms.Label();
            this.Sale_text = new System.Windows.Forms.Label();
            this.Pmanage_text = new System.Windows.Forms.Label();
            this.Pregister_text = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(251, 74);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1511, 654);
            this.dataGridView1.TabIndex = 0;
            // 
            // 총판매수량
            // 
            this.총판매수량.AutoSize = true;
            this.총판매수량.Font = new System.Drawing.Font("궁서체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.총판매수량.Location = new System.Drawing.Point(1040, 764);
            this.총판매수량.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.총판매수량.Name = "총판매수량";
            this.총판매수량.Size = new System.Drawing.Size(178, 24);
            this.총판매수량.TabIndex = 1;
            this.총판매수량.Text = "총 판매 수량 :";
            // 
            // 총판매금액
            // 
            this.총판매금액.AutoSize = true;
            this.총판매금액.Font = new System.Drawing.Font("궁서체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.총판매금액.Location = new System.Drawing.Point(1416, 764);
            this.총판매금액.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.총판매금액.Name = "총판매금액";
            this.총판매금액.Size = new System.Drawing.Size(178, 24);
            this.총판매금액.TabIndex = 2;
            this.총판매금액.Text = "총 판매 금액 :";
            // 
            // 조회
            // 
            this.조회.Location = new System.Drawing.Point(1374, 14);
            this.조회.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.조회.Name = "조회";
            this.조회.Size = new System.Drawing.Size(94, 28);
            this.조회.TabIndex = 3;
            this.조회.Text = "조회";
            this.조회.UseVisualStyleBackColor = true;
            // 
            // 출력
            // 
            this.출력.Location = new System.Drawing.Point(1528, 14);
            this.출력.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.출력.Name = "출력";
            this.출력.Size = new System.Drawing.Size(94, 28);
            this.출력.TabIndex = 4;
            this.출력.Text = "출력";
            this.출력.UseVisualStyleBackColor = true;
            this.출력.Click += new System.EventHandler(this.출력_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("궁서체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(1246, 764);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("궁서체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(1610, 764);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.UseEXDialog = true;
            // 
            // Report_text
            // 
            this.Report_text.AutoSize = true;
            this.Report_text.Font = new System.Drawing.Font("궁서체", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Report_text.Location = new System.Drawing.Point(21, 646);
            this.Report_text.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Report_text.Name = "Report_text";
            this.Report_text.Size = new System.Drawing.Size(178, 30);
            this.Report_text.TabIndex = 20;
            this.Report_text.Text = "보고서 관리";
            // 
            // Sale_text
            // 
            this.Sale_text.AutoSize = true;
            this.Sale_text.Font = new System.Drawing.Font("궁서체", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Sale_text.Location = new System.Drawing.Point(34, 478);
            this.Sale_text.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Sale_text.Name = "Sale_text";
            this.Sale_text.Size = new System.Drawing.Size(148, 30);
            this.Sale_text.TabIndex = 19;
            this.Sale_text.Text = "판매 내역";
            this.Sale_text.Click += new System.EventHandler(this.Sale_text_Click);
            // 
            // Pmanage_text
            // 
            this.Pmanage_text.AutoSize = true;
            this.Pmanage_text.Font = new System.Drawing.Font("궁서체", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Pmanage_text.Location = new System.Drawing.Point(34, 308);
            this.Pmanage_text.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Pmanage_text.Name = "Pmanage_text";
            this.Pmanage_text.Size = new System.Drawing.Size(148, 30);
            this.Pmanage_text.TabIndex = 18;
            this.Pmanage_text.Text = "상품 관리";
            this.Pmanage_text.Click += new System.EventHandler(this.Pmanage_text_Click);
            // 
            // Pregister_text
            // 
            this.Pregister_text.AutoSize = true;
            this.Pregister_text.Font = new System.Drawing.Font("궁서체", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Pregister_text.Location = new System.Drawing.Point(34, 142);
            this.Pregister_text.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Pregister_text.Name = "Pregister_text";
            this.Pregister_text.Size = new System.Drawing.Size(148, 30);
            this.Pregister_text.TabIndex = 17;
            this.Pregister_text.Text = "상품 등록";
            // 
            // 보고서
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1816, 838);
            this.Controls.Add(this.Report_text);
            this.Controls.Add(this.Sale_text);
            this.Controls.Add(this.Pmanage_text);
            this.Controls.Add(this.Pregister_text);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.출력);
            this.Controls.Add(this.조회);
            this.Controls.Add(this.총판매금액);
            this.Controls.Add(this.총판매수량);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "보고서";
            this.Text = "보고서";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label 총판매수량;
        private System.Windows.Forms.Label 총판매금액;
        private System.Windows.Forms.Button 조회;
        private System.Windows.Forms.Button 출력;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printPreviewDialog1;
        private System.Windows.Forms.Label Report_text;
        private System.Windows.Forms.Label Sale_text;
        private System.Windows.Forms.Label Pmanage_text;
        private System.Windows.Forms.Label Pregister_text;
    }
}