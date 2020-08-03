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
using System.Windows.Shapes;

namespace prelim_project {
    /// <summary>
    /// Interaction logic for CongratulationWindow.xaml
    /// </summary>
    public partial class CongratulationWindow : Window {
        public CongratulationWindow() {
            InitializeComponent();
        }

        private void CongratulationWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }

        private void BackToMainButton_Click(object sender, RoutedEventArgs e) {
            MainWindow window = Application.Current.Windows[0] as MainWindow;
            this.Close();
 
        }
    }
}
