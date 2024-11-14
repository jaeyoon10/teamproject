namespace TeamProject
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
            ((System.ComponentModel.ISupportInitialize)(this.재고관리)).BeginInit();
            this.SuspendLayout();
            // 
            // 재고관리
            // 
            this.재고관리.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.재고관리.Location = new System.Drawing.Point(211, 74);
            this.재고관리.Name = "재고관리";
            this.재고관리.RowHeadersWidth = 51;
            this.재고관리.RowTemplate.Height = 27;
            this.재고관리.Size = new System.Drawing.Size(1069, 501);
            this.재고관리.TabIndex = 0;
            // 
            // 전체기간
            // 
            this.전체기간.FormattingEnabled = true;
            this.전체기간.Location = new System.Drawing.Point(447, 657);
            this.전체기간.Name = "전체기간";
            this.전체기간.Size = new System.Drawing.Size(91, 23);
            this.전체기간.TabIndex = 1;
            this.전체기간.Text = "전체기간";
            // 
            // 카테고리
            // 
            this.카테고리.FormattingEnabled = true;
            this.카테고리.Location = new System.Drawing.Point(666, 657);
            this.카테고리.Name = "카테고리";
            this.카테고리.Size = new System.Drawing.Size(85, 23);
            this.카테고리.TabIndex = 2;
            this.카테고리.Text = "카테고리";
            // 
            // 상품명
            // 
            this.상품명.FormattingEnabled = true;
            this.상품명.Location = new System.Drawing.Point(566, 657);
            this.상품명.Name = "상품명";
            this.상품명.Size = new System.Drawing.Size(80, 23);
            this.상품명.TabIndex = 3;
            this.상품명.Text = "상품명";
            // 
            // 검색창
            // 
            this.검색창.Location = new System.Drawing.Point(778, 657);
            this.검색창.Name = "검색창";
            this.검색창.Size = new System.Drawing.Size(238, 25);
            this.검색창.TabIndex = 4;
            this.검색창.Text = "검색어를 입력하세요";
            // 
            // 검색버튼
            // 
            this.검색버튼.Location = new System.Drawing.Point(1041, 659);
            this.검색버튼.Name = "검색버튼";
            this.검색버튼.Size = new System.Drawing.Size(75, 23);
            this.검색버튼.TabIndex = 5;
            this.검색버튼.Text = "검색";
            this.검색버튼.UseVisualStyleBackColor = true;
            // 
            // 버튼생성
            // 
            this.버튼생성.Location = new System.Drawing.Point(666, 597);
            this.버튼생성.Name = "버튼생성";
            this.버튼생성.Size = new System.Drawing.Size(200, 37);
            this.버튼생성.TabIndex = 12;
            // 
            // 상품재고관리
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1373, 734);
            this.Controls.Add(this.버튼생성);
            this.Controls.Add(this.검색버튼);
            this.Controls.Add(this.검색창);
            this.Controls.Add(this.상품명);
            this.Controls.Add(this.카테고리);
            this.Controls.Add(this.전체기간);
            this.Controls.Add(this.재고관리);
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
    }
}