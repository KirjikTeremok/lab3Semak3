namespace telnetServer
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
            this.RemotePort = new System.Windows.Forms.TextBox();
            this.inputButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.testCommandTextBox = new System.Windows.Forms.TextBox();
            this.testButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // RemotePort
            // 
            this.RemotePort.Location = new System.Drawing.Point(12, 20);
            this.RemotePort.Name = "RemotePort";
            this.RemotePort.Size = new System.Drawing.Size(81, 22);
            this.RemotePort.TabIndex = 0;
            this.RemotePort.TextChanged += new System.EventHandler(this.RemotePort_TextChanged);
            // 
            // inputButton
            // 
            this.inputButton.Location = new System.Drawing.Point(155, 16);
            this.inputButton.Name = "inputButton";
            this.inputButton.Size = new System.Drawing.Size(74, 31);
            this.inputButton.TabIndex = 1;
            this.inputButton.Text = "вход";
            this.inputButton.UseVisualStyleBackColor = true;
            this.inputButton.Click += new System.EventHandler(this.inputButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(273, 13);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(66, 33);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "выход";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(60, 158);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(637, 260);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // testCommandTextBox
            // 
            this.testCommandTextBox.Location = new System.Drawing.Point(547, 17);
            this.testCommandTextBox.Name = "testCommandTextBox";
            this.testCommandTextBox.Size = new System.Drawing.Size(95, 22);
            this.testCommandTextBox.TabIndex = 4;
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(672, 13);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(93, 26);
            this.testButton.TabIndex = 5;
            this.testButton.Text = "тест";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.testCommandTextBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.inputButton);
            this.Controls.Add(this.RemotePort);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox testCommandTextBox;

        private System.Windows.Forms.Button testButton;

        private System.Windows.Forms.PictureBox pictureBox1;

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button inputButton;
        private System.Windows.Forms.TextBox RemotePort;

        #endregion
    }
}