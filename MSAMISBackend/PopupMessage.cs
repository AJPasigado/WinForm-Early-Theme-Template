using MSAMISBackend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSAMISCustomGUITools;
using System.Runtime.InteropServices;

namespace MSAMISBackend {
    public class PopupMessage {
        static BaseForm p = new BaseForm();
        static DialogResult dr = DialogResult.Cancel;


        public static DialogResult showDialog (String title, String text, MessageBoxButtons btn) {

            InitForm(title, text, false);
            
            // ONE BUTTON
            if (btn == MessageBoxButtons.OK)
                EnableButtons(DialogResult.OK);
            //TWO BUTTONS
            if (btn == MessageBoxButtons.OKCancel) 
                EnableButtons(DialogResult.OK, DialogResult.Cancel);
            if (btn == MessageBoxButtons.RetryCancel)
                EnableButtons(DialogResult.Retry, DialogResult.Cancel);
            if (btn == MessageBoxButtons.YesNo)
                EnableButtons(DialogResult.Yes, DialogResult.No);
            //THREE BUTTONS
            if (btn == MessageBoxButtons.YesNoCancel)
                EnableButtons(DialogResult.Yes, DialogResult.No, DialogResult.Cancel);
            if (btn == MessageBoxButtons.AbortRetryIgnore)
                EnableButtons(DialogResult.Abort, DialogResult.Retry, DialogResult.Ignore);
            
            p.ShowDialog();
            return dr;
        }

        public static void EnableButtons(DialogResult Btn2) {
            p.Button2.Location = ControlProperties.Button.Right;
            p.Button2.Size = new System.Drawing.Size(143, 35);
            p.Button0.Visible = false;
            p.Button1.Visible = false;
            p.Button2.Click += (sender, e) => { p.Close(); dr = Btn2; };
            p.Button2.Text = Btn2.ToString();
        }
        public static void EnableButtons (DialogResult Btn1, DialogResult Btn2) {
            p.Button1.Location = ControlProperties.Button.Left;
            p.Button2.Location = ControlProperties.Button.Right;
            p.Button1.Size = p.Button2.Size =  new System.Drawing.Size(143, 35);
            p.Button0.Visible = false;
            p.Button1.Click += (sender, e) => { p.Close(); dr = Btn1; };
            p.Button2.Click += (sender, e) => { p.Close(); dr = Btn2; };
            p.Button1.Text = Btn1.ToString();
            p.Button2.Text = Btn2.ToString(); 
        }
        public static void EnableButtons(DialogResult Btn0, DialogResult Btn1, DialogResult Btn2) {
            p.Button0.Location = ControlProperties.Button.FarLeft;
            p.Button1.Location = ControlProperties.Button.Middle;
            p.Button2.Location = ControlProperties.Button.FarRight;
            p.Button1.Size = p.Button2.Size = p.Button0.Size = new System.Drawing.Size(117, 35);
            p.Button0.Click += (sender, e) => { p.Close(); dr = Btn0; };
            p.Button1.Click += (sender, e) => { p.Close(); dr = Btn1; };
            p.Button2.Click += (sender, e) => { p.Close(); dr = Btn2; };
            p.Button0.Text = Btn0.ToString();
            p.Button1.Text = Btn1.ToString();
            p.Button2.Text = Btn2.ToString();
        }

        public static void DisableIcon () {
            // Called when Icon is not required.
            // Disables IconBox and Extends ReadOnlyRichTextBox
            p.IconBox.Visible = false;
            p.Text.Location = ControlProperties.Text.WithoutIcon.Location;
            p.Text.Size = ControlProperties.Text.WithoutIcon.Size;
        }

        public static void InitForm(String a, String b, bool c) {
            p.Title.Text = a;
            p.Text.Text = b;
            if (!c)
                DisableIcon();
        }
    }
}

     