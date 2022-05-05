
namespace Chapter19_WebPractice
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
            this.httpRequest = new System.Windows.Forms.TextBox();
            this.pageCode = new System.Windows.Forms.TextBox();
            this.downloadB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // httpRequest
            // 
            this.httpRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.httpRequest.Location = new System.Drawing.Point(12, 12);
            this.httpRequest.Name = "httpRequest";
            this.httpRequest.Size = new System.Drawing.Size(1119, 26);
            this.httpRequest.TabIndex = 0;
            this.httpRequest.Enter += new System.EventHandler(this.httpRequest_Enter);
            // 
            // pageCode
            // 
            this.pageCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pageCode.Location = new System.Drawing.Point(12, 44);
            this.pageCode.Multiline = true;
            this.pageCode.Name = "pageCode";
            this.pageCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.pageCode.Size = new System.Drawing.Size(1212, 684);
            this.pageCode.TabIndex = 1;
            // 
            // downloadB
            // 
            this.downloadB.Location = new System.Drawing.Point(1137, 12);
            this.downloadB.Name = "downloadB";
            this.downloadB.Size = new System.Drawing.Size(87, 26);
            this.downloadB.TabIndex = 2;
            this.downloadB.Text = "Загрузить";
            this.downloadB.UseVisualStyleBackColor = true;
            this.downloadB.Click += new System.EventHandler(this.downloadB_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 740);
            this.Controls.Add(this.downloadB);
            this.Controls.Add(this.pageCode);
            this.Controls.Add(this.httpRequest);
            this.Name = "Form2";
            this.Text = "Form2";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox httpRequest;
        private System.Windows.Forms.TextBox pageCode;
        private System.Windows.Forms.Button downloadB;
    }
}