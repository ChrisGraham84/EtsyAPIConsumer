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
    public partial class AddStyle : Form
    {
        private string clientID;
        private UserAdmin userAdmin;

        public AddStyle(string ClientID, UserAdmin UserAdmin)
        {
            InitializeComponent();

            clientID = ClientID;
            userAdmin = UserAdmin;
        }

        private void btnAddNewStyle_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtStyle.Text) 
                && !string.IsNullOrEmpty(txtDescription.Text) 
                && !string.IsNullOrEmpty(txtEtsyDescription.Text))
            {
                var gclient = InternalClientService.GetInternalClientByID(clientID);
                var style = gclient.ClientStyles.Where(x => x.style_number == txtStyle.Text).FirstOrDefault();
                if(style == null)
                {
                    style = new Models.InternalClientStyle();
                    style.style_number = txtStyle.Text;
                    style.style_description = txtDescription.Text;
                    style.etsy_style_descripion = txtEtsyDescription.Text;

                    gclient.ClientStyles.Add(style);
                    InternalClientService.UpdateInternalClient(gclient);
                    userAdmin.Enabled = true;
                    userAdmin.AdminRefresh();
                    this.Close();
                }
            }
        }

        private void AddStyle_FormClosed(object sender, FormClosedEventArgs e)
        {
            userAdmin.Enabled = true;
        }
    }
}
