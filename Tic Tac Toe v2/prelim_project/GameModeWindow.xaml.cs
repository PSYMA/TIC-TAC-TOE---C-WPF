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
    /// Interaction logic for GameModeWindow.xaml
    /// </summary>
    public partial class GameModeWindow : Window {
        public GameModeWindow() {
            InitializeComponent();
            Random random = new Random();
            pointDeduction = random.Next(10, 21);
            pointDeduction /= 4;
        }
        public bool playerVsComputer = false;
        public bool ifPlay = false;
        public bool ifEndless = false;
        public double pointDeduction = 0.0;
        
        private void GameModeWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e) {
            if(_gameMode1RadioButton.IsChecked.Equals(false) && _gameMode2RadioButton.IsChecked.Equals(false)) {
                MessageBox.Show("Please select Game Mode", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (_gamePlay1RadioButton.IsChecked.Equals(false) && _gamePlay2RadioButton.IsChecked.Equals(false)) {
                MessageBox.Show("Please select Game Play", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
          
            ifPlay = true;
            this.Close();
        }

        private void BackToMainButton_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void ClassicMode_PreviewMouseDown(object sender, MouseButtonEventArgs e) {
            if (e.ClickCount.Equals(1)) {
                _gameMode1RadioButton.IsChecked = true;
            }
        }

        private void EndlessMode_PreviewMouseDown(object sender, MouseButtonEventArgs e) {
            if (e.ClickCount.Equals(1)) {
                _gameMode2RadioButton.IsChecked = true;
            }
        }

        private void PlayerVsPlayer_PreviewMouseDown(object sender, MouseButtonEventArgs e) {
            if (e.ClickCount.Equals(1)) {
                _gamePlay1RadioButton.IsChecked = true;
            }
        }

        private void PlayerVsComputer_PreviewMouseDown(object sender, MouseButtonEventArgs e) {
            if (e.ClickCount.Equals(1)) {
                _gamePlay2RadioButton.IsChecked = true;
            }
        }
    }
}
