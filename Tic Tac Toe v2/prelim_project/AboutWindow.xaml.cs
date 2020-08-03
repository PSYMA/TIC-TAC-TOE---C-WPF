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
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window {
        public AboutWindow() {
            InitializeComponent();
            _myPictureLabel.Content = new Image {
                Source = new BitmapImage(new Uri("/prelim_project;component/Images/myPic.png", UriKind.Relative)),
                VerticalAlignment = VerticalAlignment.Center,
                Stretch = Stretch.Fill
            };
             
        }

        private void AboutWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }

        private void BackToMainButton_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void BackToMainButton_MouseEnter(object sender, MouseEventArgs e) {
            Mouse.OverrideCursor = Cursors.Hand;
        }

        private void BackToMainButton_MouseLeave(object sender, MouseEventArgs e) {
            Mouse.OverrideCursor = Cursors.Arrow;
        }
    }
}
