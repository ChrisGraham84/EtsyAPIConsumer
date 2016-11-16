namespace EtsyApiConsumer
{
    partial class AddStyle
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
            this.btnAddNewStyle = new System.Windows.Forms.Button();
            this.txtStyle = new System.Windows.Forms.TextBox();
            this.lblStyle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblEtsyDescription = new System.Windows.Forms.Label();
            this.txtEtsyDescription = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAddNewStyle
            // 
            this.btnAddNewStyle.Location = new System.Drawing.Point(128, 93);
            this.btnAddNewStyle.Name = "btnAddNewStyle";
            this.btnAddNewStyle.Size = new System.Drawing.Size(98, 37);
            this.btnAddNewStyle.TabIndex = 10;
            this.btnAddNewStyle.Text = "Add";
            this.btnAddNewStyle.UseVisualStyleBackColor = true;
            this.btnAddNewStyle.Click += new System.EventHandler(this.btnAddNewStyle_Click);
            // 
            // txtStyle
            // 
            this.txtStyle.Location = new System.Drawing.Point(128, 12);
            this.txtStyle.Name = "txtStyle";
            this.txtStyle.Size = new System.Drawing.Size(245, 22);
            this.txtStyle.TabIndex = 9;
            // 
            // lblStyle
            // 
            this.lblStyle.AutoSize = true;
            this.lblStyle.Location = new System.Drawing.Point(12, 15);
            this.lblStyle.Name = "lblStyle";
            this.lblStyle.Size = new System.Drawing.Size(39, 17);
            this.lblStyle.TabIndex = 8;
            this.lblStyle.Text = "Style";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 43);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(79, 17);
            this.lblDescription.TabIndex = 8;
            this.lblDescription.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(128, 40);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(245, 22);
            this.txtDescription.TabIndex = 9;
            // 
            // lblEtsyDescription
            // 
            this.lblEtsyDescription.AutoSize = true;
            this.lblEtsyDescription.Location = new System.Drawing.Point(12, 71);
            this.lblEtsyDescription.Name = "lblEtsyDescription";
            this.lblEtsyDescription.Size = new System.Drawing.Size(110, 17);
            this.lblEtsyDescription.TabIndex = 8;
            this.lblEtsyDescription.Text = "Etsy Description";
            // 
            // txtEtsyDescription
            // 
            this.txtEtsyDescription.Location = new System.Drawing.Point(128, 66);
            this.txtEtsyDescription.Name = "txtEtsyDescription";
            this.txtEtsyDescription.Size = new System.Drawing.Size(245, 22);
            this.txtEtsyDescription.TabIndex = 9;
            // 
            // AddStyle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 142);
            this.Controls.Add(this.btnAddNewStyle);
            this.Controls.Add(this.txtEtsyDescription);
            this.Controls.Add(this.lblEtsyDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtStyle);
            this.Controls.Add(this.lblStyle);
            this.Name = "AddStyle";
            this.Text = "Add Style";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddStyle_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddNewStyle;
        private System.Windows.Forms.TextBox txtStyle;
        private System.Windows.Forms.Label lblStyle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblEtsyDescription;
        private System.Windows.Forms.TextBox txtEtsyDescription;
    }
}