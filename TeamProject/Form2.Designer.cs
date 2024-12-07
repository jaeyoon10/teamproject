namespace TeamProject
{
    partial class Form2
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
            this.카테고리 = new System.Windows.Forms.ComboBox();
            this.등록가격 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.비고 = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.상품이름 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.유통기한 = new System.Windows.Forms.DateTimePicker();
            this.점주 = new System.Windows.Forms.Label();
            this.공급_업체 = new System.Windows.Forms.Label();
            this.공급업체 = new System.Windows.Forms.TextBox();
            this.점주ID = new System.Windows.Forms.TextBox();
            this.상품수량 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.수정 = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.카테고리.Location = new System.Drawing.Point(134, 284);
            this.카테고리.Margin = new System.Windows.Forms.Padding(2);
            this.카테고리.Name = "카테고리";
            this.카테고리.Size = new System.Drawing.Size(149, 23);
            this.카테고리.TabIndex = 44;
            // 
            // 등록가격
            // 
            this.등록가격.Location = new System.Drawing.Point(134, 143);
            this.등록가격.Margin = new System.Windows.Forms.Padding(2);
            this.등록가격.Name = "등록가격";
            this.등록가격.Size = new System.Drawing.Size(149, 25);
            this.등록가격.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("궁서", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(66, 432);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 35;
            this.label4.Text = "비고";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("궁서체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(27, 284);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 34;
            this.label3.Text = "카테고리";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("궁서체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(28, 143);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 33;
            this.label2.Text = "등록가격";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(221, 546);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 55);
            this.btnSave.TabIndex = 51;
            this.btnSave.Text = "등록";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.등록버튼_Click);
            // 
            // 비고
            // 
            this.비고.Location = new System.Drawing.Point(134, 432);
            this.비고.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.비고.Multiline = true;
            this.비고.Name = "비고";
            this.비고.Size = new System.Drawing.Size(383, 81);
            this.비고.TabIndex = 52;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("궁서체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label5.Location = new System.Drawing.Point(27, 92);
            this.Label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(89, 20);
            this.Label5.TabIndex = 53;
            this.Label5.Text = "상품이름";
            // 
            // 상품이름
            // 
            this.상품이름.Location = new System.Drawing.Point(134, 88);
            this.상품이름.Margin = new System.Windows.Forms.Padding(2);
            this.상품이름.Name = "상품이름";
            this.상품이름.Size = new System.Drawing.Size(149, 25);
            this.상품이름.TabIndex = 54;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("궁서체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(27, 330);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 20);
            this.label6.TabIndex = 57;
            this.label6.Text = "유통기한";
            // 
            // 유통기한
            // 
            this.유통기한.Location = new System.Drawing.Point(134, 329);
            this.유통기한.Margin = new System.Windows.Forms.Padding(2);
            this.유통기한.Name = "유통기한";
            this.유통기한.Size = new System.Drawing.Size(161, 25);
            this.유통기한.TabIndex = 59;
            // 
            // 점주
            // 
            this.점주.AutoSize = true;
            this.점주.Font = new System.Drawing.Font("궁서체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.점주.Location = new System.Drawing.Point(37, 234);
            this.점주.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.점주.Name = "점주";
            this.점주.Size = new System.Drawing.Size(79, 20);
            this.점주.TabIndex = 60;
            this.점주.Text = "점주 ID";
            // 
            // 공급_업체
            // 
            this.공급_업체.AutoSize = true;
            this.공급_업체.Font = new System.Drawing.Font("궁서체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.공급_업체.Location = new System.Drawing.Point(28, 192);
            this.공급_업체.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.공급_업체.Name = "공급_업체";
            this.공급_업체.Size = new System.Drawing.Size(89, 20);
            this.공급_업체.TabIndex = 61;
            this.공급_업체.Text = "공급업체";
            // 
            // 공급업체
            // 
            this.공급업체.Location = new System.Drawing.Point(134, 188);
            this.공급업체.Margin = new System.Windows.Forms.Padding(2);
            this.공급업체.Name = "공급업체";
            this.공급업체.Size = new System.Drawing.Size(149, 25);
            this.공급업체.TabIndex = 62;
            // 
            // 점주ID
            // 
            this.점주ID.Location = new System.Drawing.Point(134, 237);
            this.점주ID.Margin = new System.Windows.Forms.Padding(2);
            this.점주ID.Name = "점주ID";
            this.점주ID.Size = new System.Drawing.Size(149, 25);
            this.점주ID.TabIndex = 63;
            // 
            // 상품수량
            // 
            this.상품수량.Location = new System.Drawing.Point(134, 378);
            this.상품수량.Margin = new System.Windows.Forms.Padding(2);
            this.상품수량.Name = "상품수량";
            this.상품수량.Size = new System.Drawing.Size(149, 25);
            this.상품수량.TabIndex = 83;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("궁서체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(28, 378);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 20);
            this.label7.TabIndex = 82;
            this.label7.Text = "상품 수량";
            // 
            // 수정
            // 
            this.수정.AutoSize = true;
            this.수정.Font = new System.Drawing.Font("궁서체", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.수정.Location = new System.Drawing.Point(166, 9);
            this.수정.Name = "수정";
            this.수정.Size = new System.Drawing.Size(236, 47);
            this.수정.TabIndex = 84;
            this.수정.Text = "상품 등록";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 646);
            this.Controls.Add(this.수정);
            this.Controls.Add(this.상품수량);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.점주ID);
            this.Controls.Add(this.공급업체);
            this.Controls.Add(this.공급_업체);
            this.Controls.Add(this.점주);
            this.Controls.Add(this.유통기한);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.상품이름);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.비고);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.카테고리);
            this.Controls.Add(this.등록가격);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox 카테고리;
        private System.Windows.Forms.TextBox 등록가격;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox 비고;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.TextBox 상품이름;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker 유통기한;
        private System.Windows.Forms.Label 점주;
        private System.Windows.Forms.Label 공급_업체;
        private System.Windows.Forms.TextBox 공급업체;
        private System.Windows.Forms.TextBox 점주ID;
        private System.Windows.Forms.TextBox 상품수량;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label 수정;
    }
}