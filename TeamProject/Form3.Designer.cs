﻿namespace TeamProject
{
    partial class 상품재고관리
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
            this.전체기간 = new System.Windows.Forms.ComboBox();
            this.카테고리 = new System.Windows.Forms.ComboBox();
            this.상품명 = new System.Windows.Forms.ComboBox();
            this.검색창 = new System.Windows.Forms.TextBox();
            this.검색버튼 = new System.Windows.Forms.Button();
            this.버튼생성 = new System.Windows.Forms.FlowLayoutPanel();
            this.Pregister_text = new System.Windows.Forms.Label();
            this.Report_text = new System.Windows.Forms.Label();
            this.Sale_text = new System.Windows.Forms.Label();
            this.Pmanage_text = new System.Windows.Forms.Label();
            this.추가 = new System.Windows.Forms.Button();
            this.수정 = new System.Windows.Forms.Button();
            this.삭제 = new System.Windows.Forms.Button();
            this.판매 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.재고관리)).BeginInit();
            this.SuspendLayout();
            // 
            // 재고관리
            // 
            this.재고관리.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.재고관리.Location = new System.Drawing.Point(330, 106);
            this.재고관리.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.재고관리.Name = "재고관리";
            this.재고관리.RowHeadersWidth = 51;
            this.재고관리.RowTemplate.Height = 27;
            this.재고관리.Size = new System.Drawing.Size(1336, 602);
            this.재고관리.TabIndex = 0;
            // 
            // 전체기간
            // 
            this.전체기간.FormattingEnabled = true;
            this.전체기간.Location = new System.Drawing.Point(507, 849);
            this.전체기간.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.전체기간.Name = "전체기간";
            this.전체기간.Size = new System.Drawing.Size(113, 26);
            this.전체기간.TabIndex = 1;
            this.전체기간.Text = "전체기간";
            // 
            // 카테고리
            // 
            this.카테고리.FormattingEnabled = true;
            this.카테고리.Location = new System.Drawing.Point(789, 849);
            this.카테고리.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.카테고리.Name = "카테고리";
            this.카테고리.Size = new System.Drawing.Size(105, 26);
            this.카테고리.TabIndex = 2;
            this.카테고리.Text = "카테고리";
            // 
            // 상품명
            // 
            this.상품명.FormattingEnabled = true;
            this.상품명.Location = new System.Drawing.Point(661, 849);
            this.상품명.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.상품명.Name = "상품명";
            this.상품명.Size = new System.Drawing.Size(98, 26);
            this.상품명.TabIndex = 3;
            this.상품명.Text = "상품명";
            // 
            // 검색창
            // 
            this.검색창.ForeColor = System.Drawing.Color.Gray;
            this.검색창.Location = new System.Drawing.Point(944, 848);
            this.검색창.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.검색창.Name = "검색창";
            this.검색창.Size = new System.Drawing.Size(297, 28);
            this.검색창.TabIndex = 4;
            this.검색창.Enter += new System.EventHandler(this.검색창_Enter);
            this.검색창.Leave += new System.EventHandler(this.검색창_Leave);
            // 
            // 검색버튼
            // 
            this.검색버튼.Location = new System.Drawing.Point(1254, 849);
            this.검색버튼.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.검색버튼.Name = "검색버튼";
            this.검색버튼.Size = new System.Drawing.Size(101, 30);
            this.검색버튼.TabIndex = 5;
            this.검색버튼.Text = "검색";
            this.검색버튼.UseVisualStyleBackColor = true;
            // 
            // 버튼생성
            // 
            this.버튼생성.Location = new System.Drawing.Point(831, 764);
            this.버튼생성.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.버튼생성.Name = "버튼생성";
            this.버튼생성.Size = new System.Drawing.Size(250, 45);
            this.버튼생성.TabIndex = 12;
            // 
            // Pregister_text
            // 
            this.Pregister_text.AutoSize = true;
            this.Pregister_text.Font = new System.Drawing.Font("궁서체", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Pregister_text.Location = new System.Drawing.Point(34, 141);
            this.Pregister_text.Name = "Pregister_text";
            this.Pregister_text.Size = new System.Drawing.Size(148, 30);
            this.Pregister_text.TabIndex = 13;
            this.Pregister_text.Text = "상품 등록";
            
            // 
            // Report_text
            // 
            this.Report_text.AutoSize = true;
            this.Report_text.Font = new System.Drawing.Font("궁서체", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Report_text.Location = new System.Drawing.Point(21, 645);
            this.Report_text.Name = "Report_text";
            this.Report_text.Size = new System.Drawing.Size(178, 30);
            this.Report_text.TabIndex = 16;
            this.Report_text.Text = "보고서 관리";
            this.Report_text.Click += new System.EventHandler(this.Report_text_Click);
            // 
            // Sale_text
            // 
            this.Sale_text.AutoSize = true;
            this.Sale_text.Font = new System.Drawing.Font("궁서체", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Sale_text.Location = new System.Drawing.Point(34, 477);
            this.Sale_text.Name = "Sale_text";
            this.Sale_text.Size = new System.Drawing.Size(148, 30);
            this.Sale_text.TabIndex = 15;
            this.Sale_text.Text = "판매 내역";
            this.Sale_text.Click += new System.EventHandler(this.Sale_text_Click);
            // 
            // Pmanage_text
            // 
            this.Pmanage_text.AutoSize = true;
            this.Pmanage_text.Font = new System.Drawing.Font("궁서체", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Pmanage_text.Location = new System.Drawing.Point(34, 309);
            this.Pmanage_text.Name = "Pmanage_text";
            this.Pmanage_text.Size = new System.Drawing.Size(148, 30);
            this.Pmanage_text.TabIndex = 14;
            this.Pmanage_text.Text = "상품 관리";
            
            // 
            // 추가
            // 
            this.추가.Location = new System.Drawing.Point(1314, 734);
            this.추가.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.추가.Name = "추가";
            this.추가.Size = new System.Drawing.Size(96, 27);
            this.추가.TabIndex = 17;
            this.추가.Text = "추가";
            this.추가.UseVisualStyleBackColor = true;
            this.추가.Click += new System.EventHandler(this.추가_Click);
            // 
            // 수정
            // 
            this.수정.Location = new System.Drawing.Point(1443, 734);
            this.수정.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.수정.Name = "수정";
            this.수정.Size = new System.Drawing.Size(94, 27);
            this.수정.TabIndex = 18;
            this.수정.Text = "수정";
            this.수정.UseVisualStyleBackColor = true;
            // 
            // 삭제
            // 
            this.삭제.Location = new System.Drawing.Point(1570, 734);
            this.삭제.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.삭제.Name = "삭제";
            this.삭제.Size = new System.Drawing.Size(94, 27);
            this.삭제.TabIndex = 19;
            this.삭제.Text = "삭제";
            this.삭제.UseVisualStyleBackColor = true;
            // 
            // 판매
            // 
            this.판매.Location = new System.Drawing.Point(1429, 801);
            this.판매.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.판매.Name = "판매";
            this.판매.Size = new System.Drawing.Size(110, 78);
            this.판매.TabIndex = 20;
            this.판매.Text = "판매";
            this.판매.UseVisualStyleBackColor = true;
            // 
            // 상품재고관리
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1820, 968);
            this.Controls.Add(this.판매);
            this.Controls.Add(this.삭제);
            this.Controls.Add(this.수정);
            this.Controls.Add(this.추가);
            this.Controls.Add(this.Report_text);
            this.Controls.Add(this.Sale_text);
            this.Controls.Add(this.Pmanage_text);
            this.Controls.Add(this.Pregister_text);
            this.Controls.Add(this.버튼생성);
            this.Controls.Add(this.검색버튼);
            this.Controls.Add(this.검색창);
            this.Controls.Add(this.상품명);
            this.Controls.Add(this.카테고리);
            this.Controls.Add(this.전체기간);
            this.Controls.Add(this.재고관리);
            this.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.Name = "상품재고관리";
            this.Text = "상품재고관리";
            
            ((System.ComponentModel.ISupportInitialize)(this.재고관리)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView 재고관리;
        private System.Windows.Forms.ComboBox 전체기간;
        private System.Windows.Forms.ComboBox 카테고리;
        private System.Windows.Forms.ComboBox 상품명;
        private System.Windows.Forms.TextBox 검색창;
        private System.Windows.Forms.Button 검색버튼;
        private System.Windows.Forms.FlowLayoutPanel 버튼생성;
        private System.Windows.Forms.Label Pregister_text;
        private System.Windows.Forms.Label Report_text;
        private System.Windows.Forms.Label Sale_text;
        private System.Windows.Forms.Label Pmanage_text;
        private System.Windows.Forms.Button 추가;
        private System.Windows.Forms.Button 수정;
        private System.Windows.Forms.Button 삭제;
        private System.Windows.Forms.Button 판매;
    }
}