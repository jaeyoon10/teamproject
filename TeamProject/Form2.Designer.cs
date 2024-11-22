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
            this.label1 = new System.Windows.Forms.Label();
            this.등록ID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.유통기한 = new System.Windows.Forms.DateTimePicker();
            this.점주 = new System.Windows.Forms.Label();
            this.공급_업체 = new System.Windows.Forms.Label();
            this.공급업체 = new System.Windows.Forms.TextBox();
            this.점주ID = new System.Windows.Forms.TextBox();
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
            this.카테고리.Location = new System.Drawing.Point(167, 322);
            this.카테고리.Name = "카테고리";
            this.카테고리.Size = new System.Drawing.Size(185, 26);
            this.카테고리.TabIndex = 44;
            // 
            // 등록가격
            // 
            this.등록가격.Location = new System.Drawing.Point(167, 152);
            this.등록가격.Name = "등록가격";
            this.등록가격.Size = new System.Drawing.Size(185, 28);
            this.등록가격.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("궁서", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(82, 431);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 24);
            this.label4.TabIndex = 35;
            this.label4.Text = "비고";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("궁서체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(34, 322);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 24);
            this.label3.TabIndex = 34;
            this.label3.Text = "카테고리";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("궁서체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(35, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 24);
            this.label2.TabIndex = 33;
            this.label2.Text = "등록가격";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(273, 601);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 66);
            this.btnSave.TabIndex = 51;
            this.btnSave.Text = "등록";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.등록버튼_Click);
            // 
            // 비고
            // 
            this.비고.Location = new System.Drawing.Point(167, 431);
            this.비고.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.비고.Multiline = true;
            this.비고.Name = "비고";
            this.비고.Size = new System.Drawing.Size(478, 96);
            this.비고.TabIndex = 52;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("궁서체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label5.Location = new System.Drawing.Point(34, 91);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(106, 24);
            this.Label5.TabIndex = 53;
            this.Label5.Text = "상품이름";
            // 
            // 상품이름
            // 
            this.상품이름.Location = new System.Drawing.Point(167, 87);
            this.상품이름.Name = "상품이름";
            this.상품이름.Size = new System.Drawing.Size(185, 28);
            this.상품이름.TabIndex = 54;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("궁서체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(46, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 24);
            this.label1.TabIndex = 55;
            this.label1.Text = "등록 ID";
            // 
            // 등록ID
            // 
            this.등록ID.Location = new System.Drawing.Point(167, 25);
            this.등록ID.Name = "등록ID";
            this.등록ID.Size = new System.Drawing.Size(185, 28);
            this.등록ID.TabIndex = 56;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("궁서체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(34, 377);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 24);
            this.label6.TabIndex = 57;
            this.label6.Text = "유통기한";
            // 
            // 유통기한
            // 
            this.유통기한.Location = new System.Drawing.Point(167, 376);
            this.유통기한.Name = "유통기한";
            this.유통기한.Size = new System.Drawing.Size(200, 28);
            this.유통기한.TabIndex = 59;
            // 
            // 점주
            // 
            this.점주.AutoSize = true;
            this.점주.Font = new System.Drawing.Font("궁서체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.점주.Location = new System.Drawing.Point(46, 262);
            this.점주.Name = "점주";
            this.점주.Size = new System.Drawing.Size(94, 24);
            this.점주.TabIndex = 60;
            this.점주.Text = "점주 ID";
            // 
            // 공급_업체
            // 
            this.공급_업체.AutoSize = true;
            this.공급_업체.Font = new System.Drawing.Font("궁서체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.공급_업체.Location = new System.Drawing.Point(35, 211);
            this.공급_업체.Name = "공급_업체";
            this.공급_업체.Size = new System.Drawing.Size(106, 24);
            this.공급_업체.TabIndex = 61;
            this.공급_업체.Text = "공급업체";
            // 
            // 공급업체
            // 
            this.공급업체.Location = new System.Drawing.Point(167, 207);
            this.공급업체.Name = "공급업체";
            this.공급업체.Size = new System.Drawing.Size(185, 28);
            this.공급업체.TabIndex = 62;
            // 
            // 점주ID
            // 
            this.점주ID.Location = new System.Drawing.Point(167, 265);
            this.점주ID.Name = "점주ID";
            this.점주ID.Size = new System.Drawing.Size(185, 28);
            this.점주ID.TabIndex = 63;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 872);
            this.Controls.Add(this.점주ID);
            this.Controls.Add(this.공급업체);
            this.Controls.Add(this.공급_업체);
            this.Controls.Add(this.점주);
            this.Controls.Add(this.유통기한);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.등록ID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.상품이름);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.비고);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.카테고리);
            this.Controls.Add(this.등록가격);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox 등록ID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker 유통기한;
        private System.Windows.Forms.Label 점주;
        private System.Windows.Forms.Label 공급_업체;
        private System.Windows.Forms.TextBox 공급업체;
        private System.Windows.Forms.TextBox 점주ID;
    }
}