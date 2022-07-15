namespace BatchIconReplace
{
    partial class Form1
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
            this.btnIconFolder = new System.Windows.Forms.Button();
            this.newIconFolder = new System.Windows.Forms.TextBox();
            this.textbox2 = new System.Windows.Forms.TextBox();
            this.btnHongqueFolder = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnIconFolder
            // 
            this.btnIconFolder.Location = new System.Drawing.Point(129, 94);
            this.btnIconFolder.Name = "btnIconFolder";
            this.btnIconFolder.Size = new System.Drawing.Size(233, 23);
            this.btnIconFolder.TabIndex = 0;
            this.btnIconFolder.Text = "确认新图标的文件夹";
            this.btnIconFolder.UseVisualStyleBackColor = true;
            this.btnIconFolder.Click += new System.EventHandler(this.button1_Click);
            // 
            // newIconFolder
            // 
            this.newIconFolder.Location = new System.Drawing.Point(56, 42);
            this.newIconFolder.Name = "newIconFolder";
            this.newIconFolder.Size = new System.Drawing.Size(416, 20);
            this.newIconFolder.TabIndex = 1;
            this.newIconFolder.Text = "C:\\Project\\【11月闪联版】\\【2017年六月开发】\\【珑icon】";
            // 
            // textbox2
            // 
            this.textbox2.Location = new System.Drawing.Point(56, 184);
            this.textbox2.Name = "textbox2";
            this.textbox2.Size = new System.Drawing.Size(416, 20);
            this.textbox2.TabIndex = 3;
            this.textbox2.Text = "C:\\Project\\Muffin_Domestic_Advance";
            // 
            // btnHongqueFolder
            // 
            this.btnHongqueFolder.Location = new System.Drawing.Point(129, 233);
            this.btnHongqueFolder.Name = "btnHongqueFolder";
            this.btnHongqueFolder.Size = new System.Drawing.Size(275, 23);
            this.btnHongqueFolder.TabIndex = 5;
            this.btnHongqueFolder.Text = "确认红雀工程文件夹";
            this.btnHongqueFolder.UseVisualStyleBackColor = true;
            this.btnHongqueFolder.Click += new System.EventHandler(this.btnHongqueFolder_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(129, 389);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(192, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "换图标(包括安卓和ios)";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 482);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnHongqueFolder);
            this.Controls.Add(this.textbox2);
            this.Controls.Add(this.newIconFolder);
            this.Controls.Add(this.btnIconFolder);
            this.Name = "Form1";
            this.Text = "批量图标替换";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIconFolder;
        private System.Windows.Forms.TextBox newIconFolder;
        private System.Windows.Forms.TextBox textbox2;
        private System.Windows.Forms.Button btnHongqueFolder;
        private System.Windows.Forms.Button button4;
    }
}

