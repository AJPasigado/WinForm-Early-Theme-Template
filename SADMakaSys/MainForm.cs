using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSAMISBackend;

namespace SADMakaSys {
    public partial class MainForm : Form {

        //Form Variables
            bool mouseDown;                                 //for form drag
            Point lastLocation;                             //for form drag
            bool Maximized = false;                         //if form is maximize
            bool MaxBTNClicked = false;                     //if maximized form is clicked (will be set to false after clicking)
            Size currentSize;                               //current form size (for free flowing layout)
        //Subpanel Variables
            bool subpanelMinimized = false;                 //for side panel
        //Pages Variables
            int clickedIndex = 1;                           //current page
            SplitContainer currentPage;
        //Animation Variables
            int baseSpeed = 1;
            double AnimationMultiplier = 10;
            int currentSplitterDistance = 150;
        //Theme Variables
            Image dashboardHoverPic;
            Image employeesHoverPic;
            Image payrollHoverPic;
            Image clientHoverPic;
            Image guardSchedHoverPic;
            Image settingsHoverPic;
            Color accent = Color.Goldenrod;                 //Accent color
            Color baseColor = Color.DarkSlateGray;          //Base color
            Color darkBase = Color.FromArgb(0, 32, 33);     //Darker base
            Color WorkAreaBG = Color.White;
            Color SubpanelsBG = Color.Gainsboro;


        //Initialize Splash
        public void splash() {
            Application.Run(new SplashScreenForm());
        }

