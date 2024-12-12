namespace TeamProject
{
    partial class 수정창
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
            this.수정 = new System.Windows.Forms.Label();
            this.수정버튼 = new System.Windows.Forms.Button();
            this.공급업체 = new System.Windows.Forms.TextBox();
            this.공급_업체 = new System.Windows.Forms.Label();
            this.유통기한 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.상품이름 = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.비고 = new System.Windows.Forms.TextBox();
            this.카테고리 = new System.Windows.Forms.ComboBox();
            this.등록가격 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.상품수량 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // 수정
            // 
            this.수정.AutoSize = true;
            this.수정.Font = new System.Drawing.Font("궁서체", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.수정.Location = new System.Drawing.Point(257, 21);
            this.수정.Name = "수정";
            this.수정.Size = new System.Drawing.Size(116, 47);
            this.수정.TabIndex = 0;
            this.수정.Text = "수정";
            // 
            // 수정버튼
            // 
            this.수정버튼.Location = new System.Drawing.Point(266, 521);
            this.수정버튼.Margin = new System.Windows.Forms.Padding(2);
            this.수정버튼.Name = "수정버튼";
            this.수정버튼.Size = new System.Drawing.Size(100, 55);
            this.수정버튼.TabIndex = 52;
            this.수정버튼.Text = "수정";
            this.수정버튼.UseVisualStyleBackColor = true;
            this.수정버튼.Click += new System.EventHandler(this.수정버튼_Click);
            // 
            // 공급업체
            // 
            this.공급업체.Location = new System.Drawing.Point(148, 190);
            this.공급업체.Margin = new System.Windows.Forms.Padding(2);
            this.공급업체.Name = "공급업체";
            this.공급업체.Size = new System.Drawing.Size(149, 25);
            this.공급업체.TabIndex = 78;
            // 
            // 공급_업체
            // 
            this.공급_업체.AutoSize = true;
            this.공급_업체.Font = new System.Drawing.Font("궁서체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.공급_업체.Location = new System.Drawing.Point(42, 194);
            this.공급_업체.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.공급_업체.Name = "공급_업체";
            this.공급_업체.Size = new System.Drawing.Size(89, 20);
            this.공급_업체.TabIndex = 77;
            this.공급_업체.Text = "공급업체";
            // 
            // 유통기한
            // 
            this.유통기한.Location = new System.Drawing.Point(148, 285);
            this.유통기한.Margin = new System.Windows.Forms.Padding(2);
            this.유통기한.Name = "유통기한";
            this.유통기한.Size = new System.Drawing.Size(161, 25);
            this.유통기한.TabIndex = 75;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("궁서체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(41, 286);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 20);
            this.label6.TabIndex = 74;
            this.label6.Text = "유통기한";
            // 
            // 상품이름
            // 
            this.상품이름.Location = new System.Drawing.Point(148, 90);
            this.상품이름.Margin = new System.Windows.Forms.Padding(2);
            this.상품이름.Name = "상품이름";
            this.상품이름.Size = new System.Drawing.Size(149, 25);
            this.상품이름.TabIndex = 71;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("궁서체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label5.Location = new System.Drawing.Point(41, 94);
            this.Label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(89, 20);
            this.Label5.TabIndex = 70;
            this.Label5.Text = "상품이름";
            // 
            // 비고
            // 
            this.비고.Location = new System.Drawing.Point(148, 408);
            this.비고.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.비고.Multiline = true;
            this.비고.Name = "비고";
            this.비고.Size = new System.Drawing.Size(383, 81);
            this.비고.TabIndex = 69;
            // 
            // 카테고리
            // 
            this.카테고리.FormattingEnabled = true;
            this.카테고리.Items.AddRange(new object[] {
            "음료",
            "스낵",
            "즉석식품",
            "유제품",
            "가공식품",
            "생활용품",
            "주류",
            "담배",
            "뷰티",
            "기타"});
            this.카테고리.Location = new System.Drawing.Point(148, 240);
            this.카테고리.Margin = new System.Windows.Forms.Padding(2);
            this.카테고리.Name = "카테고리";
            this.카테고리.Size = new System.Drawing.Size(149, 23);
            this.카테고리.TabIndex = 68;
            // 
            // 등록가격
            // 
            this.등록가격.Location = new System.Drawing.Point(148, 145);
            this.등록가격.Margin = new System.Windows.Forms.Padding(2);
            this.등록가격.Name = "등록가격";
            this.등록가격.Size = new System.Drawing.Size(149, 25);
            this.등록가격.TabIndex = 67;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("궁서", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(80, 408);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 66;
            this.label4.Text = "비고";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("궁서체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(41, 240);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 65;
            this.label3.Text = "카테고리";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("궁서체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(42, 145);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 64;
            this.label2.Text = "등록가격";
            // 
            // 상품수량
            // 
            this.상품수량.Location = new System.Drawing.Point(148, 339);
            this.상품수량.Margin = new System.Windows.Forms.Padding(2);
            this.상품수량.Name = "상품수량";
            this.상품수량.Size = new System.Drawing.Size(149, 25);
            this.상품수량.TabIndex = 81;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("궁서체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(42, 339);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 20);
            this.label7.TabIndex = 80;
            this.label7.Text = "상품 수량";
            // 
            // 수정창
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 697);
            this.Controls.Add(this.상품수량);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.공급업체);
            this.Controls.Add(this.공급_업체);
            this.Controls.Add(this.유통기한);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.상품이름);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.비고);
            this.Controls.Add(this.카테고리);
            this.Controls.Add(this.등록가격);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.수정버튼);
            this.Controls.Add(this.수정);
            this.Name = "수정창";
            this.Text = "수정";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label 수정;
        private System.Windows.Forms.Button 수정버튼;
        private System.Windows.Forms.TextBox 공급업체;
        private System.Windows.Forms.Label 공급_업체;
        private System.Windows.Forms.DateTimePicker 유통기한;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox 상품이름;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.TextBox 비고;
        private System.Windows.Forms.ComboBox 카테고리;
        private System.Windows.Forms.TextBox 등록가격;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox 상품수량;
        private System.Windows.Forms.Label label7;
    }
}