using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSAMISCustomGUITools {
    public class ReadOnlyTextBox : TextBox {
        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

        public ReadOnlyTextBox() {
            this.ReadOnly = true;
            this.BackColor = Color.White;
            this.GotFocus += TextBoxGotFocus;
            this.Cursor = Cursors.Arrow; // mouse cursor like in other controls



            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.Location = new System.Drawing.Point(31, 15);
            this.Multiline = true;
            
            

        }

        private void TextBoxGotFocus(object sender, EventArgs args) {
            HideCaret(this.Handle);
        }
    }
}
