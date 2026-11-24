namespace WindowsFormClient
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
            this.btnGetEvenNumbers = new System.Windows.Forms.Button();
            this.btnGetOddNumbers = new System.Windows.Forms.Button();
            this.btnClearResults = new System.Windows.Forms.Button();
            this.listBoxEvenNumbers = new System.Windows.Forms.ListBox();
            this.listBoxOddNumbers = new System.Windows.Forms.ListBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // btnGetEvenNumbers
            // 
            this.btnGetEvenNumbers.Location = new System.Drawing.Point(117, 30);
            this.btnGetEvenNumbers.Name = "btnGetEvenNumbers";
            this.btnGetEvenNumbers.Size = new System.Drawing.Size(172, 23);
            this.btnGetEvenNumbers.TabIndex = 0;
            this.btnGetEvenNumbers.Text = "Get Even Numbers";
            this.btnGetEvenNumbers.UseVisualStyleBackColor = true;
            this.btnGetEvenNumbers.Click += new System.EventHandler(this.btnGetEvenNumbers_Click);
            // 
            // btnGetOddNumbers
            // 
            this.btnGetOddNumbers.Location = new System.Drawing.Point(364, 30);
            this.btnGetOddNumbers.Name = "btnGetOddNumbers";
            this.btnGetOddNumbers.Size = new System.Drawing.Size(174, 23);
            this.btnGetOddNumbers.TabIndex = 1;
            this.btnGetOddNumbers.Text = "Get Odd Numbers";
            this.btnGetOddNumbers.UseVisualStyleBackColor = true;
            this.btnGetOddNumbers.Click += new System.EventHandler(this.btnGetOddNumbers_Click);
            // 
            // btnClearResults
            // 
            this.btnClearResults.Location = new System.Drawing.Point(117, 392);
            this.btnClearResults.Name = "btnClearResults";
            this.btnClearResults.Size = new System.Drawing.Size(421, 23);
            this.btnClearResults.TabIndex = 2;
            this.btnClearResults.Text = "Clear Results";
            this.btnClearResults.UseVisualStyleBackColor = true;
            this.btnClearResults.Click += new System.EventHandler(this.btnClearResults_Click);
            // 
            // listBoxEvenNumbers
            // 
            this.listBoxEvenNumbers.FormattingEnabled = true;
            this.listBoxEvenNumbers.Location = new System.Drawing.Point(117, 78);
            this.listBoxEvenNumbers.Name = "listBoxEvenNumbers";
            this.listBoxEvenNumbers.Size = new System.Drawing.Size(172, 290);
            this.listBoxEvenNumbers.TabIndex = 3;
            // 
            // listBoxOddNumbers
            // 
            this.listBoxOddNumbers.FormattingEnabled = true;
            this.listBoxOddNumbers.Location = new System.Drawing.Point(366, 78);
            this.listBoxOddNumbers.Name = "listBoxOddNumbers";
            this.listBoxOddNumbers.Size = new System.Drawing.Size(172, 290);
            this.listBoxOddNumbers.TabIndex = 4;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBoxOddNumbers);
            this.Controls.Add(this.listBoxEvenNumbers);
            this.Controls.Add(this.btnClearResults);
            this.Controls.Add(this.btnGetOddNumbers);
            this.Controls.Add(this.btnGetEvenNumbers);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetEvenNumbers;
        private System.Windows.Forms.Button btnGetOddNumbers;
        private System.Windows.Forms.Button btnClearResults;
        private System.Windows.Forms.ListBox listBoxEvenNumbers;
        private System.Windows.Forms.ListBox listBoxOddNumbers;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}

