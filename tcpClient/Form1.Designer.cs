namespace tcpClient
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.InputButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.LocalPort = new System.Windows.Forms.TextBox();
            this.RemotePort = new System.Windows.Forms.TextBox();
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(228, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(280, 22);
            this.textBox1.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(41, 175);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(715, 235);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(228, 85);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(279, 30);
            this.SendButton.TabIndex = 2;
            this.SendButton.Text = "отправить сообщение";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // InputButton
            // 
            this.InputButton.Location = new System.Drawing.Point(41, 85);
            this.InputButton.Name = "InputButton";
            this.InputButton.Size = new System.Drawing.Size(118, 79);
            this.InputButton.TabIndex = 3;
            this.InputButton.Text = "вход";
            this.InputButton.UseVisualStyleBackColor = true;
            this.InputButton.Click += new System.EventHandler(this.InputButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(586, 85);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(121, 79);
            this.CloseButton.TabIndex = 4;
            this.CloseButton.Text = "выход";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // LocalPort
            // 
            this.LocalPort.Location = new System.Drawing.Point(49, 25);
            this.LocalPort.Name = "LocalPort";
            this.LocalPort.Size = new System.Drawing.Size(94, 22);
            this.LocalPort.TabIndex = 5;
            this.LocalPort.TextChanged += new System.EventHandler(this.LocalPort_TextChanged);
            // 
            // RemotePort
            // 
            this.RemotePort.Location = new System.Drawing.Point(595, 24);
            this.RemotePort.Name = "RemotePort";
            this.RemotePort.Size = new System.Drawing.Size(101, 22);
            this.RemotePort.TabIndex = 6;
            this.RemotePort.TextChanged += new System.EventHandler(this.RemotePort_TextChanged);
            // 
            // ipTextBox
            // 
            this.ipTextBox.Location = new System.Drawing.Point(360, 416);
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.Size = new System.Drawing.Size(208, 22);
            this.ipTextBox.TabIndex = 7;
            this.ipTextBox.TextChanged += new System.EventHandler(this.ipTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(332, 424);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Ip";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ipTextBox);
            this.Controls.Add(this.RemotePort);
            this.Controls.Add(this.LocalPort);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.InputButton);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox ipTextBox;
        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.TextBox LocalPort;
        private System.Windows.Forms.TextBox RemotePort;

        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button InputButton;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.TextBox textBox1;

        #endregion
    }
}