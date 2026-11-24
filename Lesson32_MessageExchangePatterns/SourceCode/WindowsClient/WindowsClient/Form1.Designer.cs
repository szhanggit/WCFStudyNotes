namespace WindowsClient
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
            this.btnRequestReplyOperation = new System.Windows.Forms.Button();
            this.btnRequestReplyOperation_ThrowsException = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnRequestReplyOperation
            // 
            this.btnRequestReplyOperation.Location = new System.Drawing.Point(77, 250);
            this.btnRequestReplyOperation.Name = "btnRequestReplyOperation";
            this.btnRequestReplyOperation.Size = new System.Drawing.Size(625, 33);
            this.btnRequestReplyOperation.TabIndex = 1;
            this.btnRequestReplyOperation.Text = "Request Reply Operation";
            this.btnRequestReplyOperation.UseVisualStyleBackColor = true;
            this.btnRequestReplyOperation.Click += new System.EventHandler(this.btnRequestReplyOperation_Click);
            // 
            // btnRequestReplyOperation_ThrowsException
            // 
            this.btnRequestReplyOperation_ThrowsException.Location = new System.Drawing.Point(77, 289);
            this.btnRequestReplyOperation_ThrowsException.Name = "btnRequestReplyOperation_ThrowsException";
            this.btnRequestReplyOperation_ThrowsException.Size = new System.Drawing.Size(625, 33);
            this.btnRequestReplyOperation_ThrowsException.TabIndex = 2;
            this.btnRequestReplyOperation_ThrowsException.Text = "Request Reply Operation - ThrowsException";
            this.btnRequestReplyOperation_ThrowsException.UseVisualStyleBackColor = true;
            this.btnRequestReplyOperation_ThrowsException.Click += new System.EventHandler(this.btnRequestReplyOperation_ThrowsException_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(77, 328);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(625, 32);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(77, 26);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(625, 199);
            this.listBox1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnRequestReplyOperation_ThrowsException);
            this.Controls.Add(this.btnRequestReplyOperation);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnRequestReplyOperation;
        private System.Windows.Forms.Button btnRequestReplyOperation_ThrowsException;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ListBox listBox1;
    }
}