        //Form initialization with splash screen
        public MainForm() {
            Thread splashScreen = new Thread(new ThreadStart(splash));
            splashScreen.Start();
            Thread.Sleep(950);
            InitializeComponent();
            splashScreen.Abort();
            initializeViariables();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        private void initializeViariables() {
            currentPage = DashboardPage;
            this.Opacity = 0;
            Fade.Enabled = true;
            currentSize = this.Size;
            DashboardLBL.ForeColor = accent;
            DDateLBL.Text = DateTime.Now.ToString("MMMM dd, yyyy");
            DashboardPic.Image = SADMakaSys.Properties.Resources.DashboardLogoHover;
            dashboardHoverPic = Properties.Resources.DashboardLogoHover;
            employeesHoverPic = Properties.Resources.EmployeesLogoHover;
            payrollHoverPic = Properties.Resources.PayrollLogoHover;
            clientHoverPic = Properties.Resources.ClientLogoHover;
            guardSchedHoverPic = Properties.Resources.SchedLogoHover;
            settingsHoverPic = Properties.Resources.SettingsLogoHover;
            DashboardPage.Visible = true;
            EmployeesPage.Visible = false;
            PayrollPage.Visible = false;
            ClientPage.Visible = false;
            GuardSchedPage.Visible = false;
            SettingsPage.Visible = false;
        }
        private void Fade_Tick(object sender, EventArgs e) {
            this.Opacity += 0.2;
        }
        
        //App shortcut keys
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            if (keyData == (Keys.Control | Keys.F7)) {
                DevOptionsForm e = new DevOptionsForm(AnimationMultiplier.ToString());
                DialogResult x = e.ShowDialog();
                if (x==DialogResult.OK) {
                    AnimationMultiplier = Double.Parse(e.speed);
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        //To enable form drag
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

        //Control Button and other form buttons
        private void CloseBTN_Click(object sender, EventArgs e) {
            Application.Exit();
        }
        private void MainForm_SizeChanged(object sender, EventArgs e) {
            currentSize = this.Size;
            ControlBoxBTN.Size = new Size(currentPage.SplitterDistance, 30);
            SearchPic.Location = new Point(currentPage.SplitterDistance + 20, 3);
            SearchBox.Location = new Point(currentPage.SplitterDistance + 50, 8);
            if (SearchBox.Location.X > ControlBoxPanel.Size.Width - 320) {
                SearchBox.Visible = false;
                SearchPic.Visible = false;
            }
            else {
                SearchBox.Visible = true;
                SearchPic.Visible = true;
            }
        }
        private void MaximizeBTN_Click(object sender, EventArgs e) {
            MaxBTNClicked = true;
            if (!Maximized) {
                Maximized = true;
                currentSize = this.Size;
                this.WindowState = FormWindowState.Maximized;
                changeSubpanelsSize(DashboardPage.SplitterDistance);
            }
            else {
                this.WindowState = FormWindowState.Normal;
                this.Size = currentSize;
                Maximized = false;
            }
        }
        private void MinimizeBTN_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        //Sidebar buttons Animation (Hover)
        private void DashboardBTN_MouseHover(object sender, EventArgs e) {
            DashboardPic.Image = dashboardHoverPic;
            DashboardLBL.ForeColor = accent;
            DashboardPic.BackColor = darkBase;
            DashboardLBL.BackColor = darkBase;
            DasboardSidePNL.BackColor = darkBase;
        }
        private void DashboardBTN_MouseLeave(object sender, EventArgs e) {
            if (clickedIndex!=1) HoverEverything(clickedIndex);
        }
        private void EmployeesBTN_MouseHover(object sender, EventArgs e) {
            EmployeesPic.Image = employeesHoverPic;
            EmployeesLBL.ForeColor = accent;
            EmployeesPic.BackColor = darkBase;
            EmployeesLBL.BackColor = darkBase;
            EmployeesSidePNL.BackColor = darkBase;
        }
        private void EmployeesBTN_MouseLeave(object sender, EventArgs e) {
            if (clickedIndex != 2) HoverEverything(clickedIndex);
        }
        private void PayrollBTN_MouseHover(object sender, EventArgs e) {
            PayrollPic.Image = payrollHoverPic;
            PayrollLBL.ForeColor = accent;
            PayrollPic.BackColor = darkBase;
            PayrollLBL.BackColor = darkBase;
            PayrollSidePNL.BackColor = darkBase;
        }
        private void PayrollBTN_MouseLeave(object sender, EventArgs e) {
            if (clickedIndex != 3) HoverEverything(clickedIndex);
        }
        private void ClientBTN_MouseHover(object sender, EventArgs e) {
            ClientPic.Image = clientHoverPic;
            ClientLBL.ForeColor = accent;
            ClientPic.BackColor = darkBase;
            ClientLBL.BackColor = darkBase;
            ClientSidePNL.BackColor = darkBase;
        }
        private void ClientBTN_MouseLeave(object sender, EventArgs e) {
            if (clickedIndex != 4) HoverEverything(clickedIndex);
        }
        private void GuardSchedBTN_MouseHover(object sender, EventArgs e) {
            GuardSchedPic.Image = guardSchedHoverPic;
            GuardSchedLBL.ForeColor = accent;
            GuardSchedPic.BackColor = darkBase;
            GuardSchedLBL.BackColor = darkBase;
            GuardSchedSidePNL.BackColor = darkBase;
        }
        private void GuardSchedBTN_MouseLeave(object sender, EventArgs e) {
            if (clickedIndex != 5) HoverEverything(clickedIndex);
        }
        private void SettingsBTN_MouseHover(object sender, EventArgs e) {
            SettingsPic.Image = settingsHoverPic;
            SettingsLBL.ForeColor = accent;
            SettingsPic.BackColor = darkBase;
            SettingsLBL.BackColor = darkBase;
            SettingsSidePNL.BackColor = darkBase;
        }
        private void SettingsBTN_MouseLeave(object sender, EventArgs e) {
            if (clickedIndex != 6) HoverEverything(clickedIndex);
        }
        private void HoverEverything(int index) {
            if (index == 1) {
                EmployeesPic.Image = SADMakaSys.Properties.Resources.EmployeesLogo;
                EmployeesLBL.ForeColor = Color.White;
                EmployeesSidePNL.BackgroundImage = null;
                EmployeesPic.BackColor = baseColor;
                EmployeesLBL.BackColor = baseColor;
                EmployeesSidePNL.BackColor = baseColor;
                PayrollPic.Image = SADMakaSys.Properties.Resources.PayrollLogo;
                PayrollLBL.ForeColor = Color.White;
                PayrollSidePNL.BackgroundImage = null;
                PayrollPic.BackColor = baseColor;
                PayrollLBL.BackColor = baseColor;
                PayrollSidePNL.BackColor = baseColor;
                ClientPic.Image = SADMakaSys.Properties.Resources.ClientLogo;
                ClientLBL.ForeColor = Color.White;
                ClientSidePNL.BackgroundImage = null;
                ClientPic.BackColor = baseColor;
                ClientLBL.BackColor = baseColor;
                ClientSidePNL.BackColor = baseColor;
                GuardSchedPic.Image = SADMakaSys.Properties.Resources.SchedLogo;
                GuardSchedLBL.ForeColor = Color.White;
                GuardSchedSidePNL.BackgroundImage = null;
                GuardSchedPic.BackColor = baseColor;
                GuardSchedLBL.BackColor = baseColor;
                GuardSchedSidePNL.BackColor = baseColor;
                SettingsPic.Image = SADMakaSys.Properties.Resources.SettingsLogo;
                SettingsLBL.ForeColor = Color.White;
                SettingsSidePNL.BackgroundImage = null;
                SettingsPic.BackColor = baseColor;
                SettingsLBL.BackColor = baseColor;
                SettingsSidePNL.BackColor = baseColor;
            }
            else if (index == 2) {
                DashboardPic.Image = SADMakaSys.Properties.Resources.DashboardLogo;
                DashboardLBL.ForeColor = Color.White;
                DasboardSidePNL.BackgroundImage = null;
                DashboardPic.BackColor = baseColor;
                DashboardLBL.BackColor = baseColor;
                DasboardSidePNL.BackColor = baseColor;
                PayrollSidePNL.BackgroundImage = null;
                PayrollPic.BackColor = baseColor;
                PayrollLBL.BackColor = baseColor;
                PayrollPic.Image = SADMakaSys.Properties.Resources.PayrollLogo;
                PayrollLBL.ForeColor = Color.White;
                PayrollSidePNL.BackColor = baseColor;
                ClientPic.Image = SADMakaSys.Properties.Resources.ClientLogo;
                ClientLBL.ForeColor = Color.White;
                ClientSidePNL.BackgroundImage = null;
                ClientPic.BackColor = baseColor;
                ClientLBL.BackColor = baseColor;
                ClientSidePNL.BackColor = baseColor;
                GuardSchedPic.Image = SADMakaSys.Properties.Resources.SchedLogo;
                GuardSchedLBL.ForeColor = Color.White;
                GuardSchedSidePNL.BackgroundImage = null;
                GuardSchedPic.BackColor = baseColor;
                GuardSchedLBL.BackColor = baseColor;
                GuardSchedSidePNL.BackColor = baseColor;
                SettingsPic.Image = SADMakaSys.Properties.Resources.SettingsLogo;
                SettingsLBL.ForeColor = Color.White;
                SettingsSidePNL.BackgroundImage = null;
                SettingsPic.BackColor = baseColor;
                SettingsLBL.BackColor = baseColor;
                SettingsSidePNL.BackColor = baseColor;
            }
            else if (index == 3) {
                DashboardPic.Image = SADMakaSys.Properties.Resources.DashboardLogo;
                DashboardLBL.ForeColor = Color.White;
                DasboardSidePNL.BackgroundImage = null;
                DashboardPic.BackColor = baseColor;
                DashboardLBL.BackColor = baseColor;
                DasboardSidePNL.BackColor = baseColor;
                EmployeesPic.Image = SADMakaSys.Properties.Resources.EmployeesLogo;
                EmployeesLBL.ForeColor = Color.White;
                EmployeesPic.BackColor = baseColor;
                EmployeesLBL.BackColor = baseColor;
                EmployeesSidePNL.BackColor = baseColor;
                EmployeesSidePNL.BackgroundImage = null;
                ClientPic.Image = SADMakaSys.Properties.Resources.ClientLogo;
                ClientLBL.ForeColor = Color.White;
                ClientSidePNL.BackgroundImage = null;
                ClientPic.BackColor = baseColor;
                ClientLBL.BackColor = baseColor;
                ClientSidePNL.BackColor = baseColor;
                GuardSchedPic.Image = SADMakaSys.Properties.Resources.SchedLogo;
                GuardSchedLBL.ForeColor = Color.White;
                GuardSchedSidePNL.BackgroundImage = null;
                GuardSchedPic.BackColor = baseColor;
                GuardSchedLBL.BackColor = baseColor;
                GuardSchedSidePNL.BackColor = baseColor;
                SettingsPic.Image = SADMakaSys.Properties.Resources.SettingsLogo;
                SettingsLBL.ForeColor = Color.White;
                SettingsSidePNL.BackgroundImage = null;
                SettingsPic.BackColor = baseColor;
                SettingsLBL.BackColor = baseColor;
                SettingsSidePNL.BackColor = baseColor;
            }
            else if (index == 4) {
                DashboardPic.Image = SADMakaSys.Properties.Resources.DashboardLogo;
                DashboardLBL.ForeColor = Color.White;
                DasboardSidePNL.BackgroundImage = null;
                DashboardPic.BackColor = baseColor;
                DashboardLBL.BackColor = baseColor;
                DasboardSidePNL.BackColor = baseColor;
                EmployeesPic.Image = SADMakaSys.Properties.Resources.EmployeesLogo;
                EmployeesLBL.ForeColor = Color.White;
                EmployeesSidePNL.BackgroundImage = null;
                EmployeesPic.BackColor = baseColor;
                EmployeesLBL.BackColor = baseColor;
                EmployeesSidePNL.BackColor = baseColor;
                PayrollPic.Image = SADMakaSys.Properties.Resources.PayrollLogo;
                PayrollLBL.ForeColor = Color.White;
                PayrollSidePNL.BackgroundImage = null;
                PayrollPic.BackColor = baseColor;
                PayrollLBL.BackColor = baseColor;
                PayrollSidePNL.BackColor = baseColor;
                GuardSchedPic.Image = SADMakaSys.Properties.Resources.SchedLogo;
                GuardSchedLBL.ForeColor = Color.White;
                GuardSchedSidePNL.BackgroundImage = null;
                GuardSchedPic.BackColor = baseColor;
                GuardSchedLBL.BackColor = baseColor;
                GuardSchedSidePNL.BackColor = baseColor;
                SettingsPic.Image = SADMakaSys.Properties.Resources.SettingsLogo;
                SettingsLBL.ForeColor = Color.White;
                SettingsSidePNL.BackgroundImage = null;
                SettingsPic.BackColor = baseColor;
                SettingsLBL.BackColor = baseColor;
                SettingsSidePNL.BackColor = baseColor;
            }
            else if (index == 5) {
                DashboardPic.Image = SADMakaSys.Properties.Resources.DashboardLogo;
                DashboardLBL.ForeColor = Color.White;
                DasboardSidePNL.BackgroundImage = null;
                DashboardPic.BackColor = baseColor;
                DashboardLBL.BackColor = baseColor;
                DasboardSidePNL.BackColor = baseColor;
                EmployeesPic.Image = SADMakaSys.Properties.Resources.EmployeesLogo;
                EmployeesLBL.ForeColor = Color.White;
                EmployeesSidePNL.BackgroundImage = null;
                EmployeesPic.BackColor = baseColor;
                EmployeesLBL.BackColor = baseColor;
                EmployeesSidePNL.BackColor = baseColor;
                PayrollPic.Image = SADMakaSys.Properties.Resources.PayrollLogo;
                PayrollLBL.ForeColor = Color.White;
                PayrollSidePNL.BackgroundImage = null;
                PayrollPic.BackColor = baseColor;
                PayrollLBL.BackColor = baseColor;
                PayrollSidePNL.BackColor = baseColor;
                ClientPic.Image = SADMakaSys.Properties.Resources.ClientLogo;
                ClientLBL.ForeColor = Color.White;
                ClientSidePNL.BackgroundImage = null;
                ClientPic.BackColor = baseColor;
                ClientLBL.BackColor = baseColor;
                ClientSidePNL.BackColor = baseColor;
                SettingsPic.Image = SADMakaSys.Properties.Resources.SettingsLogo;
                SettingsLBL.ForeColor = Color.White;
                SettingsSidePNL.BackgroundImage = null;
                SettingsPic.BackColor = baseColor;
                SettingsLBL.BackColor = baseColor;
                SettingsSidePNL.BackColor = baseColor;
            }
            else if (index == 6) {
                DashboardPic.Image = SADMakaSys.Properties.Resources.DashboardLogo;
                DashboardLBL.ForeColor = Color.White;
                DasboardSidePNL.BackgroundImage = null;
                DashboardPic.BackColor = baseColor;
                DashboardLBL.BackColor = baseColor;
                DasboardSidePNL.BackColor = baseColor;
                EmployeesPic.Image = SADMakaSys.Properties.Resources.EmployeesLogo;
                EmployeesLBL.ForeColor = Color.White;
                EmployeesSidePNL.BackgroundImage = null;
                EmployeesPic.BackColor = baseColor;
                EmployeesLBL.BackColor = baseColor;
                EmployeesSidePNL.BackColor = baseColor;
                PayrollPic.Image = SADMakaSys.Properties.Resources.PayrollLogo;
                PayrollLBL.ForeColor = Color.White;
                PayrollSidePNL.BackgroundImage = null;
                PayrollPic.BackColor = baseColor;
                PayrollLBL.BackColor = baseColor;
                PayrollSidePNL.BackColor = baseColor;
                ClientPic.Image = SADMakaSys.Properties.Resources.ClientLogo;
                ClientLBL.ForeColor = Color.White;
                ClientSidePNL.BackgroundImage = null;
                ClientPic.BackColor = baseColor;
                ClientLBL.BackColor = baseColor;
                ClientSidePNL.BackColor = baseColor;
                GuardSchedPic.Image = SADMakaSys.Properties.Resources.SchedLogo;
                GuardSchedLBL.ForeColor = Color.White;
                GuardSchedSidePNL.BackgroundImage = null;
                GuardSchedPic.BackColor = baseColor;
                GuardSchedLBL.BackColor = baseColor;
                GuardSchedSidePNL.BackColor = baseColor;
            }
        }

        //Side bar buttons actions
        private void DashboardLBL_Click(object sender, EventArgs e) {
            HoverEverything(1);
            clickedIndex = 1;
            DashboardPage.Visible = true;
            EmployeesPage.Visible = false;
            PayrollPage.Visible = false;
            ClientPage.Visible = false;
            GuardSchedPage.Visible = false;
            SettingsPage.Visible = false;
            ControlBoxBTN.Text = "   =   Dashboard";
            currentPage = DashboardPage;
        }
        private void EmployeesLBL_Click(object sender, EventArgs e) {
            DashboardPage.Visible = false;
            EmployeesPage.Visible = true;
            PayrollPage.Visible = false;
            ClientPage.Visible = false;
            GuardSchedPage.Visible = false;
            SettingsPage.Visible = false;
            HoverEverything(2);
            clickedIndex = 2;
            ControlBoxBTN.Text = "   =   Employees";
            currentPage = EmployeesPage;
        }
        private void PayrollLBL_Click(object sender, EventArgs e) {
            DashboardPage.Visible = false;
            EmployeesPage.Visible = false;
            PayrollPage.Visible = true;
            ClientPage.Visible = false;
            GuardSchedPage.Visible = false;
            SettingsPage.Visible = false;
            HoverEverything(3);
            clickedIndex = 3;
            ControlBoxBTN.Text = "   =   Payroll";
            currentPage = PayrollPage;
        }
        private void ClientLBL_Click(object sender, EventArgs e) {
            DashboardPage.Visible = false;
            EmployeesPage.Visible = false;
            PayrollPage.Visible = false;
            ClientPage.Visible = true;
            GuardSchedPage.Visible = false;
            SettingsPage.Visible = false;
            HoverEverything(4);
            clickedIndex = 4;
            ControlBoxBTN.Text = "   =   Clients";
            currentPage = ClientPage;
        }
        private void GuardSchedLBL_Click(object sender, EventArgs e) {
            DashboardPage.Visible = false;
            EmployeesPage.Visible = false;
            PayrollPage.Visible = false;
            ClientPage.Visible = false;
            GuardSchedPage.Visible = true;
            SettingsPage.Visible = false;
            HoverEverything(5);
            clickedIndex = 5;
            ControlBoxBTN.Text = "   =   Assignments";
            currentPage = GuardSchedPage;
        }
        private void SettingsLBL_Click(object sender, EventArgs e) {
            DashboardPage.Visible = false;
            EmployeesPage.Visible = false;
            PayrollPage.Visible = false;
            ClientPage.Visible = false;
            GuardSchedPage.Visible = false;
            SettingsPage.Visible = true;
            HoverEverything(6);
            clickedIndex = 6;
            ControlBoxBTN.Text = "   =   Settings";
            currentPage = SettingsPage;
        }

        //Subpanel
        private void MinBTN_Click(object sender, EventArgs e) {
            if (!subpanelMinimized) currentSplitterDistance = currentPage.SplitterDistance;
            if (!SAnimationCHKBX.Checked) {
                if (!subpanelMinimized) {
                    ChangePanelMinimumSize(0);
                    ControlBoxBTN.Size = new Size(currentPage.SplitterDistance, 30);
                    CollapseSubPanels(0);
                }
                else CollapseSubPanels(currentSplitterDistance);
            } else if (SAnimationCHKBX.Checked) {
                if (!subpanelMinimized) ChangePanelMinimumSize(0);
                if (currentPage.Panel1Collapsed) { CollapseSubPanels(currentSplitterDistance); }
                SubpanelAnimation.Enabled = true;
            }
        }
        private void DashboardPage_SplitterMoved(object sender, SplitterEventArgs e) {
            if(!MaxBTNClicked) changeSubpanelsSize(DashboardPage.SplitterDistance);
        }
        private void EmployeesPage_SplitterMoved(object sender, SplitterEventArgs e) {
            if (!MaxBTNClicked) changeSubpanelsSize(EmployeesPage.SplitterDistance);
        }
        private void PayrollPage_SplitterMoved(object sender, SplitterEventArgs e) {
            if (!MaxBTNClicked) changeSubpanelsSize(PayrollPage.SplitterDistance);
        }
        private void ClientPage_SplitterMoved(object sender, SplitterEventArgs e) {
            if (!MaxBTNClicked) changeSubpanelsSize(ClientPage.SplitterDistance);
        }
        private void GuardSchedPage_SplitterMoved(object sender, SplitterEventArgs e) {
            if (!MaxBTNClicked) changeSubpanelsSize(GuardSchedPage.SplitterDistance);
        }
        private void SettingsPage_SplitterMoved(object sender, SplitterEventArgs e) {
            if (!MaxBTNClicked) changeSubpanelsSize(SettingsPage.SplitterDistance);
        }
        private void changeSubpanelsSize(int distance) {
            DashboardPage.SplitterDistance = distance;
            EmployeesPage.SplitterDistance = distance;
            ClientPage.SplitterDistance = distance;
            PayrollPage.SplitterDistance = distance;
            GuardSchedPage.SplitterDistance = distance;
            SettingsPage.SplitterDistance = distance;
            if (currentPage.SplitterDistance <= 150) {
                ControlBoxBTN.Size = new Size(150, 30);
                SearchPic.Location = new Point(150 + 20, 3);
                SearchBox.Location = new Point(150 + 50, 8);
            }
            else {
                ControlBoxBTN.Size = new Size(currentPage.SplitterDistance, 30);
                SearchPic.Location = new Point(currentPage.SplitterDistance + 20, 3);
                SearchBox.Location = new Point(currentPage.SplitterDistance + 50, 8);
            }
            if (SearchBox.Location.X > ControlBoxPanel.Size.Width - 320) {
                SearchBox.Visible = false;
                SearchPic.Visible = false;
            } else {
                SearchBox.Visible = true;
                SearchPic.Visible = true;
            }
            MaxBTNClicked = false;
        }
        private void CollapseSubPanels(int size) {
            if (size > 0) ChangePanelMinimumSize(150);
            if (currentPage.SplitterDistance == 0) currentPage.SplitterDistance = currentSplitterDistance;
            DashboardPage.SplitterDistance = size;
            EmployeesPage.SplitterDistance = size;
            PayrollPage.SplitterDistance = size;
            ClientPage.SplitterDistance = size;
            GuardSchedPage.SplitterDistance = size;
            SettingsPage.SplitterDistance = size;
            subpanelMinimized = !subpanelMinimized;
        }
        private void SubpanelAnimation_Tick(object sender, EventArgs e) {
            if (!subpanelMinimized) {
                if (currentPage.SplitterDistance > (int)(baseSpeed * AnimationMultiplier))
                    currentPage.SplitterDistance = currentPage.SplitterDistance - (int)(baseSpeed * AnimationMultiplier);
                else {
                    CollapseSubPanels(0);
                    SubpanelAnimation.Enabled = false;
                }
            } else if (subpanelMinimized) {
                if (currentPage.SplitterDistance + (int)(baseSpeed * AnimationMultiplier) < currentSplitterDistance)
                    currentPage.SplitterDistance = currentPage.SplitterDistance + (int)(baseSpeed * AnimationMultiplier);
                else {
                    CollapseSubPanels(currentSplitterDistance);
                    SubpanelAnimation.Enabled = false;
                }
            }
        }

        //=====Dashboard=====//
        //Animations
        private void DQuickAction1PNL_MouseEnter(object sender, EventArgs e) {
            DQuickAction1PNL.BackColor = accent;
        }
        private void DQuickAction2PNL_MouseEnter(object sender, EventArgs e) {
            DQuickAction2PNL.BackColor = accent;
        }
        private void DQuickAction3PNL_MouseEnter(object sender, EventArgs e) {
            DQuickAction3PNL.BackColor = accent;
        }
        private void DQuickAction4PNL_MouseEnter(object sender, EventArgs e) {
            DQuickAction4PNL.BackColor = accent;
        }
        private void DQuickAction1PNL_MouseLeave(object sender, EventArgs e) {
            DQuickAction1PNL.BackColor = baseColor;
            DQuickAction2PNL.BackColor = baseColor;
            DQuickAction3PNL.BackColor = baseColor;
            DQuickAction4PNL.BackColor = baseColor;
        }
        //Actions

        //Employees Panel=====// 
        //Animation

        //Payroll Panel=====// 
        //Animation

        //=====Client Panel=====// 
        //Animation

        //=====Guard Sched Panel=====// 
        //Animation

        //======Settings Panel=====//
        //Animations
        private void SDefaultThemeBTN_Click(object sender, EventArgs e) {
            SBlackThemeBTN.Text = String.Empty;
            SDarkGrayBTN.Text = String.Empty;
            SDefaultThemeBTN.Text = "/";
            SBlueBTN.Text = String.Empty;
            baseColor = Color.DarkSlateGray;
            darkBase = Color.FromArgb(0, 32, 33);
            ChangeTheme(baseColor, darkBase, accent);
            SSavedLBL.Visible = true;
        }
        private void SBlackThemeBTN_Click(object sender, EventArgs e) {
            SBlackThemeBTN.Text = "/";
            SDarkGrayBTN.Text = String.Empty;
            SDefaultThemeBTN.Text = String.Empty;
            SBlueBTN.Text = String.Empty;
            baseColor = Color.Black;
            darkBase = Color.FromArgb(64, 64, 64);
            ChangeTheme(baseColor, darkBase, accent);
            SSavedLBL.Visible = true;
        }
        private void SDarkGrayBTN_Click(object sender, EventArgs e) {
            SBlackThemeBTN.Text = String.Empty;
            SDarkGrayBTN.Text = "/";
            SDefaultThemeBTN.Text = String.Empty;
            SBlueBTN.Text = String.Empty;
            baseColor = Color.FromArgb(64, 64, 64);
            darkBase = Color.Black;
            ChangeTheme(baseColor, darkBase, accent);
            SSavedLBL.Visible = true;
        }
        private void SBlueBTN_Click(object sender, EventArgs e) {
            SBlackThemeBTN.Text = String.Empty;
            SDarkGrayBTN.Text = String.Empty;
            SDefaultThemeBTN.Text = String.Empty;
            SBlueBTN.Text = "/";
            baseColor = Color.FromArgb(0, 0, 64);
            darkBase = Color.MidnightBlue;
            ChangeTheme(baseColor, darkBase, accent);
            SSavedLBL.Visible = true;
        }
        private void SGoldAccentBTN_Click(object sender, EventArgs e) {
            SGoldAccentBTN.Text = "/";
            SPinkAccentBTN.Text = String.Empty;
            SBlueAccentBTN.Text = String.Empty;
            SGreenAccentBTN.Text = String.Empty;
            accent = Color.Goldenrod;
            dashboardHoverPic = Properties.Resources.DashboardLogoHover;
            employeesHoverPic = Properties.Resources.EmployeesLogoHover;
            payrollHoverPic = Properties.Resources.PayrollLogoHover;
            clientHoverPic = Properties.Resources.ClientLogoHover;
            guardSchedHoverPic = Properties.Resources.SchedLogoHover;
            settingsHoverPic = Properties.Resources.SettingsLogoHover;
            ChangeTheme(baseColor, darkBase, accent);
        }
        private void SPinkAccentBTN_Click(object sender, EventArgs e) {
            SGoldAccentBTN.Text = String.Empty;
            SPinkAccentBTN.Text = "/";
            SBlueAccentBTN.Text = String.Empty;
            SGreenAccentBTN.Text = String.Empty;
            accent = Color.DeepPink;
            dashboardHoverPic = Properties.Resources.DashboardLogoHoverPink;
            employeesHoverPic = Properties.Resources.EmployeesLogoHoverPink;
            payrollHoverPic = Properties.Resources.PayrollLogoHoverPink;
            clientHoverPic = Properties.Resources.ClientLogoHoverPink;
            guardSchedHoverPic = Properties.Resources.SchedLogoHoverPink;
            settingsHoverPic = Properties.Resources.SettingsLogoHoverPink;
            ChangeTheme(baseColor, darkBase, accent);
        }
        private void SBlueAccentBTN_Click(object sender, EventArgs e) {
            SGoldAccentBTN.Text = String.Empty;
            SPinkAccentBTN.Text = String.Empty;
            SBlueAccentBTN.Text = "/";
            SGreenAccentBTN.Text = String.Empty;
            accent = Color.DeepSkyBlue;
            dashboardHoverPic = Properties.Resources.DashboardLogoHoverBlue;
            employeesHoverPic = Properties.Resources.EmployeesLogoHoverBlue;
            payrollHoverPic = Properties.Resources.PayrollLogoHoverBlue;
            clientHoverPic = Properties.Resources.ClientLogoHoverBlue;
            guardSchedHoverPic = Properties.Resources.SchedLogoHoverBlue;
            settingsHoverPic = Properties.Resources.SettingsLogoHoverBlue;
            ChangeTheme(baseColor, darkBase, accent);
        }
        private void SGreenAccentBTN_Click(object sender, EventArgs e) {
            SGoldAccentBTN.Text = String.Empty;
            SPinkAccentBTN.Text = String.Empty;
            SBlueAccentBTN.Text = String.Empty;
            SGreenAccentBTN.Text = "/";
            accent = Color.Lime;
            dashboardHoverPic = Properties.Resources.DashboardLogoHoverGreen;
            employeesHoverPic = Properties.Resources.EmployeesLogoHoverGreen;
            payrollHoverPic = Properties.Resources.PayrollLogoHoverGreen;
            clientHoverPic = Properties.Resources.ClientLogoHoverGreen;
            guardSchedHoverPic = Properties.Resources.SchedLogoHoverGreen;
            settingsHoverPic = Properties.Resources.SettingsLogoHoverGreen;
            ChangeTheme(baseColor, darkBase, accent);
        }
        //Actions
        private void ChangeTheme(Color baseC, Color dark, Color accent) {
            baseColor = baseC;
            darkBase = dark;
            ControlBoxPanel.BackColor = dark;
            SearchBox.BackColor = dark;
            MaximizeBTN.BackColor = dark;
            MinimizeBTN.BackColor = dark;
            ControlBoxBTN.BackColor = accent;
            //SidePanel
            SidePanel.BackColor = baseC;
            SettingsSidePNL.BackColor = dark;
            SettingsPic.BackColor = dark;
            SettingsLBL.BackColor = dark;
            SettingsLBL.ForeColor = accent;
            SettingsPic.Image = settingsHoverPic;
            DashboardPic.BackColor = baseC;
            DashboardLBL.BackColor = baseC;
            DasboardSidePNL.BackColor = baseC;
            EmployeesPic.BackColor = baseC;
            EmployeesLBL.BackColor = baseC;
            EmployeesSidePNL.BackColor = baseC;
            ClientPic.BackColor = baseC;
            ClientLBL.BackColor = baseC;
            ClientSidePNL.BackColor = baseC;
            PayrollPic.BackColor = baseC;
            PayrollLBL.BackColor = baseC;
            PayrollSidePNL.BackColor = baseC;
            GuardSchedPic.BackColor = baseC;
            GuardSchedLBL.BackColor = baseC;
            GuardSchedSidePNL.BackColor = baseC;
            //Dashboard
            DDateLBL.ForeColor = baseC;
            DQuickActionsLBL.ForeColor = baseC;
            DQuickAction1PNL.BackColor = baseC;
            DQuickAction2PNL.BackColor = baseC;
            DQuickAction3PNL.BackColor = baseC;
            DQuickAction4PNL.BackColor = baseC;
            //Settings
            SAccentLBL.ForeColor = baseC;
            SThemeLBL2.ForeColor = baseC;
            SNetworkLBL.ForeColor = baseC;
            SIPConnectBTN.BackColor = baseC;
            SHosetIPLBL.ForeColor = baseC;
            SUsernameLBL.ForeColor = baseC;
            SPasswordLBL.ForeColor = baseC;
            SLookandfeelLBL.ForeColor = baseC;
            SExtensionLBL1.ForeColor = baseC;
            SExtensionLBL2.ForeColor = baseC;
            SAnimationLBL.ForeColor = baseC;
            SAnimationSpeedLBL.ForeColor = baseC;
            SDefaultLBL.ForeColor = baseC;
            SSlowLBL.ForeColor = baseC;
            SFastLBL.ForeColor = baseC;
            SSavedLBL.ForeColor = baseC;
        }
        private void SAnimationCHKBX_CheckedChanged(object sender, EventArgs e) {
            if (SAnimationCHKBX.Checked) SAnimationSpeedTRKBR.Enabled = true;
            else SAnimationSpeedTRKBR.Enabled = false;
        }
        private void ChangePanelMinimumSize(int size) {
            DashboardPage.Panel1MinSize = size;
            EmployeesPage.Panel1MinSize = size;
            PayrollPage.Panel1MinSize = size;
            ClientPage.Panel1MinSize = size;
            GuardSchedPage.Panel1MinSize = size;
            SettingsPage.Panel1MinSize = size;
        }
        private void SAnimationSpeedTRKBR_Scroll(object sender, EventArgs e) {
            if (SAnimationSpeedTRKBR.Value == 10) AnimationMultiplier = 150;
            else if (SAnimationSpeedTRKBR.Value >= 9) AnimationMultiplier = 100;
            else if (SAnimationSpeedTRKBR.Value >= 8) AnimationMultiplier = 75;
            else if (SAnimationSpeedTRKBR.Value >= 7) AnimationMultiplier = 50;
            else if (SAnimationSpeedTRKBR.Value >= 6) AnimationMultiplier = 25;
            else if (SAnimationSpeedTRKBR.Value >= 5) AnimationMultiplier = 10;
            else if (SAnimationSpeedTRKBR.Value >= 4) AnimationMultiplier = 8;
            else if (SAnimationSpeedTRKBR.Value >= 3) AnimationMultiplier = 7;
            else if (SAnimationSpeedTRKBR.Value >= 2) AnimationMultiplier = 5;
            else if (SAnimationSpeedTRKBR.Value >= 1) AnimationMultiplier = 3;
            else if (SAnimationSpeedTRKBR.Value >= 0) AnimationMultiplier = 1;
        }
        private void SIPConnectBTN_Click(object sender, EventArgs e) {
            PopupMessage.showDialog("Change Database Host", "Are you sure you want to save the address?", MessageBoxButtons.YesNo);
        }
    }
}
