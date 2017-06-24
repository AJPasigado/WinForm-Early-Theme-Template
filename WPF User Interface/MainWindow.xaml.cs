using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MSAMISUIWPF {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();
        }

        //Control Buttons
        private void SettingsBTN_Click(object sender, RoutedEventArgs e) {
            Window settings = new SettingsWindows();
            settings.Show();
        }
        private void CloseBTN_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
        private void MinBTN_Click(object sender, RoutedEventArgs e) {
            this.WindowState = WindowState.Minimized;
        }

        //Menu Buttons
        private void EmployeesBTN_Click(object sender, RoutedEventArgs e) {
            HoverButtons(1);
        }
        private void PayrollBTN_Click(object sender, RoutedEventArgs e) {
            HoverButtons(2);
        }
        private void ClientsBTN_Click(object sender, RoutedEventArgs e) {
            HoverButtons(3);
        }
        private void AssignmentsBTN_Click(object sender, RoutedEventArgs e) {
            HoverButtons(4);
        }
        private void HoverButtons(int index) {
            if (index != 1) EmployeesBTN.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFAEAEAE")); else EmployeesBTN.Foreground = Brushes.Black;
            if (index != 2) PayrollBTN.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFAEAEAE")); else PayrollBTN.Foreground = Brushes.Black;
            if (index != 3) ClientsBTN.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFAEAEAE")); else ClientsBTN.Foreground = Brushes.Black;
            if (index != 4) AssignmentsBTN.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFAEAEAE")); else AssignmentsBTN.Foreground = Brushes.Black;
        }

        private void Dashboard_Click(object sender, RoutedEventArgs e) {
        }
    }
}
