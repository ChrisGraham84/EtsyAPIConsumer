namespace EtsyApiConsumer
{
    partial class DesignAdd
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtDesignNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDefaultColor = new System.Windows.Forms.TextBox();
            this.btnAddNewDesign = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Design Number";
            // 
            // txtDesignNumber
            // 
            this.txtDesignNumber.Location = new System.Drawing.Point(143, 10);
            this.txtDesignNumber.Name = "txtDesignNumber";
            this.txtDesignNumber.Size = new System.Drawing.Size(245, 22);
            this.txtDesignNumber.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Default Color";
            // 
            // txtDefaultColor
            // 
            this.txtDefaultColor.Location = new System.Drawing.Point(143, 38);
            this.txtDefaultColor.Name = "txtDefaultColor";
            this.txtDefaultColor.Size = new System.Drawing.Size(245, 22);
            this.txtDefaultColor.TabIndex = 3;
            // 
            // btnAddNewDesign
            // 
            this.btnAddNewDesign.Location = new System.Drawing.Point(143, 78);
            this.btnAddNewDesign.Name = "btnAddNewDesign";
            this.btnAddNewDesign.Size = new System.Drawing.Size(98, 37);
            this.btnAddNewDesign.TabIndex = 4;
            this.btnAddNewDesign.Text = "Add";
            this.btnAddNewDesign.UseVisualStyleBackColor = true;
            this.btnAddNewDesign.Click += new System.EventHandler(this.btnAddNewDesign_Click);
            // 
            // DesignAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 141);
            this.Controls.Add(this.btnAddNewDesign);
            this.Controls.Add(this.txtDefaultColor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDesignNumber);
            this.Controls.Add(this.label1);
            this.Name = "DesignAdd";
            this.Text = "Design Add";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DesignAdd_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDesignNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDefaultColor;
        private System.Windows.Forms.Button btnAddNewDesign;
    }
}