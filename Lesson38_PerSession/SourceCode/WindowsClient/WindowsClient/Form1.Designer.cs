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
            this.btnInvokeService = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnInvokeService
            // 
            this.btnInvokeService.Location = new System.Drawing.Point(165, 106);
            this.btnInvokeService.Name = "btnInvokeService";
            this.btnInvokeService.Size = new System.Drawing.Size(330, 23);
            this.btnInvokeService.TabIndex = 0;
            this.btnInvokeService.Text = "Invoke Service";
            this.btnInvokeService.UseVisualStyleBackColor = true;
            this.btnInvokeService.Click += new System.EventHandler(this.btnInvokeService_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnInvokeService);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInvokeService;
    }
}

