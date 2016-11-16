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
    public partial class UserAdmin : Form
    {
        DownloadUploadForm downloaduploadform;
        bool isClientsLoaded = false;
        public UserAdmin(DownloadUploadForm DownloadUploadForm)
        {
            downloaduploadform = DownloadUploadForm;
            InitializeComponent();

            var clients = InternalClientService.GetAllInternalClients();
            cmbClients.DataSource = clients;
            cmbClients.DisplayMember = "clientName";
            cmbClients.ValueMember = "clientID";
            isClientsLoaded = true;

            AdminRefresh();
        }

        private void UserAdmin_Load(object sender, EventArgs e)
        {
           

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            AdminRefresh();
        }

        private void lbDesigns_SelectedIndexChanged(object sender, EventArgs e)
        {
            string clientID = cmbClients.SelectedValue.ToString();
            var client = InternalClientService.GetInternalClientByID(clientID);

            ListBox lb = (ListBox)sender;
            string designNumber = lb.SelectedItem.ToString();
            var design = client.ClientDesigns.Where(x => x.design_number == designNumber).FirstOrDefault();
            if(design != null)
            {
                lbDesignColors.Items.Clear();
                lbDesignColors.Items.AddRange(design.colors.ToArray());
            }
        }
        private void lbStyles_SelectedIndexChanged(object sender, EventArgs e)
        {
            string clientID = cmbClients.SelectedValue.ToString();
            var client = InternalClientService.GetInternalClientByID(clientID);

            ListBox lb = (ListBox)sender;
            string styleNumber = lb.SelectedItem.ToString();
            var style = client.ClientStyles.Where(x => x.style_number == styleNumber).FirstOrDefault();
            if(style != null)
            {
                txtEtsyDescription.Text = style.etsy_style_descripion;
                txtStyleDescription.Text = style.style_description;
            }
        }

        private void UserAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            downloaduploadform.Enabled = true;
        }

        private void btnDesignAdd_Click(object sender, EventArgs e)
        {
            string clientID = cmbClients.SelectedValue.ToString();
            DesignAdd designAddForm = new DesignAdd(clientID, this);
            designAddForm.Show();
            this.Enabled = false;
        }

        public void AdminRefresh()
        {
            var clientID = cmbClients.SelectedValue.ToString();
            var client = InternalClientService.GetInternalClientByID(clientID);

            txtClientID.Text = client.clientID;
            txtClientName.Text = client.clientName;

            var styles = client.ClientStyles.Select(x => x.style_number).ToList();
            lbStyles.Items.Clear();
            lbStyles.Items.AddRange(styles.ToArray());

            var designs = client.ClientDesigns;
            if (designs != null)
            {
                lbDesigns.Items.Clear();
                lbDesigns.Items.AddRange(designs.Select(x => x.design_number).ToArray());
                lbDesigns.SelectedIndex = 0;

                lbDesignColors.Items.Clear();
                lbDesignColors.Items.AddRange(designs.FirstOrDefault().colors.ToArray());
            }
        }

        private void brtnColorAd_Click(object sender, EventArgs e)
        {
            string clientID = cmbClients.SelectedValue.ToString();
            string designNumber = lbDesigns.SelectedItem.ToString();
            AddColor addColorForm = new AddColor(clientID, designNumber, this);
            addColorForm.Show();
            this.Enabled = false;
        }

        private void btnColorRemove_Click(object sender, EventArgs e)
        {
            string clientID = cmbClients.SelectedValue.ToString();
            if(lbDesignColors.SelectedItem != null && lbDesigns.SelectedItem != null)
            {
                var gclient = InternalClientService.GetInternalClientByID(clientID);
                var design = gclient.ClientDesigns.Where(x => x.design_number == lbDesigns.SelectedItem.ToString()).FirstOrDefault();
                design.colors.Remove(lbDesignColors.SelectedItem.ToString());
                InternalClientService.UpdateInternalClient(gclient);
                AdminRefresh();
            }
        }

        private void cmbClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isClientsLoaded)
            {
                AdminRefresh();
            }
        }

        private void btnStyleAdd_Click(object sender, EventArgs e)
        {
            string clientID = cmbClients.SelectedValue.ToString();
            AddStyle addStyleForm = new AddStyle(clientID, this);
            addStyleForm.Show();
            this.Enabled = false;
        }

        private void btnStyleRemove_Click(object sender, EventArgs e)
        {
            string clientID = cmbClients.SelectedValue.ToString();
            var stylenumber = lbStyles.SelectedItem.ToString();
            var gclient = InternalClientService.GetInternalClientByID(clientID);

            var style = gclient.ClientStyles.Where(x => x.style_number == stylenumber).FirstOrDefault();
            if(style != null)
            {
                gclient.ClientStyles.Remove(style);
                InternalClientService.UpdateInternalClient(gclient);
            }
            AdminRefresh();
            txtStyleDescription.Text = string.Empty;
            txtEtsyDescription.Text = string.Empty;
        }

        private void btnDesignRemove_Click(object sender, EventArgs e)
        {

        }
    }
}
