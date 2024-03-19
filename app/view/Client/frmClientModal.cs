using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app.view.Client
{
    public partial class frmClientModal : Form
    {
        public frmClientModal()
        {
            InitializeComponent();
            //TODO: Populating combobox data.
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //TODO: Save function
        }

        private void frmClientModal_Load(object sender, EventArgs e)
        {
            //TODO: When updating load all fetch data to each components.
        }
    }
}
