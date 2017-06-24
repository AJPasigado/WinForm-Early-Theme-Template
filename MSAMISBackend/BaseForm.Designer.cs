using MSAMISCustomGUITools;
using System.Drawing;

namespace MSAMISBackend {
    partial class BaseForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// 
        Font defaultFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        private void InitializeComponent() {
            this.TitleBar = new System.Windows.Forms.Panel();
            this.QuitButton = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.ContentPane = new System.Windows.Forms.Panel();
            this.Button0 = new System.Windows.Forms.Button();
            this.IconBox = new System.Windows.Forms.PictureBox();
            this.Button2 = new System.Windows.Forms.Button();
            this.Text = new MSAMISCustomGUITools.ReadOnlyTextBox();
            this.Button1 = new System.Windows.Forms.Button();
            this.TitleBar.SuspendLayout();
            this.ContentPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconBox)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleBar
            // 
            this.TitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TitleBar.Controls.Add(this.QuitButton);
            this.TitleBar.Controls.Add(this.Title);
            this.TitleBar.Location = new System.Drawing.Point(-4, -2);
            this.TitleBar.Name = "TitleBar";
            this.TitleBar.Size = new System.Drawing.Size(436, 33);
            this.TitleBar.TabIndex = 0;
            this.TitleBar.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.TitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseDown);
            // 
            // QuitButton
            // 
            this.QuitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.QuitButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.QuitButton.FlatAppearance.BorderSize = 0;
            this.QuitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.QuitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.QuitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.QuitButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuitButton.Location = new System.Drawing.Point(398, 3);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(28, 28);
            this.QuitButton.TabIndex = 3;
            this.QuitButton.Text = "X";
            this.QuitButton.UseVisualStyleBackColor = false;
            this.QuitButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.Title.Location = new System.Drawing.Point(17, 8);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(41, 17);
            this.Title.TabIndex = 0;
            this.Title.Text = "label1";
            this.Title.Click += new System.EventHandler(this.Title_Click);
            this.Title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Title_MouseDown);
            // 
            // ContentPane
            // 
            this.ContentPane.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ContentPane.Controls.Add(this.Button0);
            this.ContentPane.Controls.Add(this.IconBox);
            this.ContentPane.Controls.Add(this.Button2);
            this.ContentPane.Controls.Add(this.Text);
            this.ContentPane.Controls.Add(this.Button1);
            this.ContentPane.Location = new System.Drawing.Point(-1, 33);
            this.ContentPane.Name = "ContentPane";
            this.ContentPane.Size = new System.Drawing.Size(432, 218);
            this.ContentPane.TabIndex = 1;
            this.ContentPane.Paint += new System.Windows.Forms.PaintEventHandler(this.ContentPane_Paint);
            // 
            // Button0
            // 
            this.Button0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Button0.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.Button0.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.Button0.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.Button0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button0.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button0.Location = new System.Drawing.Point(35, 165);
            this.Button0.Name = "Button0";
            this.Button0.Size = new System.Drawing.Size(117, 35);
            this.Button0.TabIndex = 4;
            this.Button0.Text = "button1";
            this.Button0.UseVisualStyleBackColor = false;
            this.Button0.Click += new System.EventHandler(this.Button0_Click);
            // 
            // IconBox
            // 
            
            this.IconBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.IconBox.Location = new System.Drawing.Point(17, 13);
            this.IconBox.Name = "IconBox";
            this.IconBox.Size = new System.Drawing.Size(89, 85);
            this.IconBox.TabIndex = 3;
            this.IconBox.TabStop = false;
            this.IconBox.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Button2
            // 
            this.Button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button2.Location = new System.Drawing.Point(289, 165);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(117, 35);
            this.Button2.TabIndex = 2;
            this.Button2.Text = "button1";
            this.Button2.UseVisualStyleBackColor = false;
            // 
            // Text
            // 
            this.Text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Text.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Text.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.Text.Location = new System.Drawing.Point(112, 15);
            this.Text.Multiline = true;
            this.Text.Name = "Text";
            this.Text.ReadOnly = true;
            this.Text.Size = new System.Drawing.Size(292, 141);
            this.Text.TabIndex = 1;
            this.Text.TextChanged += new System.EventHandler(this.Text_TextChanged);
            // 
            // Button1
            // 
            this.Button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button1.Location = new System.Drawing.Point(162, 165);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(117, 35);
            this.Button1.TabIndex = 0;
            this.Button1.Text = "button1";
            this.Button1.UseVisualStyleBackColor = false;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.ClientSize = new System.Drawing.Size(428, 249);
            this.ControlBox = false;
            this.Controls.Add(this.ContentPane);
            this.Controls.Add(this.TitleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "BaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Activated += new System.EventHandler(this.BaseForm_Activated);
            this.Deactivate += new System.EventHandler(this.BaseForm_Deactivate);
            this.Enter += new System.EventHandler(this.BaseForm_Enter);
            this.Leave += new System.EventHandler(this.BaseForm_Leave);
            this.TitleBar.ResumeLayout(false);
            this.TitleBar.PerformLayout();
            this.ContentPane.ResumeLayout(false);
            this.ContentPane.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        
        public System.Windows.Forms.Panel TitleBar;
        public System.Windows.Forms.Panel ContentPane;
        public System.Windows.Forms.Button Button1;
        public ReadOnlyTextBox Text;
        public System.Windows.Forms.Button Button2;
        public System.Windows.Forms.Label Title;
        public System.Windows.Forms.Button QuitButton;
        public System.Windows.Forms.Button Button0;
        public System.Windows.Forms.PictureBox IconBox;
    }
}