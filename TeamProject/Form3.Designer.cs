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
            this.components = new System.ComponentModel.Container();
            this.상품관리 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.추가ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.상품수정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.상품삭제ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.카테고리 = new System.Windows.Forms.ComboBox();
            this.검색창 = new System.Windows.Forms.TextBox();
            this.검색버튼 = new System.Windows.Forms.Button();
            this.Report_text = new System.Windows.Forms.Label();
            this.Sale_text = new System.Windows.Forms.Label();
            this.Pmanage_text = new System.Windows.Forms.Label();
            this.재고 = new System.Windows.Forms.Button();
            this.시작날짜 = new System.Windows.Forms.DateTimePicker();
            this.종료날짜 = new System.Windows.Forms.DateTimePicker();
            this.기간선택 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.상품관리)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // 상품관리
            // 
            this.상품관리.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.상품관리.ContextMenuStrip = this.contextMenuStrip1;
            this.상품관리.Location = new System.Drawing.Point(184, 51);
            this.상품관리.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.상품관리.Name = "상품관리";
            this.상품관리.RowHeadersWidth = 51;
            this.상품관리.RowTemplate.Height = 27;
            this.상품관리.Size = new System.Drawing.Size(1079, 566);
            this.상품관리.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.추가ToolStripMenuItem,
            this.상품수정ToolStripMenuItem,
            this.상품삭제ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(144, 76);
            // 
            // 추가ToolStripMenuItem
            // 
            this.추가ToolStripMenuItem.Name = "추가ToolStripMenuItem";
            this.추가ToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.추가ToolStripMenuItem.Text = "상품 추가";
            // 
            // 상품수정ToolStripMenuItem
            // 
            this.상품수정ToolStripMenuItem.Name = "상품수정ToolStripMenuItem";
            this.상품수정ToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.상품수정ToolStripMenuItem.Text = "상품 수정";
            // 
            // 상품삭제ToolStripMenuItem
            // 
            this.상품삭제ToolStripMenuItem.Name = "상품삭제ToolStripMenuItem";
            this.상품삭제ToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.상품삭제ToolStripMenuItem.Text = "상품 삭제";
            // 
            // 카테고리
            // 
            this.카테고리.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.카테고리.FormattingEnabled = true;
            this.카테고리.Location = new System.Drawing.Point(110, 678);
            this.카테고리.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.카테고리.Name = "카테고리";
            this.카테고리.Size = new System.Drawing.Size(85, 23);
            this.카테고리.TabIndex = 2;
            // 
            // 검색창
            // 
            this.검색창.ForeColor = System.Drawing.Color.Gray;
            this.검색창.Location = new System.Drawing.Point(679, 680);
            this.검색창.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.검색창.Name = "검색창";
            this.검색창.Size = new System.Drawing.Size(237, 25);
            this.검색창.TabIndex = 4;
            this.검색창.Text = "검색어를 입력하세요.";
            this.검색창.Enter += new System.EventHandler(this.검색창_Enter);
            this.검색창.Leave += new System.EventHandler(this.검색창_Leave);
            // 
            // 검색버튼
            // 
            this.검색버튼.Location = new System.Drawing.Point(925, 678);
            this.검색버튼.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.검색버튼.Name = "검색버튼";
            this.검색버튼.Size = new System.Drawing.Size(81, 25);
            this.검색버튼.TabIndex = 5;
            this.검색버튼.Text = "검색";
            this.검색버튼.UseVisualStyleBackColor = true;
            this.검색버튼.Click += new System.EventHandler(this.검색버튼_Click);
            // 
            // Report_text
            // 
            this.Report_text.AutoSize = true;
            this.Report_text.Font = new System.Drawing.Font("궁서체", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Report_text.Location = new System.Drawing.Point(21, 369);
            this.Report_text.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Report_text.Name = "Report_text";
            this.Report_text.Size = new System.Drawing.Size(155, 25);
            this.Report_text.TabIndex = 16;
            this.Report_text.Text = "보고서 관리";
            this.Report_text.Click += new System.EventHandler(this.Report_text_Click);
            // 
            // Sale_text
            // 
            this.Sale_text.AutoSize = true;
            this.Sale_text.Font = new System.Drawing.Font("궁서체", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Sale_text.Location = new System.Drawing.Point(31, 229);
            this.Sale_text.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Sale_text.Name = "Sale_text";
            this.Sale_text.Size = new System.Drawing.Size(129, 25);
            this.Sale_text.TabIndex = 15;
            this.Sale_text.Text = "판매 내역";
            this.Sale_text.Click += new System.EventHandler(this.Sale_text_Click);
            // 
            // Pmanage_text
            // 
            this.Pmanage_text.AutoSize = true;
            this.Pmanage_text.Font = new System.Drawing.Font("궁서체", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Pmanage_text.Location = new System.Drawing.Point(31, 89);
            this.Pmanage_text.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Pmanage_text.Name = "Pmanage_text";
            this.Pmanage_text.Size = new System.Drawing.Size(129, 25);
            this.Pmanage_text.TabIndex = 14;
            this.Pmanage_text.Text = "상품 관리";
            this.Pmanage_text.Click += new System.EventHandler(this.Pmanage_text_Click);
            // 
            // 재고
            // 
            this.재고.Location = new System.Drawing.Point(1110, 638);
            this.재고.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.재고.Name = "재고";
            this.재고.Size = new System.Drawing.Size(88, 65);
            this.재고.TabIndex = 20;
            this.재고.Text = "재고";
            this.재고.UseVisualStyleBackColor = true;
            this.재고.Click += new System.EventHandler(this.재고버튼_Click);
            // 
            // 시작날짜
            // 
            this.시작날짜.Location = new System.Drawing.Point(215, 676);
            this.시작날짜.Margin = new System.Windows.Forms.Padding(2);
            this.시작날짜.Name = "시작날짜";
            this.시작날짜.Size = new System.Drawing.Size(161, 25);
            this.시작날짜.TabIndex = 21;
            // 
            // 종료날짜
            // 
            this.종료날짜.Location = new System.Drawing.Point(398, 676);
            this.종료날짜.Margin = new System.Windows.Forms.Padding(2);
            this.종료날짜.Name = "종료날짜";
            this.종료날짜.Size = new System.Drawing.Size(161, 25);
            this.종료날짜.TabIndex = 22;
            // 
            // 기간선택
            // 
            this.기간선택.AutoSize = true;
            this.기간선택.Location = new System.Drawing.Point(571, 679);
            this.기간선택.Margin = new System.Windows.Forms.Padding(2);
            this.기간선택.Name = "기간선택";
            this.기간선택.Size = new System.Drawing.Size(94, 19);
            this.기간선택.TabIndex = 23;
            this.기간선택.Text = "기간 선택";
            this.기간선택.UseVisualStyleBackColor = true;
            // 
            // 상품재고관리
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 728);
            this.Controls.Add(this.기간선택);
            this.Controls.Add(this.종료날짜);
            this.Controls.Add(this.시작날짜);
            this.Controls.Add(this.재고);
            this.Controls.Add(this.Report_text);
            this.Controls.Add(this.Sale_text);
            this.Controls.Add(this.Pmanage_text);
            this.Controls.Add(this.검색버튼);
            this.Controls.Add(this.검색창);
            this.Controls.Add(this.카테고리);
            this.Controls.Add(this.상품관리);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "상품재고관리";
            this.Text = "상품재고관리";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.상품재고관리_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.상품재고관리_FormClosed);
            this.Shown += new System.EventHandler(this.상품재고관리_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.상품관리)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView 상품관리;
        private System.Windows.Forms.ComboBox 카테고리;
        private System.Windows.Forms.TextBox 검색창;
        private System.Windows.Forms.Button 검색버튼;
        private System.Windows.Forms.Label Report_text;
        private System.Windows.Forms.Label Sale_text;
        private System.Windows.Forms.Label Pmanage_text;
        private System.Windows.Forms.Button 재고;
        private System.Windows.Forms.DateTimePicker 시작날짜;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 추가ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 상품수정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 상품삭제ToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker 종료날짜;
        private System.Windows.Forms.CheckBox 기간선택;
    }
}