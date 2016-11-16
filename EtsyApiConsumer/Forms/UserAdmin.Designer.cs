namespace EtsyApiConsumer
{
    partial class UserAdmin
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
            this.cmbClients = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grpStyles = new System.Windows.Forms.GroupBox();
            this.txtEtsyDescription = new System.Windows.Forms.TextBox();
            this.lblEtsyDescription = new System.Windows.Forms.Label();
            this.txtStyleDescription = new System.Windows.Forms.TextBox();
            this.lblStyleDescription = new System.Windows.Forms.Label();
            this.lbStyles = new System.Windows.Forms.ListBox();
            this.btnStyleRemove = new System.Windows.Forms.Button();
            this.btnStyleAdd = new System.Windows.Forms.Button();
            this.grpbDesigns = new System.Windows.Forms.GroupBox();
            this.btnColorRemove = new System.Windows.Forms.Button();
            this.btnDesignRemove = new System.Windows.Forms.Button();
            this.lbDesignColors = new System.Windows.Forms.ListBox();
            this.brtnColorAd = new System.Windows.Forms.Button();
            this.btnDesignAdd = new System.Windows.Forms.Button();
            this.lblColors = new System.Windows.Forms.Label();
            this.lbDesigns = new System.Windows.Forms.ListBox();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.lblClientName = new System.Windows.Forms.Label();
            this.lblClientID = new System.Windows.Forms.Label();
            this.txtClientID = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.lblClientSelect = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAddClient = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grpStyles.SuspendLayout();
            this.grpbDesigns.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbClients
            // 
            this.cmbClients.FormattingEnabled = true;
            this.cmbClients.Location = new System.Drawing.Point(13, 13);
            this.cmbClients.Name = "cmbClients";
            this.cmbClients.Size = new System.Drawing.Size(224, 24);
            this.cmbClients.TabIndex = 0;
            this.cmbClients.SelectedIndexChanged += new System.EventHandler(this.cmbClients_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(13, 44);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(707, 724);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grpStyles);
            this.tabPage1.Controls.Add(this.grpbDesigns);
            this.tabPage1.Controls.Add(this.txtClientName);
            this.tabPage1.Controls.Add(this.lblClientName);
            this.tabPage1.Controls.Add(this.lblClientID);
            this.tabPage1.Controls.Add(this.txtClientID);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(699, 695);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Client Info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grpStyles
            // 
            this.grpStyles.BackColor = System.Drawing.Color.DimGray;
            this.grpStyles.Controls.Add(this.txtEtsyDescription);
            this.grpStyles.Controls.Add(this.lblEtsyDescription);
            this.grpStyles.Controls.Add(this.txtStyleDescription);
            this.grpStyles.Controls.Add(this.lblStyleDescription);
            this.grpStyles.Controls.Add(this.lbStyles);
            this.grpStyles.Controls.Add(this.btnStyleRemove);
            this.grpStyles.Controls.Add(this.btnStyleAdd);
            this.grpStyles.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grpStyles.Location = new System.Drawing.Point(7, 35);
            this.grpStyles.Name = "grpStyles";
            this.grpStyles.Size = new System.Drawing.Size(686, 305);
            this.grpStyles.TabIndex = 6;
            this.grpStyles.TabStop = false;
            this.grpStyles.Text = "Styles";
            // 
            // txtEtsyDescription
            // 
            this.txtEtsyDescription.Location = new System.Drawing.Point(312, 111);
            this.txtEtsyDescription.Name = "txtEtsyDescription";
            this.txtEtsyDescription.Size = new System.Drawing.Size(368, 22);
            this.txtEtsyDescription.TabIndex = 8;
            // 
            // lblEtsyDescription
            // 
            this.lblEtsyDescription.AutoSize = true;
            this.lblEtsyDescription.Location = new System.Drawing.Point(312, 90);
            this.lblEtsyDescription.Name = "lblEtsyDescription";
            this.lblEtsyDescription.Size = new System.Drawing.Size(110, 17);
            this.lblEtsyDescription.TabIndex = 7;
            this.lblEtsyDescription.Text = "Etsy Description";
            // 
            // txtStyleDescription
            // 
            this.txtStyleDescription.Location = new System.Drawing.Point(312, 43);
            this.txtStyleDescription.Name = "txtStyleDescription";
            this.txtStyleDescription.Size = new System.Drawing.Size(368, 22);
            this.txtStyleDescription.TabIndex = 8;
            // 
            // lblStyleDescription
            // 
            this.lblStyleDescription.AutoSize = true;
            this.lblStyleDescription.Location = new System.Drawing.Point(312, 22);
            this.lblStyleDescription.Name = "lblStyleDescription";
            this.lblStyleDescription.Size = new System.Drawing.Size(114, 17);
            this.lblStyleDescription.TabIndex = 7;
            this.lblStyleDescription.Text = "Style Description";
            // 
            // lbStyles
            // 
            this.lbStyles.FormattingEnabled = true;
            this.lbStyles.ItemHeight = 16;
            this.lbStyles.Location = new System.Drawing.Point(7, 21);
            this.lbStyles.Name = "lbStyles";
            this.lbStyles.Size = new System.Drawing.Size(295, 244);
            this.lbStyles.TabIndex = 6;
            this.lbStyles.SelectedIndexChanged += new System.EventHandler(this.lbStyles_SelectedIndexChanged);
            // 
            // btnStyleRemove
            // 
            this.btnStyleRemove.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnStyleRemove.Location = new System.Drawing.Point(88, 269);
            this.btnStyleRemove.Name = "btnStyleRemove";
            this.btnStyleRemove.Size = new System.Drawing.Size(75, 30);
            this.btnStyleRemove.TabIndex = 5;
            this.btnStyleRemove.Text = "Remove";
            this.btnStyleRemove.UseVisualStyleBackColor = true;
            this.btnStyleRemove.Click += new System.EventHandler(this.btnStyleRemove_Click);
            // 
            // btnStyleAdd
            // 
            this.btnStyleAdd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnStyleAdd.Location = new System.Drawing.Point(7, 269);
            this.btnStyleAdd.Name = "btnStyleAdd";
            this.btnStyleAdd.Size = new System.Drawing.Size(75, 30);
            this.btnStyleAdd.TabIndex = 5;
            this.btnStyleAdd.Text = "Add";
            this.btnStyleAdd.UseVisualStyleBackColor = true;
            this.btnStyleAdd.Click += new System.EventHandler(this.btnStyleAdd_Click);
            // 
            // grpbDesigns
            // 
            this.grpbDesigns.BackColor = System.Drawing.Color.DimGray;
            this.grpbDesigns.Controls.Add(this.btnColorRemove);
            this.grpbDesigns.Controls.Add(this.btnDesignRemove);
            this.grpbDesigns.Controls.Add(this.lbDesignColors);
            this.grpbDesigns.Controls.Add(this.brtnColorAd);
            this.grpbDesigns.Controls.Add(this.btnDesignAdd);
            this.grpbDesigns.Controls.Add(this.lblColors);
            this.grpbDesigns.Controls.Add(this.lbDesigns);
            this.grpbDesigns.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grpbDesigns.Location = new System.Drawing.Point(7, 346);
            this.grpbDesigns.Name = "grpbDesigns";
            this.grpbDesigns.Size = new System.Drawing.Size(686, 343);
            this.grpbDesigns.TabIndex = 5;
            this.grpbDesigns.TabStop = false;
            this.grpbDesigns.Text = "Designs";
            // 
            // btnColorRemove
            // 
            this.btnColorRemove.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnColorRemove.Location = new System.Drawing.Point(393, 307);
            this.btnColorRemove.Name = "btnColorRemove";
            this.btnColorRemove.Size = new System.Drawing.Size(75, 30);
            this.btnColorRemove.TabIndex = 5;
            this.btnColorRemove.Text = "Remove";
            this.btnColorRemove.UseVisualStyleBackColor = true;
            this.btnColorRemove.Click += new System.EventHandler(this.btnColorRemove_Click);
            // 
            // btnDesignRemove
            // 
            this.btnDesignRemove.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDesignRemove.Location = new System.Drawing.Point(88, 307);
            this.btnDesignRemove.Name = "btnDesignRemove";
            this.btnDesignRemove.Size = new System.Drawing.Size(75, 30);
            this.btnDesignRemove.TabIndex = 5;
            this.btnDesignRemove.Text = "Remove";
            this.btnDesignRemove.UseVisualStyleBackColor = true;
            this.btnDesignRemove.Click += new System.EventHandler(this.btnDesignRemove_Click);
            // 
            // lbDesignColors
            // 
            this.lbDesignColors.FormattingEnabled = true;
            this.lbDesignColors.ItemHeight = 16;
            this.lbDesignColors.Location = new System.Drawing.Point(312, 43);
            this.lbDesignColors.Name = "lbDesignColors";
            this.lbDesignColors.Size = new System.Drawing.Size(368, 260);
            this.lbDesignColors.TabIndex = 2;
            // 
            // brtnColorAd
            // 
            this.brtnColorAd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.brtnColorAd.Location = new System.Drawing.Point(312, 307);
            this.brtnColorAd.Name = "brtnColorAd";
            this.brtnColorAd.Size = new System.Drawing.Size(75, 30);
            this.brtnColorAd.TabIndex = 5;
            this.brtnColorAd.Text = "Add";
            this.brtnColorAd.UseVisualStyleBackColor = true;
            this.brtnColorAd.Click += new System.EventHandler(this.brtnColorAd_Click);
            // 
            // btnDesignAdd
            // 
            this.btnDesignAdd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDesignAdd.Location = new System.Drawing.Point(7, 307);
            this.btnDesignAdd.Name = "btnDesignAdd";
            this.btnDesignAdd.Size = new System.Drawing.Size(75, 30);
            this.btnDesignAdd.TabIndex = 5;
            this.btnDesignAdd.Text = "Add";
            this.btnDesignAdd.UseVisualStyleBackColor = true;
            this.btnDesignAdd.Click += new System.EventHandler(this.btnDesignAdd_Click);
            // 
            // lblColors
            // 
            this.lblColors.AutoSize = true;
            this.lblColors.Location = new System.Drawing.Point(309, 22);
            this.lblColors.Name = "lblColors";
            this.lblColors.Size = new System.Drawing.Size(48, 17);
            this.lblColors.TabIndex = 1;
            this.lblColors.Text = "Colors";
            // 
            // lbDesigns
            // 
            this.lbDesigns.FormattingEnabled = true;
            this.lbDesigns.ItemHeight = 16;
            this.lbDesigns.Location = new System.Drawing.Point(7, 27);
            this.lbDesigns.Name = "lbDesigns";
            this.lbDesigns.Size = new System.Drawing.Size(295, 276);
            this.lbDesigns.TabIndex = 0;
            this.lbDesigns.SelectedIndexChanged += new System.EventHandler(this.lbDesigns_SelectedIndexChanged);
            // 
            // txtClientName
            // 
            this.txtClientName.Location = new System.Drawing.Point(406, 7);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(213, 22);
            this.txtClientName.TabIndex = 2;
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.Location = new System.Drawing.Point(316, 12);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(84, 17);
            this.lblClientName.TabIndex = 1;
            this.lblClientName.Text = "Client Name";
            // 
            // lblClientID
            // 
            this.lblClientID.AutoSize = true;
            this.lblClientID.Location = new System.Drawing.Point(4, 10);
            this.lblClientID.Name = "lblClientID";
            this.lblClientID.Size = new System.Drawing.Size(60, 17);
            this.lblClientID.TabIndex = 1;
            this.lblClientID.Text = "Client ID";
            // 
            // txtClientID
            // 
            this.txtClientID.Location = new System.Drawing.Point(70, 7);
            this.txtClientID.Name = "txtClientID";
            this.txtClientID.Size = new System.Drawing.Size(212, 22);
            this.txtClientID.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.comboBox2);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.textBox6);
            this.tabPage2.Controls.Add(this.textBox5);
            this.tabPage2.Controls.Add(this.textBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(699, 695);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "EtsyInfo";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(8, 92);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(210, 24);
            this.comboBox2.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(226, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "label4";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(226, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(224, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "label4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(224, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "label4";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(8, 62);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(212, 22);
            this.textBox6.TabIndex = 2;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(6, 34);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(212, 22);
            this.textBox5.TabIndex = 2;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(6, 6);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(212, 22);
            this.textBox4.TabIndex = 2;
            // 
            // lblClientSelect
            // 
            this.lblClientSelect.AutoSize = true;
            this.lblClientSelect.Location = new System.Drawing.Point(245, 16);
            this.lblClientSelect.Name = "lblClientSelect";
            this.lblClientSelect.Size = new System.Drawing.Size(43, 17);
            this.lblClientSelect.TabIndex = 2;
            this.lblClientSelect.Text = "Client";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(294, 13);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnAddClient
            // 
            this.btnAddClient.Location = new System.Drawing.Point(598, 10);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(122, 40);
            this.btnAddClient.TabIndex = 4;
            this.btnAddClient.Text = "Add Client";
            this.btnAddClient.UseVisualStyleBackColor = true;
            // 
            // UserAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 780);
            this.Controls.Add(this.btnAddClient);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblClientSelect);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cmbClients);
            this.Name = "UserAdmin";
            this.Text = "UserAdmin";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserAdmin_FormClosed);
            this.Load += new System.EventHandler(this.UserAdmin_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.grpStyles.ResumeLayout(false);
            this.grpStyles.PerformLayout();
            this.grpbDesigns.ResumeLayout(false);
            this.grpbDesigns.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbClients;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox grpStyles;
        private System.Windows.Forms.Button btnStyleRemove;
        private System.Windows.Forms.Button btnStyleAdd;
        private System.Windows.Forms.GroupBox grpbDesigns;
        private System.Windows.Forms.Button btnColorRemove;
        private System.Windows.Forms.Button btnDesignRemove;
        private System.Windows.Forms.ListBox lbDesignColors;
        private System.Windows.Forms.Button brtnColorAd;
        private System.Windows.Forms.Button btnDesignAdd;
        private System.Windows.Forms.Label lblColors;
        private System.Windows.Forms.ListBox lbDesigns;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.Label lblClientName;
        private System.Windows.Forms.Label lblClientID;
        private System.Windows.Forms.TextBox txtClientID;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label lblClientSelect;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ListBox lbStyles;
        private System.Windows.Forms.TextBox txtEtsyDescription;
        private System.Windows.Forms.Label lblEtsyDescription;
        private System.Windows.Forms.TextBox txtStyleDescription;
        private System.Windows.Forms.Label lblStyleDescription;
        private System.Windows.Forms.Button btnAddClient;
    }
}