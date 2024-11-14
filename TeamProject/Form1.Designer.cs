namespace TeamProject
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.id = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.password = new System.Windows.Forms.Label();
            this.id_text = new System.Windows.Forms.TextBox();
            this.password_text = new System.Windows.Forms.TextBox();
            this.Login = new System.Windows.Forms.Button();
            this.convenience = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // id
            // 
            this.id.AutoSize = true;
            this.id.Font = new System.Drawing.Font("궁서체", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.id.Location = new System.Drawing.Point(480, 309);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(103, 30);
            this.id.TabIndex = 0;
            this.id.Text = "아이디";
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.Font = new System.Drawing.Font("궁서", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.password.Location = new System.Drawing.Point(450, 419);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(133, 30);
            this.password.TabIndex = 1;
            this.password.Text = "비밀번호";
            // 
            // id_text
            // 
            this.id_text.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.id_text.Location = new System.Drawing.Point(622, 300);
            this.id_text.Multiline = true;
            this.id_text.Name = "id_text";
            this.id_text.Size = new System.Drawing.Size(207, 39);
            this.id_text.TabIndex = 2;
            // 
            // password_text
            // 
            this.password_text.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.password_text.Location = new System.Drawing.Point(622, 410);
            this.password_text.Multiline = true;
            this.password_text.Name = "password_text";
            this.password_text.Size = new System.Drawing.Size(207, 39);
            this.password_text.TabIndex = 3;
            // 
            // Login
            // 
            this.Login.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Login.Font = new System.Drawing.Font("궁서체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Login.Location = new System.Drawing.Point(646, 506);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(165, 56);
            this.Login.TabIndex = 4;
            this.Login.Text = "로그인";
            this.Login.UseVisualStyleBackColor = false;
            this.Login.Click += new System.EventHandler(this.button1_Click);
            // 
            // convenience
            // 
            this.convenience.AutoSize = true;
            this.convenience.Font = new System.Drawing.Font("궁서체", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.convenience.Location = new System.Drawing.Point(445, 97);
            this.convenience.Name = "convenience";
            this.convenience.Size = new System.Drawing.Size(535, 60);
            this.convenience.TabIndex = 5;
            this.convenience.Text = "편의점 재고 관리 ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1418, 766);
            this.Controls.Add(this.convenience);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.password_text);
            this.Controls.Add(this.id_text);
            this.Controls.Add(this.password);
            this.Controls.Add(this.id);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label id;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.TextBox id_text;
        private System.Windows.Forms.TextBox password_text;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.Label convenience;
    }
}

