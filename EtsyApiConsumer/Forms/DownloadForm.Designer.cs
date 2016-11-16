namespace EtsyApiConsumer
{
    partial class DownloadForm
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
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.lblClient = new System.Windows.Forms.Label();
            this.lblOpenOrders = new System.Windows.Forms.Label();
            this.lblShop = new System.Windows.Forms.Label();
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnOrderRefresh = new System.Windows.Forms.Button();
            this.chkGetAllOrders = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbClients
            // 
            this.cmbClients.FormattingEnabled = true;
            this.cmbClients.Location = new System.Drawing.Point(12, 12);
            this.cmbClients.Name = "cmbClients";
            this.cmbClients.Size = new System.Drawing.Size(166, 24);
            this.cmbClients.TabIndex = 0;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(13, 43);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(165, 24);
            this.comboBox2.TabIndex = 1;
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(185, 12);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(43, 17);
            this.lblClient.TabIndex = 2;
            this.lblClient.Text = "Client";
            // 
            // lblOpenOrders
            // 
            this.lblOpenOrders.AutoSize = true;
            this.lblOpenOrders.Location = new System.Drawing.Point(12, 74);
            this.lblOpenOrders.Name = "lblOpenOrders";
            this.lblOpenOrders.Size = new System.Drawing.Size(91, 17);
            this.lblOpenOrders.TabIndex = 3;
            this.lblOpenOrders.Text = "Open Orders";
            // 
            // lblShop
            // 
            this.lblShop.AutoSize = true;
            this.lblShop.Location = new System.Drawing.Point(188, 49);
            this.lblShop.Name = "lblShop";
            this.lblShop.Size = new System.Drawing.Size(48, 17);
            this.lblShop.TabIndex = 4;
            this.lblShop.Text = "Shops";
            // 
            // dgvTransactions
            // 
            this.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactions.Location = new System.Drawing.Point(15, 141);
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.RowTemplate.Height = 24;
            this.dgvTransactions.Size = new System.Drawing.Size(1109, 515);
            this.dgvTransactions.TabIndex = 5;
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(1014, 675);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(110, 56);
            this.btnDownload.TabIndex = 6;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnOrderRefresh
            // 
            this.btnOrderRefresh.Location = new System.Drawing.Point(15, 95);
            this.btnOrderRefresh.Name = "btnOrderRefresh";
            this.btnOrderRefresh.Size = new System.Drawing.Size(132, 40);
            this.btnOrderRefresh.TabIndex = 7;
            this.btnOrderRefresh.Text = "Refresh";
            this.btnOrderRefresh.UseVisualStyleBackColor = true;
            this.btnOrderRefresh.Click += new System.EventHandler(this.btnOrderRefresh_Click);
            // 
            // chkGetAllOrders
            // 
            this.chkGetAllOrders.AutoSize = true;
            this.chkGetAllOrders.Location = new System.Drawing.Point(168, 106);
            this.chkGetAllOrders.Name = "chkGetAllOrders";
            this.chkGetAllOrders.Size = new System.Drawing.Size(120, 21);
            this.chkGetAllOrders.TabIndex = 8;
            this.chkGetAllOrders.Text = "Get All Orders";
            this.chkGetAllOrders.UseVisualStyleBackColor = true;
            // 
            // DownloadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 743);
            this.Controls.Add(this.chkGetAllOrders);
            this.Controls.Add(this.btnOrderRefresh);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.dgvTransactions);
            this.Controls.Add(this.lblShop);
            this.Controls.Add(this.lblOpenOrders);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.cmbClients);
            this.Name = "DownloadForm";
            this.Text = "DownloadForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DownloadForm_FormClosed);
            this.Load += new System.EventHandler(this.DownloadForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbClients;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.Label lblOpenOrders;
        private System.Windows.Forms.Label lblShop;
        private System.Windows.Forms.DataGridView dgvTransactions;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnOrderRefresh;
        private System.Windows.Forms.CheckBox chkGetAllOrders;
    }
}