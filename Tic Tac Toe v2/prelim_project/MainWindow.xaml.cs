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

namespace prelim_project {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public char[,] table;
        public StartGameWindow startGameWindow;
        public CongratulationWindow congratulationWindow;
        public AboutWindow aboutWindow;
        public HelpWindow helpWindow;
        public GameModeWindow gameModeWindow;
        public MainWindow() {
            try {
                InitializeComponent();
                startGameWindow = new StartGameWindow();
                congratulationWindow = new CongratulationWindow();
                aboutWindow = new AboutWindow();
                helpWindow = new HelpWindow();
                gameModeWindow = new GameModeWindow();
                table = new char[3, 3];
            } catch(Exception) {  }
        }

        private void StartGameButton_MouseEnter(object sender, MouseEventArgs e) {
            Mouse.OverrideCursor = Cursors.Hand;
        }

        private void StartGameButton_MouseLeave(object sender, MouseEventArgs e) {
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void HelpButton_MouseEnter(object sender, MouseEventArgs e) {
            Mouse.OverrideCursor = Cursors.Hand;
        }

        private void HelpButton_MouseLeave(object sender, MouseEventArgs e) {
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void AboutButton_MouseEnter(object sender, MouseEventArgs e) {
            Mouse.OverrideCursor = Cursors.Hand;
        }

        private void AboutButton_MouseLeave(object sender, MouseEventArgs e) {
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void ExitButton_MouseEnter(object sender, MouseEventArgs e) {
            Mouse.OverrideCursor = Cursors.Hand;
        }

        private void ExitButton_MouseLeave(object sender, MouseEventArgs e) {
            Mouse.OverrideCursor = Cursors.Arrow;
        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            Application.Current.Shutdown();
        }
        private void StartGameButton_Click(object sender, RoutedEventArgs e) {
            try {
                this.Hide();
                gameModeWindow.ShowDialog();
                // buttons from StartGameWindow
                startGameWindow._index00Button.IsEnabled = false;
                startGameWindow._index01Button.IsEnabled = false;
                startGameWindow._index02Button.IsEnabled = false;

                startGameWindow._index10Button.IsEnabled = false;
                startGameWindow._index11Button.IsEnabled = false;
                startGameWindow._index12Button.IsEnabled = false;

                startGameWindow._index20Button.IsEnabled = false;
                startGameWindow._index21Button.IsEnabled = false;
                startGameWindow._index22Button.IsEnabled = false;

                if (gameModeWindow.ifPlay) {
                    if (gameModeWindow._gameMode2RadioButton.IsChecked.Equals(false)) {
                        startGameWindow._player1ProgressBar.Opacity = 0.0;
                        startGameWindow._player2ProgressBar.Opacity = 0.0;
                        gameModeWindow.ifEndless = false;
                    }
                    else {
                        startGameWindow._player1Score1Button.Opacity = 0.0;
                        startGameWindow._player1Score2Button.Opacity = 0.0;
                        startGameWindow._player1Score3Button.Opacity = 0.0;
                        startGameWindow._player2Score1Button.Opacity = 0.0;
                        startGameWindow._player2Score2Button.Opacity = 0.0;
                        startGameWindow._player2Score3Button.Opacity = 0.0;
                        
                    }
                    if (gameModeWindow._gamePlay2RadioButton.IsChecked.Equals(true)) {
                        gameModeWindow.ifEndless = true;
                        startGameWindow._player2NicknameTextBox.Text = "Computer";
                        startGameWindow._player2NicknameTextBox.IsEnabled = false;
                        Random random = new Random();
                        int pieces = random.Next(startGameWindow.str.Length);
                        startGameWindow._player2ComboBox.IsEnabled = false;
                        startGameWindow._player2PiecesLabel.Content = new Image {
                            Source = new BitmapImage(new Uri("/prelim_project;component/Images/" + startGameWindow.str[pieces] + ".png", UriKind.Relative)),
                            VerticalAlignment = VerticalAlignment.Center,
                            Stretch = Stretch.Fill
                        };
                        startGameWindow.player2Piece = startGameWindow.str[pieces] + ".png";
                    }
                    startGameWindow.ShowDialog();
                   
                }
            
               
                gameModeWindow.ifPlay = false;
               
                gameModeWindow._gameMode1RadioButton.IsChecked = false;
                gameModeWindow._gameMode2RadioButton.IsChecked = false;
                gameModeWindow._gamePlay1RadioButton.IsChecked = false;
                gameModeWindow._gamePlay2RadioButton.IsChecked = false;
                this.Show();
            }catch(Exception) {  }
        }
        private void HelpButton_Click(object sender, RoutedEventArgs e) {
            try {
                this.Hide();
                helpWindow.ShowDialog();
                this.ShowDialog();
            }catch(Exception) {  }
        }
        private void AboutButton_Click(object sender, RoutedEventArgs e) {
            try {
                this.Hide();
                aboutWindow.ShowDialog();
                this.Show();
            }catch(Exception) {  }
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        
    }
}
