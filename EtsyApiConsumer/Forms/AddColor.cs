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
    public partial class AddColor : Form
    {
        private string clientID;
        private string designNumber;
        private UserAdmin userAdmin;

        public AddColor(string ClientID, string DesignNumber, UserAdmin UserAdmin)
        {
            InitializeComponent();

            clientID = ClientID;
            designNumber = DesignNumber;
            userAdmin = UserAdmin;
        }

        private void btnAddNewColor_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtColor.Text))
            {
                var gclient = InternalClientService.GetInternalClientByID(clientID);
                var design = gclient.ClientDesigns.Where(x => x.design_number == designNumber).FirstOrDefault();
                if(design != null)
                {
                    design.colors.Add(txtColor.Text);
                }
                InternalClientService.UpdateInternalClient(gclient);
                this.Close();
            }
        }

        private void AddColor_FormClosed(object sender, FormClosedEventArgs e)
        {
            userAdmin.Enabled = true;
            userAdmin.AdminRefresh();
        }

        private void txtColor_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblColor_Click(object sender, EventArgs e)
        {

        }
    }
}
