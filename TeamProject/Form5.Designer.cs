﻿namespace TeamProject
{
    partial class Form5
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
            this.Report_text = new System.Windows.Forms.Label();
            this.Sale_text = new System.Windows.Forms.Label();
            this.Pmanage_text = new System.Windows.Forms.Label();
            this.Pregister_text = new System.Windows.Forms.Label();
            this.버튼생성 = new System.Windows.Forms.FlowLayoutPanel();
            this.검색버튼 = new System.Windows.Forms.Button();
            this.검색창 = new System.Windows.Forms.TextBox();
            this.상품명 = new System.Windows.Forms.ComboBox();
            this.카테고리 = new System.Windows.Forms.ComboBox();
            this.전체기간 = new System.Windows.Forms.ComboBox();
            this.재고관리 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.재고관리)).BeginInit();
            this.SuspendLayout();
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
            this.Report_text.Click += new System.EventHandler(this.Report_text_Click);
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
            this.Pregister_text.Click += new System.EventHandler(this.Pregister_text_Click);
            // 
            // 버튼생성
            // 
            this.버튼생성.Location = new System.Drawing.Point(920, 702);
            this.버튼생성.Margin = new System.Windows.Forms.Padding(4);
            this.버튼생성.Name = "버튼생성";
            this.버튼생성.Size = new System.Drawing.Size(250, 44);
            this.버튼생성.TabIndex = 27;
            // 
            // 검색버튼
            // 
            this.검색버튼.Location = new System.Drawing.Point(1389, 777);
            this.검색버튼.Margin = new System.Windows.Forms.Padding(4);
            this.검색버튼.Name = "검색버튼";
            this.검색버튼.Size = new System.Drawing.Size(94, 28);
            this.검색버튼.TabIndex = 26;
            this.검색버튼.Text = "검색";
            this.검색버튼.UseVisualStyleBackColor = true;
            // 
            // 검색창
            // 
            this.검색창.Location = new System.Drawing.Point(1060, 774);
            this.검색창.Margin = new System.Windows.Forms.Padding(4);
            this.검색창.Name = "검색창";
            this.검색창.Size = new System.Drawing.Size(296, 28);
            this.검색창.TabIndex = 25;
            this.검색창.Text = "검색어를 입력하세요";
            // 
            // 상품명
            // 
            this.상품명.FormattingEnabled = true;
            this.상품명.Location = new System.Drawing.Point(796, 774);
            this.상품명.Margin = new System.Windows.Forms.Padding(4);
            this.상품명.Name = "상품명";
            this.상품명.Size = new System.Drawing.Size(99, 26);
            this.상품명.TabIndex = 24;
            this.상품명.Text = "상품명";
            // 
            // 카테고리
            // 
            this.카테고리.FormattingEnabled = true;
            this.카테고리.Location = new System.Drawing.Point(920, 774);
            this.카테고리.Margin = new System.Windows.Forms.Padding(4);
            this.카테고리.Name = "카테고리";
            this.카테고리.Size = new System.Drawing.Size(105, 26);
            this.카테고리.TabIndex = 23;
            this.카테고리.Text = "카테고리";
            // 
            // 전체기간
            // 
            this.전체기간.FormattingEnabled = true;
            this.전체기간.Location = new System.Drawing.Point(647, 774);
            this.전체기간.Margin = new System.Windows.Forms.Padding(4);
            this.전체기간.Name = "전체기간";
            this.전체기간.Size = new System.Drawing.Size(113, 26);
            this.전체기간.TabIndex = 22;
            this.전체기간.Text = "전체기간";
            // 
            // 재고관리
            // 
            this.재고관리.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.재고관리.Location = new System.Drawing.Point(352, 75);
            this.재고관리.Margin = new System.Windows.Forms.Padding(4);
            this.재고관리.Name = "재고관리";
            this.재고관리.RowHeadersWidth = 51;
            this.재고관리.RowTemplate.Height = 27;
            this.재고관리.Size = new System.Drawing.Size(1336, 601);
            this.재고관리.TabIndex = 21;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1867, 864);
            this.Controls.Add(this.버튼생성);
            this.Controls.Add(this.검색버튼);
            this.Controls.Add(this.검색창);
            this.Controls.Add(this.상품명);
            this.Controls.Add(this.카테고리);
            this.Controls.Add(this.전체기간);
            this.Controls.Add(this.재고관리);
            this.Controls.Add(this.Report_text);
            this.Controls.Add(this.Sale_text);
            this.Controls.Add(this.Pmanage_text);
            this.Controls.Add(this.Pregister_text);
            this.Name = "Form5";
            this.Text = "Form5";
            ((System.ComponentModel.ISupportInitialize)(this.재고관리)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Report_text;
        private System.Windows.Forms.Label Sale_text;
        private System.Windows.Forms.Label Pmanage_text;
        private System.Windows.Forms.Label Pregister_text;
        private System.Windows.Forms.FlowLayoutPanel 버튼생성;
        private System.Windows.Forms.Button 검색버튼;
        private System.Windows.Forms.TextBox 검색창;
        private System.Windows.Forms.ComboBox 상품명;
        private System.Windows.Forms.ComboBox 카테고리;
        private System.Windows.Forms.ComboBox 전체기간;
        private System.Windows.Forms.DataGridView 재고관리;
    }
}