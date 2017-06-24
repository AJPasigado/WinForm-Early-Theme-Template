using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;
using System.Runtime.InteropServices;

namespace MSAMISBackend {
    public partial class BaseForm : Form {

        Color originalColor; 
        Color blinkColor;

        

        public BaseForm() {
            InitializeComponent();
            originalColor = TitleBar.BackColor;
            blinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            
        }


        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;


        
        

        private void panel1_Paint(object sender, PaintEventArgs e) {

        }

        private void ContentPane_Paint(object sender, PaintEventArgs e) {

        }

        private void Button1_Click(object sender, EventArgs e) {

        }

        private void Title_Click(object sender, EventArgs e) {

        }

        private void button3_Click(object sender, EventArgs e) {
            this.Close();
        }

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void TitleBar_MouseDown(object sender, MouseEventArgs e) {


            
            if (e.Button == MouseButtons.Left) {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        
        }

        private void BaseForm_Deactivate(object sender, EventArgs e) {
            
        }

        private void BaseForm_Activated(object sender, EventArgs e) {
            


        }

        private void BaseForm_Enter(object sender, EventArgs e) {
            
            
        }

        private void Title_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Text_TextChanged(object sender, EventArgs e) {

        }

        private void pictureBox1_Click(object sender, EventArgs e) {

        }

        private void Button0_Click(object sender, EventArgs e) {

        }

        private void BaseForm_Leave(object sender, EventArgs e) {

            
        }

        protected override void WndProc(ref Message m) {
            //134 = WM_NCACTIVATE
            if (m.Msg == 134) {
                //Check if other app is activating - if so, we do not close         
                if (m.LParam == IntPtr.Zero) {
                    if (m.WParam != IntPtr.Zero) {
                        if (TitleBar.BackColor == originalColor) {
                            this.TitleBar.BackColor = blinkColor;
                            this.QuitButton.BackColor = blinkColor;
                        } else {
                            this.TitleBar.BackColor = originalColor;
                            this.QuitButton.BackColor = originalColor;
                        }
                    }
                    
                }
                
            }

            base.WndProc(ref m);
        }
        /*
        protected override void WndProc(ref Message m) {
            base.WndProc(ref m);
            if (TitleBar.BackColor == originalColor)
                this.TitleBar.BackColor = blinkColor;
            else
                this.TitleBar.BackColor = originalColor;

        }
        */

    }
}
