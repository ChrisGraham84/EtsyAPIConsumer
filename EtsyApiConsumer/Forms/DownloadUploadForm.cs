using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EtsyApiConsumer
{
    public partial class DownloadUploadForm : Form
    {
        public DownloadUploadForm()
        {
            InitializeComponent();
        }

        private void DownloadUploadForm_Load(object sender, EventArgs e)
        {

        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            DownloadForm downloadForm = new DownloadForm(this);
            downloadForm.Show();
            this.Enabled = false;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {

        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            UserAdmin userAdminForm = new UserAdmin(this);
            userAdminForm.Show();
            this.Enabled = false;
        }
    }
}
