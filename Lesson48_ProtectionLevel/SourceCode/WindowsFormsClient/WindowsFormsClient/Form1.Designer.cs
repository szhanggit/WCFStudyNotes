namespace WindowsFormsClient
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
            this.btnGetMessage = new System.Windows.Forms.Button();
            this.btnGetSignedMessage = new System.Windows.Forms.Button();
            this.btnGetSignedEncryptedMessage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetMessage
            // 
            this.btnGetMessage.Location = new System.Drawing.Point(162, 128);
            this.btnGetMessage.Name = "btnGetMessage";
            this.btnGetMessage.Size = new System.Drawing.Size(467, 23);
            this.btnGetMessage.TabIndex = 0;
            this.btnGetMessage.Text = "Get Message - Not Signed and Not Encrypted";
            this.btnGetMessage.UseVisualStyleBackColor = true;
            this.btnGetMessage.Click += new System.EventHandler(this.btnGetMessage_Click);
            // 
            // btnGetSignedMessage
            // 
            this.btnGetSignedMessage.Location = new System.Drawing.Point(162, 197);
            this.btnGetSignedMessage.Name = "btnGetSignedMessage";
            this.btnGetSignedMessage.Size = new System.Drawing.Size(467, 23);
            this.btnGetSignedMessage.TabIndex = 1;
            this.btnGetSignedMessage.Text = "Get Message - Signed but Not Encrypted";
            this.btnGetSignedMessage.UseVisualStyleBackColor = true;
            this.btnGetSignedMessage.Click += new System.EventHandler(this.btnGetSignedMessage_Click);
            // 
            // btnGetSignedEncryptedMessage
            // 
            this.btnGetSignedEncryptedMessage.Location = new System.Drawing.Point(162, 272);
            this.btnGetSignedEncryptedMessage.Name = "btnGetSignedEncryptedMessage";
            this.btnGetSignedEncryptedMessage.Size = new System.Drawing.Size(467, 23);
            this.btnGetSignedEncryptedMessage.TabIndex = 2;
            this.btnGetSignedEncryptedMessage.Text = "Get Message - Signed and Encrypted";
            this.btnGetSignedEncryptedMessage.UseVisualStyleBackColor = true;
            this.btnGetSignedEncryptedMessage.Click += new System.EventHandler(this.btnGetSignedEncryptedMessage_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGetSignedEncryptedMessage);
            this.Controls.Add(this.btnGetSignedMessage);
            this.Controls.Add(this.btnGetMessage);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetMessage;
        private System.Windows.Forms.Button btnGetSignedMessage;
        private System.Windows.Forms.Button btnGetSignedEncryptedMessage;
    }
}

