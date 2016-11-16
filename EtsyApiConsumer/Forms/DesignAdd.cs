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
    public partial class DesignAdd : Form
    {
        private string clientID;
        private UserAdmin userAdmin;

        public DesignAdd(string ClientID, UserAdmin UserAdmin)
        {
            clientID = ClientID;
            userAdmin = UserAdmin;
            InitializeComponent();
        }

        private void btnAddNewDesign_Click(object sender, EventArgs e)
        {
            var client = InternalClientService.GetInternalClientByID(clientID);
            if(!string.IsNullOrEmpty(txtDefaultColor.Text) && !string.IsNullOrEmpty(txtDesignNumber.Text))
            {
                var designs = client.ClientDesigns;
                if(designs == null)
                {
                    designs = new List<Models.InternalClientDesign>();
                    client.ClientDesigns = designs;
                }
                var design = designs.Where(x => x.design_number == txtDesignNumber.Text).FirstOrDefault();
                if(design == null)
                {
                    design = new Models.InternalClientDesign();
                    design.design_number = txtDesignNumber.Text;

                    design.colors = new List<string>();
                    design.colors.Add(txtDefaultColor.Text);

                    client.ClientDesigns.Add(design);
                }
                InternalClientService.UpdateInternalClient(client);
                userAdmin.Enabled = true;
                userAdmin.AdminRefresh();
                this.Close();
            }
        }

        private void DesignAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            userAdmin.Enabled = true;
        }
    }
}
