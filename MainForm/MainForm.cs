using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;
using Tekla.Structures.Model.Operations;

namespace MuggleTeklaPlugins.MainForm {
    public partial class MainForm: Form {
        private SelectBooleans formSelectBooleans;
        public MainForm() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            if(formSelectBooleans == null || formSelectBooleans.IsDisposed) {
                formSelectBooleans = new SelectBooleans();
            }
            formSelectBooleans.Show();
            formSelectBooleans.Activate();
        }
    }
}
