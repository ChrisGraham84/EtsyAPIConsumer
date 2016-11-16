namespace EtsyApiConsumer
{
    partial class AddColor
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
            this.btnAddNewColor = new System.Windows.Forms.Button();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.lblColor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAddNewColor
            // 
            this.btnAddNewColor.Location = new System.Drawing.Point(110, 44);
            this.btnAddNewColor.Name = "btnAddNewColor";
            this.btnAddNewColor.Size = new System.Drawing.Size(98, 37);
            this.btnAddNewColor.TabIndex = 7;
            this.btnAddNewColor.Text = "Add";
            this.btnAddNewColor.UseVisualStyleBackColor = true;
            this.btnAddNewColor.Click += new System.EventHandler(this.btnAddNewColor_Click);
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(59, 6);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(245, 22);
            this.txtColor.TabIndex = 6;
            this.txtColor.TextChanged += new System.EventHandler(this.txtColor_TextChanged);
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(12, 9);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(41, 17);
            this.lblColor.TabIndex = 5;
            this.lblColor.Text = "Color";
            this.lblColor.Click += new System.EventHandler(this.lblColor_Click);
            // 
            // AddColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 93);
            this.Controls.Add(this.btnAddNewColor);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.lblColor);
            this.Name = "AddColor";
            this.Text = "Add Color";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddColor_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddNewColor;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label lblColor;
    }
}