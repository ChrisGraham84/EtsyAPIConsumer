using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EtsyApiConsumer.Services;

namespace EtsyApiConsumer
{
    public partial class DownloadForm : Form
    {
        DownloadUploadForm downloaduploadform;
        public DownloadForm(DownloadUploadForm DLF)
        {
            InitializeComponent();
            downloaduploadform = DLF;
        }
        private void DownloadForm_Load(object sender, EventArgs e)
        {
            
            var clients = InternalClientService.GetAllInternalClients();
            cmbClients.DataSource = clients;
            cmbClients.DisplayMember = "clientName";
            cmbClients.ValueMember = "clientID";

            comboBox2.Visible = false;
            lblShop.Visible = false;
        }
        private void btnOrderRefresh_Click(object sender, EventArgs e)
        {
            string clientID = cmbClients.SelectedValue.ToString();
            var client = InternalClientService.GetInternalClientByID(clientID);
            if(client.EtsyShopIDs.Count > 1)
            {
                comboBox2.Visible = true;
                lblShop.Visible = true;
                //alert that a shop must be selected
            }

            var extractions = ExtractionService.CreateExtractionFromReceipt(client,chkGetAllOrders.Checked);
            dgvTransactions.DataSource = extractions;

        }
        private void btnDownload_Click(object sender, EventArgs e)
        {
            var extractions = dgvTransactions.DataSource;
            ExtractionService.WriteRecieptExtractions(extractions);
        }

        private void DownloadForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            downloaduploadform.Enabled = true;
        }
    }
}
