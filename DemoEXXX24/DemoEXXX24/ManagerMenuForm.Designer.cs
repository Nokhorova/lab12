namespace DemoEXXX24
{
    partial class ManagerMenuForm
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
            this.ClientsButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ClientsButton
            // 
            this.ClientsButton.Location = new System.Drawing.Point(97, 52);
            this.ClientsButton.Margin = new System.Windows.Forms.Padding(4);
            this.ClientsButton.Name = "ClientsButton";
            this.ClientsButton.Size = new System.Drawing.Size(100, 28);
            this.ClientsButton.TabIndex = 0;
            this.ClientsButton.Text = "Клиенты";
            this.ClientsButton.UseVisualStyleBackColor = true;
            this.ClientsButton.Click += new System.EventHandler(this.ClientsButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(97, 87);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "Заявки";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(17, 2);
            this.labelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(0, 16);
            this.labelName.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(97, 123);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 3;
            this.button2.Text = "Статистика";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ManagerMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 263);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ClientsButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ManagerMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MangerMenuForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ClientsButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button button2;
    }
}