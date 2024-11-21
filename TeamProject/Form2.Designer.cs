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
            this.등록날짜 = new System.Windows.Forms.DateTimePicker();
            this.카테고리 = new System.Windows.Forms.ComboBox();
            this.등록가격 = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.등록 = new System.Windows.Forms.Button();
            this.비고 = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.상품이름 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // 등록날짜
            // 
            this.등록날짜.Location = new System.Drawing.Point(167, 32);
            this.등록날짜.Name = "등록날짜";
            this.등록날짜.Size = new System.Drawing.Size(523, 28);
            this.등록날짜.TabIndex = 45;
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
            this.카테고리.Location = new System.Drawing.Point(167, 150);
            this.카테고리.Name = "카테고리";
            this.카테고리.Size = new System.Drawing.Size(185, 26);
            this.카테고리.TabIndex = 44;
            // 
            // 등록가격
            // 
            this.등록가격.Location = new System.Drawing.Point(167, 207);
            this.등록가격.Name = "등록가격";
            this.등록가격.Size = new System.Drawing.Size(185, 28);
            this.등록가격.TabIndex = 42;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("궁서체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label1.Location = new System.Drawing.Point(34, 32);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(118, 24);
            this.Label1.TabIndex = 41;
            this.Label1.Text = "등록 날짜";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("궁서", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(83, 358);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 24);
            this.label4.TabIndex = 35;
            this.label4.Text = "비고";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("궁서체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(34, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 24);
            this.label3.TabIndex = 34;
            this.label3.Text = "카테고리";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("궁서체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(23, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 24);
            this.label2.TabIndex = 33;
            this.label2.Text = "등록 가격";
            // 
            // 등록
            // 
            this.등록.Location = new System.Drawing.Point(276, 552);
            this.등록.Name = "등록";
            this.등록.Size = new System.Drawing.Size(126, 66);
            this.등록.TabIndex = 51;
            this.등록.Text = "등록";
            this.등록.UseVisualStyleBackColor = true;
            this.등록.Click += new System.EventHandler(this.button3_Click);
            // 
            // 비고
            // 
            this.비고.Location = new System.Drawing.Point(167, 358);
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
            this.Label5.Location = new System.Drawing.Point(23, 91);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(118, 24);
            this.Label5.TabIndex = 53;
            this.Label5.Text = "상품 이름";
            // 
            // 상품이름
            // 
            this.상품이름.Location = new System.Drawing.Point(167, 87);
            this.상품이름.Name = "상품이름";
            this.상품이름.Size = new System.Drawing.Size(185, 28);
            this.상품이름.TabIndex = 54;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 872);
            this.Controls.Add(this.상품이름);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.비고);
            this.Controls.Add(this.등록);
            this.Controls.Add(this.등록날짜);
            this.Controls.Add(this.카테고리);
            this.Controls.Add(this.등록가격);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker 등록날짜;
        private System.Windows.Forms.ComboBox 카테고리;
        private System.Windows.Forms.TextBox 등록가격;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button 등록;
        private System.Windows.Forms.TextBox 비고;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.TextBox 상품이름;
    }
}