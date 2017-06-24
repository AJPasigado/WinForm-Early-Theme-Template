using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SADMakaSys {
    public partial class SplashScreenForm : Form {
        public SplashScreenForm() {
            InitializeComponent();
        }

        private void Fade_Tick(object sender, EventArgs e) {
            this.Opacity += 0.1;
        }

        private void SplashScreen_Load(object sender, EventArgs e) {
            this.Opacity = 0;
            Fade.Enabled = true;
        }

        bool mouseDown;
        Point lastLocation;
        private void label1_MouseUp(object sender, MouseEventArgs e) {
            mouseDown = false;
        }

        private void label1_MouseDown(object sender, MouseEventArgs e) {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e) {
            if (mouseDown) {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y
                    );
                this.Update();
            }
        }
    }
}
