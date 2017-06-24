using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SADMakaSys {
    
    public partial class DevOptionsForm : Form {
        public String speed;

        public DevOptionsForm(String a) {
            InitializeComponent();
            
            speed = a;
            textBox1.Text = speed;
        }

        private void button1_Click(object sender, EventArgs e) {
            if (Double.Parse(textBox1.Text, CultureInfo.InvariantCulture) <=5.0 && Double.Parse(textBox1.Text, CultureInfo.InvariantCulture) >= 0.1) {
                this.DialogResult = DialogResult.OK;
                speed = textBox1.Text;
                this.Close();
            } else {
                MessageBox.Show("Invalid value for SidebarAnimationSpeed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DevOptionsForm_Load(object sender, EventArgs e) {

        }
    }
}
