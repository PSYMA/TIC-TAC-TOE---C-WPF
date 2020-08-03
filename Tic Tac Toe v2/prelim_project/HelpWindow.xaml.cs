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
    /// Interaction logic for HelpWindow.xaml
    /// </summary>
    public partial class HelpWindow : Window {
        int count = 0;
        void FirstPage() {
            _informationTextBlock.Text = "This is the Main Menu of the game\n\n" +
                                         "Click Start Game to Play\n\n" +
                                         "Click Help to know the mechanics of the game\n\n" +
                                         "Click About to know About the Developer\n\n" +
                                         "Click Exit to close the game";
            _imageLabel.Content = new Image {
                Source = new BitmapImage(new Uri("/prelim_project;component/Images/page1.png", UriKind.Relative)),
                VerticalAlignment = VerticalAlignment.Center,
                Stretch = Stretch.Fill
            };
        }
        void SecondPage() {
            _informationTextBlock.Text = "Game Mechanics\n\n" +
                                         "Both players must write their nickname/name\n\n" +
                                         "Both players must select their game pieces\n\n" +
                                         "The Game is BO5 first player gets 3 wins will get the match\n\n" +
                                         "Click the Play Game to start the game\n\n" +
                                         "Click the board to place your move, Have fun!";
            _imageLabel.Content = new Image {
                Source = new BitmapImage(new Uri("/prelim_project;component/Images/page2.png", UriKind.Relative)),
                VerticalAlignment = VerticalAlignment.Center,
                Stretch = Stretch.Fill
            };
        }
        void ThirdPage() {
            _informationTextBlock.Text = "This is what it looks like when the game is started\n\n" +
                                         "Win first before you get lose\n\n";
            _imageLabel.Content = new Image {
                Source = new BitmapImage(new Uri("/prelim_project;component/Images/page3.png", UriKind.Relative)),
                VerticalAlignment = VerticalAlignment.Center,
                Stretch = Stretch.Fill
            };
        }
        void FourthPage() {
            _informationTextBlock.Text = "This is what it looks like when the game is started\n\n" +
                                         "Player 1 wins the round\n\n";
            _imageLabel.Content = new Image {
                Source = new BitmapImage(new Uri("/prelim_project;component/Images/page4.png", UriKind.Relative)),
                VerticalAlignment = VerticalAlignment.Center,
                Stretch = Stretch.Fill
            };
        }
        void FifthPage() {
            _informationTextBlock.Text = "This is what it looks like when the game is started\n\n" +
                                         "Player 2 won the match\n\n";
            _imageLabel.Content = new Image {
                Source = new BitmapImage(new Uri("/prelim_project;component/Images/page5.png", UriKind.Relative)),
                VerticalAlignment = VerticalAlignment.Center,
                Stretch = Stretch.Fill
            };
        }
        void SixthPage() {
            _informationTextBlock.Text = "This is what it looks like when the game is started\n\n" +
                                         "No winner game is draw\n\n";
            _imageLabel.Content = new Image {
                Source = new BitmapImage(new Uri("/prelim_project;component/Images/page6.png", UriKind.Relative)),
                VerticalAlignment = VerticalAlignment.Center,
                Stretch = Stretch.Fill,
                UseLayoutRounding = true
            };
        }
        public HelpWindow() {
            InitializeComponent();
            FirstPage();
            count++;
        }

        private void HelpWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
            FirstPage();
            count = 0;
            count++;
            ifClickBack = false;
            x = true;
        }
        private void NextButton_Click(object sender, RoutedEventArgs e) {
            if(ifClickBack) {
                count++;
                ifClickBack = false;
            }
            if (count == 0) {
                FirstPage();
                count++;
            }
            else if(count == 1) {
                SecondPage();
                count++;
            }
            else if (count == 2) {
                ThirdPage();
                count++;
            }
            else if (count == 3) {
                FourthPage();
                count++;
            }
            else if (count == 4) {
                FifthPage();
                count++;
            }
            else if (count == 5) {
                SixthPage();
                count++;
            }
            if (count == 6) {
                count = 0;
            }
            x = false;
        }
        bool x = false;
        bool ifClickBack = false;
        private void BackButton_Click(object sender, RoutedEventArgs e) {
            if(count == 0) {
                count = 6;
            }
            ifClickBack = true;
            count--;
            if (!x) {
                count--;
                x = true;
            }
            if (count == 0) {
                FirstPage();
            }
            else if (count == 1) {
                SecondPage();
            }
            else if (count == 2) {
                ThirdPage();
            }
            else if (count == 3) {
                FourthPage();
            }
            else if (count == 4) {
                FifthPage();
            }
            else if (count == 5) {
                SixthPage();
            }
            if(count <= 0) {
                count = 0;
            }
        }
        private void BackToMainButton_Click(object sender, RoutedEventArgs e) {
         
            this.Close();
        }

        
    }
}
