using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for StartGameWindow.xaml
    /// </summary>
    public partial class StartGameWindow : Window {  
        MainWindow window = Application.Current.Windows[0] as MainWindow;
        public string[] str = new string[]
            { "C", "C++", "CSharp", "Python", "Java", "Ruby", "karl", "prince1", "cat", "dog",
              "cat2", "monkey", "creature1", "creature2", "creature3", "creature4", "creature5",
              "Unknown1", "Unknown2"};
        Random random;
        string player1Piece = "";
        public string player2Piece = "";
        bool move = false; // false = player1, true = player2 or Computer
        int countWinPlayer1 = 0;
        int countWinPlayer2 = 0;
        int countMoves = 0;
        public void SetComboBoxAndOthers() {
            try {
                // comboBoxes
                _player1ComboBox.Items.Add("Select Pieces");
                _player1ComboBox.SelectedIndex = 0;
                _player2ComboBox.Items.Add("Select Pieces");
                _player2ComboBox.SelectedIndex = 0;
                for (int i = 0; i < str.Length; i++) {
                    _player1ComboBox.Items.Add(str[i]);
                    _player2ComboBox.Items.Add(str[i]);
                }
  
                // Others
                // player1
                _player1NicknameTextBox.Text = "Nickname";
                _player1NicknameTextBox.Foreground = Brushes.Gray;
                _player1PiecesLabel.IsEnabled = false;

                // player2
                _player2NicknameTextBox.Text = "Nickname";
                _player2NicknameTextBox.Foreground = Brushes.Gray;
                _player2PiecesLabel.IsEnabled = false;

                _messageTextBox.Text = "xxxxxxxxxx";
                _messageTextBox.Foreground = Brushes.Gray;

               
                
            } catch (Exception) { }
        }
        void messageWinner(char player) {
            try {
                if (player == 'X') {
                    window.congratulationWindow._winnerLabel.Content = _player1NicknameTextBox.Text + " Won this round";
                    window.congratulationWindow.ShowDialog();
                    
                }
                else if (player == 'O') {
                    window.congratulationWindow._winnerLabel.Content = _player2NicknameTextBox.Text + " Won this round";
                    window.congratulationWindow.ShowDialog();
                    
                }
               
                countMoves = 0;
            } catch (Exception) { }
        }
        void DetermineWinner() {  
            countMoves++;
            for (int i = 0; i < 3; i++) {
                // horizontal 
                // X = player1, O = player2
                if (window.table[i, 0] == 'X' && window.table[i, 1] == 'X' && window.table[i, 2] == 'X') {
                    _player2ProgressBar.Value -= window.gameModeWindow.pointDeduction;
                    _player1ProgressBar.Value += window.gameModeWindow.pointDeduction;
                    messageWinner('X');
                    BackToDefault('X');
                    player1Move.Clear();
                    for(int j = 1; j <= 9; j++) {
                        player1Move.Add(j);
                    }
                }
                else if (window.table[i, 0] == 'O' && window.table[i, 1] == 'O' && window.table[i, 2] == 'O') {
                    _player1ProgressBar.Value -= window.gameModeWindow.pointDeduction;
                    _player2ProgressBar.Value += window.gameModeWindow.pointDeduction;
                    messageWinner('O');
                    BackToDefault('O');
                    player1Move.Clear();
                    for (int j = 1; j <= 9; j++) {
                        player1Move.Add(j);
                    }
                }
                // vertical
                else if (window.table[0, i] == 'X' && window.table[1, i] == 'X' && window.table[2, i] == 'X') {
                    _player2ProgressBar.Value -= window.gameModeWindow.pointDeduction;
                    _player1ProgressBar.Value += window.gameModeWindow.pointDeduction;
                    messageWinner('X');
                    BackToDefault('X');
                    player1Move.Clear();
                    for (int j = 1; j <= 9; j++) {
                        player1Move.Add(j);
                    }
                }
                else if (window.table[0, i] == 'O' && window.table[1, i] == 'O' && window.table[2, i] == 'O') {
                    _player1ProgressBar.Value -= window.gameModeWindow.pointDeduction;
                    _player2ProgressBar.Value += window.gameModeWindow.pointDeduction;
                    messageWinner('O');
                    BackToDefault('O');
                    player1Move.Clear();
                    for (int j = 1; j <= 9; j++) {
                        player1Move.Add(j);
                    }
                }
            }
            // slanting
            if (window.table[0, 0] == 'X' && window.table[1, 1] == 'X' && window.table[2, 2] == 'X') {
                _player2ProgressBar.Value -= window.gameModeWindow.pointDeduction;
                _player1ProgressBar.Value += window.gameModeWindow.pointDeduction;
                messageWinner('X');
                BackToDefault('X');
                player1Move.Clear();
                for (int j = 1; j <= 9; j++) {
                    player1Move.Add(j);
                }
            }
            else if (window.table[0, 0] == 'O' && window.table[1, 1] == 'O' && window.table[2, 2] == 'O') {
                _player1ProgressBar.Value -= window.gameModeWindow.pointDeduction;
                _player2ProgressBar.Value += window.gameModeWindow.pointDeduction;
                messageWinner('O');
                BackToDefault('O');
                player1Move.Clear();
                for (int j = 1; j <= 9; j++) {
                    player1Move.Add(j);
                }
            }
            else if (window.table[0, 2] == 'O' && window.table[1, 1] == 'O' && window.table[2, 0] == 'O') {
                _player2ProgressBar.Value += window.gameModeWindow.pointDeduction;
                _player1ProgressBar.Value -= window.gameModeWindow.pointDeduction;
                messageWinner('O');
                BackToDefault('O');
                player1Move.Clear();
                for (int j = 1; j <= 9; j++) {
                    player1Move.Add(j);
                }
            }
            else if (window.table[0, 2] == 'X' && window.table[1, 1] == 'X' && window.table[2, 0] == 'X') {
                _player1ProgressBar.Value += window.gameModeWindow.pointDeduction;
                _player2ProgressBar.Value -= window.gameModeWindow.pointDeduction;
                messageWinner('X');
                BackToDefault('X');
                player1Move.Clear();
                for (int j = 1; j <= 9; j++) {
                    player1Move.Add(j);
                }
            }
            else if (countMoves == 9) {
                MessageBox.Show("Draw", "", MessageBoxButton.OK, MessageBoxImage.Information);
                SetButtonImage();
                countMoves = 0;
                player1Move.Clear();
                for (int j = 1; j <= 9; j++) {
                    player1Move.Add(j);
                }
            }
        }
        void BackToDefault() {
            _player1ComboBox.IsEnabled = true;
            _player2ComboBox.IsEnabled = true;
            _player1PiecesLabel.Content = "";
            _player2PiecesLabel.Content = "";
            _player1NicknameTextBox.IsEnabled = true;
            _player2NicknameTextBox.IsEnabled = true;
            countWinPlayer1 = 0;
            countWinPlayer2 = 0;
            _player1ComboBox.Items.Clear();
            _player2ComboBox.Items.Clear();
            _playGameButton.IsEnabled = true;
            _playGameButton.Content = "Play Game";
            _player2ProgressBar.Value = 50;
            _player1ProgressBar.Value = 50;

            _player1Score1Button.Background = null;
            _player1Score2Button.Background = null;
            _player1Score3Button.Background = null;
            _player2Score1Button.Background = null;
            _player2Score2Button.Background = null;
            _player2Score3Button.Background = null;
            SetComboBoxAndOthers();
        } 
        void BackToDefault(char player) {
            try {
                if (_player1ProgressBar.Value <= 0) {
                    window.congratulationWindow._winnerLabel.Content = _player2NicknameTextBox.Text + " Won the Match";
                    window.congratulationWindow.ShowDialog();
                    window.startGameWindow._player1ProgressBar.Value = 50;
                    window.startGameWindow._player2ProgressBar.Value = 50;

                    player1Move.Clear();
                    for (int j = 1; j <= 9; j++) {
                        player1Move.Add(j);
                    }
                    SetComboBoxAndOthers();
                    BackToDefault();
                    this.Close();
                    countWinPlayer2 = -1;
                    countWinPlayer1 = -1;
                    _player1Score1Button.Background = null;
                    _player1Score2Button.Background = null;
                    _player1Score3Button.Background = null;
                    _player2Score1Button.Background = null;
                    _player2Score2Button.Background = null;
                    _player2Score3Button.Background = null;
                }
                else if (_player2ProgressBar.Value <= 0) {
                    window.congratulationWindow._winnerLabel.Content = _player1NicknameTextBox.Text + " Won the Match";
                    window.congratulationWindow.ShowDialog();
                    window.startGameWindow._player1ProgressBar.Value = 50;
                    window.startGameWindow._player2ProgressBar.Value = 50;

                    player1Move.Clear();
                    for (int j = 1; j <= 9; j++) {
                        player1Move.Add(j);
                    }
                    SetComboBoxAndOthers();
                    BackToDefault();
                    this.Close();
                    countWinPlayer1 = -1;
                    countWinPlayer2 = -1;
                    _player1Score1Button.Background = null;
                    _player1Score2Button.Background = null;
                    _player1Score3Button.Background = null;
                    _player2Score1Button.Background = null;
                    _player2Score2Button.Background = null;
                    _player2Score3Button.Background = null;
                }
                if (window.gameModeWindow._gameMode2RadioButton.IsChecked.Equals(false)) {
                    if (player == 'X') {
                        // player1
                        countWinPlayer1++;
                        if (countWinPlayer1 == 1) {
                            _player1Score1Button.Background = Brushes.Yellow;
                        }
                        else if (countWinPlayer1 == 2) {
                            _player1Score2Button.Background = Brushes.Yellow;
                        }
                        else if (countWinPlayer1 == 3) {
                            _player1Score3Button.Background = Brushes.Yellow;
                            window.congratulationWindow._winnerLabel.Content = _player1NicknameTextBox.Text + " Won the Match";
                            window.congratulationWindow.ShowDialog();
                            player1Move.Clear();
                            for (int j = 1; j <= 9; j++) {
                                player1Move.Add(j);
                            }
                            SetComboBoxAndOthers();
                            BackToDefault();
                            this.Close();

                        }
                    }
                    else if (player == 'O') {
                        // player2
                        countWinPlayer2++;
                        if (countWinPlayer2 == 1) {
                            _player2Score1Button.Background = Brushes.Yellow;
                        }
                        else if (countWinPlayer2 == 2) {
                            _player2Score2Button.Background = Brushes.Yellow;
                        }
                        else if (countWinPlayer2 == 3) {
                            _player2Score3Button.Background = Brushes.Yellow;
                            window.congratulationWindow._winnerLabel.Content = _player2NicknameTextBox.Text + " Won the Match";
                            window.congratulationWindow.ShowDialog();
                            player1Move.Clear();
                            for (int j = 1; j <= 9; j++) {
                                player1Move.Add(j);
                            }
                            SetComboBoxAndOthers();
                            BackToDefault();
                            this.Close();
                        }
                    }
                }
                SetButtonImage();
            } catch (Exception) { }
        }

        List<int> player1Move = new List<int>();
        void ComputerMoves() {
            for (int i = 0; i < player1Move.Count; i++) {
                int j = random.Next(player1Move.Count);
                int temp = player1Move[i];
                player1Move[i] = player1Move[j];
                player1Move[j] = temp;
            }
            int index = random.Next(player1Move.Count);
            if (player1Move[index] == 1) {
                _index00Button.Content = new Image {
                    Source = new BitmapImage(new Uri("/Images/" + player2Piece, UriKind.Relative)),
                    VerticalAlignment = VerticalAlignment.Center,
                    Stretch = Stretch.Fill
                };
                window.table[0, 0] = 'O';
                _index00Button.IsEnabled = false;
                player1Move.Remove(1);
            }
            else if (player1Move[index] == 2) {
                _index01Button.Content = new Image {
                    Source = new BitmapImage(new Uri("/Images/" + player2Piece, UriKind.Relative)),
                    VerticalAlignment = VerticalAlignment.Center,
                    Stretch = Stretch.Fill
                };
                window.table[0, 1] = 'O';
                _index01Button.IsEnabled = false;
                player1Move.Remove(2);
            }
            else if (player1Move[index] == 3) {
                _index02Button.Content = new Image {
                    Source = new BitmapImage(new Uri("/Images/" + player2Piece, UriKind.Relative)),
                    VerticalAlignment = VerticalAlignment.Center,
                    Stretch = Stretch.Fill
                };
                window.table[0, 2] = 'O';
                _index02Button.IsEnabled = false;
                player1Move.Remove(3);
            }
            else if (player1Move[index] == 4) {
                _index10Button.Content = new Image {
                    Source = new BitmapImage(new Uri("/Images/" + player2Piece, UriKind.Relative)),
                    VerticalAlignment = VerticalAlignment.Center,
                    Stretch = Stretch.Fill
                };
                window.table[1, 0] = 'O';
                _index10Button.IsEnabled = false;
                player1Move.Remove(4);
            }
            else if (player1Move[index] == 5) {
                _index11Button.Content = new Image {
                    Source = new BitmapImage(new Uri("/Images/" + player2Piece, UriKind.Relative)),
                    VerticalAlignment = VerticalAlignment.Center,
                    Stretch = Stretch.Fill
                };
                window.table[1, 1] = 'O';
                _index11Button.IsEnabled = false;
                player1Move.Remove(5);
            }
            else if (player1Move[index] == 6) {
                _index12Button.Content = new Image {
                    Source = new BitmapImage(new Uri("/Images/" + player2Piece, UriKind.Relative)),
                    VerticalAlignment = VerticalAlignment.Center,
                    Stretch = Stretch.Fill
                };
                window.table[1, 2] = 'O';
                _index12Button.IsEnabled = false;
                player1Move.Remove(6);
            }
            else if (player1Move[index] == 7) {
                _index20Button.Content = new Image {
                    Source = new BitmapImage(new Uri("/Images/" + player2Piece, UriKind.Relative)),
                    VerticalAlignment = VerticalAlignment.Center,
                    Stretch = Stretch.Fill
                };
                window.table[2, 0] = 'O';
                _index20Button.IsEnabled = false;
                player1Move.Remove(7);
            }
            else if (player1Move[index] == 8) {
                _index21Button.Content = new Image {
                    Source = new BitmapImage(new Uri("/Images/" + player2Piece, UriKind.Relative)),
                    VerticalAlignment = VerticalAlignment.Center,
                    Stretch = Stretch.Fill
                };
                window.table[2, 1] = 'O';
                _index21Button.IsEnabled = false;
                player1Move.Remove(8);
            }
            else if (player1Move[index] == 9) {
                _index22Button.Content = new Image {
                    Source = new BitmapImage(new Uri("/Images/" + player2Piece, UriKind.Relative)),
                    VerticalAlignment = VerticalAlignment.Center,
                    Stretch = Stretch.Fill
                };
                window.table[2, 2] = 'O';
                _index22Button.IsEnabled = false;
                player1Move.Remove(9);
            }
            for (int i = 0; i < player1Move.Count; i++) {
                int j = random.Next(player1Move.Count);
                int temp = player1Move[i];
                player1Move[i] = player1Move[j];
                player1Move[j] = temp;
            }
        }
        void ButtonImageChanged(Button button) {  // players moves
            try {
                if (window.gameModeWindow._gamePlay2RadioButton.IsChecked.Equals(true)) {
                    button.Content = new Image {
                        Source = new BitmapImage(new Uri("/Images/" + player1Piece, UriKind.Relative)),
                        VerticalAlignment = VerticalAlignment.Center,
                        Stretch = Stretch.Fill
                    };
                    ComputerMoves();
                    countMoves++;
                   
                }
                else {
                    if (move) {
                        button.Content = new Image {
                            Source = new BitmapImage(new Uri("/Images/" + player2Piece, UriKind.Relative)),
                            VerticalAlignment = VerticalAlignment.Center,
                            Stretch = Stretch.Fill
                        };
                    }
                    else {
                        button.Content = new Image {
                            Source = new BitmapImage(new Uri("/Images/" + player1Piece, UriKind.Relative)),
                            VerticalAlignment = VerticalAlignment.Center,
                            Stretch = Stretch.Fill
                        };
                    }
                }
               
                button.IsEnabled = false;
            } catch(Exception) {  }
        }
        void ClickButton(string button) {
            try {
                if (button == "Index00Button") {
                    ButtonImageChanged(_index00Button);   
                }
                else if (button == "Index01Button") {
                    ButtonImageChanged(_index01Button);
                }
                else if (button == "Index02Button") {
                    ButtonImageChanged(_index02Button);
                }
                else if (button == "Index10Button") {
                    ButtonImageChanged(_index10Button);
                }
                else if (button == "Index11Button") {
                    ButtonImageChanged(_index11Button); 
                }
                else if (button == "Index12Button") {
                    ButtonImageChanged(_index12Button);
                }
                else if (button == "Index20Button") {
                    ButtonImageChanged(_index20Button);
                }
                else if (button == "Index21Button") {
                    ButtonImageChanged(_index21Button);
                }
                else if (button == "Index22Button") {
                    ButtonImageChanged(_index22Button);
                }
                string index = new String(button.Where(Char.IsDigit).ToArray());
                int row = int.Parse(index.ToCharArray()[0].ToString());
                int column = int.Parse(index.ToCharArray()[1].ToString());
                
                if (window.gameModeWindow._gamePlay2RadioButton.IsChecked.Equals(false)) {

                    if (_messageTextBox.Text == _player2NicknameTextBox.Text + " turns to move") {
                        _messageTextBox.Text = _player1NicknameTextBox.Text + " turns to move";
                    }
                    else {
                        _messageTextBox.Text = _player2NicknameTextBox.Text + " turns to move";
                    }
                    if (move) {
                        window.table[row, column] = 'O';
                        move = false;
                    }
                    else {
                        window.table[row, column] = 'X';
                        move = true;
                    }
                }
                else {
                    window.table[row, column] = 'X';
                }
                DetermineWinner();
               
            } catch(Exception) {  }
        }
        void SetButtonImage() {
            try {
                // button name
                _index00Button.Content = new Image {                        
                    Source = new BitmapImage(new Uri("/prelim_project;component/Images/O.png", UriKind.Relative)),
                    VerticalAlignment = VerticalAlignment.Center,
                    Stretch = Stretch.Fill
                };
                _index01Button.Content = new Image {
                    Source = new BitmapImage(new Uri("/prelim_project;component/Images/wood.png", UriKind.Relative)),
                    VerticalAlignment = VerticalAlignment.Center,
                    Stretch = Stretch.Fill
                };
                _index02Button.Content = new Image {
                    Source = new BitmapImage(new Uri("/prelim_project;component/Images/X.png", UriKind.Relative)),
                    VerticalAlignment = VerticalAlignment.Center,
                    Stretch = Stretch.Fill
                };

                _index10Button.Content = new Image {
                    Source = new BitmapImage(new Uri("/prelim_project;component/Images/wood.png", UriKind.Relative)),
                    VerticalAlignment = VerticalAlignment.Center,
                    Stretch = Stretch.Fill
                };
                _index11Button.Content = new Image {
                    Source = new BitmapImage(new Uri("/prelim_project;component/Images/wood.png", UriKind.Relative)),
                    VerticalAlignment = VerticalAlignment.Center,
                    Stretch = Stretch.Fill
                };
                _index12Button.Content = new Image {
                    Source = new BitmapImage(new Uri("/prelim_project;component/Images/wood.png", UriKind.Relative)),
                    VerticalAlignment = VerticalAlignment.Center,
                    Stretch = Stretch.Fill
                };

                _index20Button.Content = new Image {
                    Source = new BitmapImage(new Uri("/prelim_project;component/Images/O.png", UriKind.Relative)),
                    VerticalAlignment = VerticalAlignment.Center,
                    Stretch = Stretch.Fill
                };
                _index21Button.Content = new Image {
                    Source = new BitmapImage(new Uri("/prelim_project;component/Images/wood.png", UriKind.Relative)),
                    VerticalAlignment = VerticalAlignment.Center,
                    Stretch = Stretch.Fill
                };
                _index22Button.Content = new Image {
                    Source = new BitmapImage(new Uri("/prelim_project;component/Images/X.png", UriKind.Relative)),
                    VerticalAlignment = VerticalAlignment.Center,
                    Stretch = Stretch.Fill
                };
                _index00Button.IsEnabled = true;
                _index01Button.IsEnabled = true;
                _index02Button.IsEnabled = true;

                _index10Button.IsEnabled = true;
                _index11Button.IsEnabled = true;
                _index12Button.IsEnabled = true;

                _index20Button.IsEnabled = true;
                _index21Button.IsEnabled = true;
                _index22Button.IsEnabled = true;

                window.table = new char[3, 3];
            }catch(Exception) {  }
        }
        public StartGameWindow() {
            try {
                InitializeComponent();
                SetButtonImage();
                SetComboBoxAndOthers();
                for(int i = 1; i <= 9; i++) {
                    player1Move.Add(i);
                }
                random = new Random();
            } catch(Exception) {  }
        }
        private void StartGameWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            this.Visibility = Visibility.Hidden;
            e.Cancel = true;
            window.gameModeWindow.ifPlay = false;
            window.gameModeWindow._gameMode1RadioButton.IsChecked = false;
            window.gameModeWindow._gameMode2RadioButton.IsChecked = false;
            window.gameModeWindow._gamePlay1RadioButton.IsChecked = false;
            window.gameModeWindow._gamePlay2RadioButton.IsChecked = false;
            window.startGameWindow._player1ProgressBar.Opacity = 100.0;
            window.startGameWindow._player2ProgressBar.Opacity = 100.0;
            window.startGameWindow._player1Score1Button.Opacity = 100.0;
            window.startGameWindow._player1Score2Button.Opacity = 100.0;
            window.startGameWindow._player1Score3Button.Opacity = 100.0;
            window.startGameWindow._player2Score1Button.Opacity = 100.0;
            window.startGameWindow._player2Score2Button.Opacity = 100.0;
            window.startGameWindow._player2Score3Button.Opacity = 100.0;
            window.gameModeWindow._gamePlay2RadioButton.IsChecked = false;


            window.startGameWindow._player2NicknameTextBox.Text = "Nickname";
            window.startGameWindow._player2NicknameTextBox.IsEnabled = true;
            window.startGameWindow._player2ComboBox.IsEnabled = true;
            window.startGameWindow._player2PiecesLabel.Content = "";

            countWinPlayer1 = 0;
            countWinPlayer2 = 0;
        }

        private void Player1Combox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            try {
                if (_player1ComboBox.SelectedItem != null) {
                    foreach (var value in str) {
                        if (value == _player1ComboBox.SelectedItem.ToString()) {
                            _player1PiecesLabel.Content = new Image {
                                Source = new BitmapImage(new Uri("/prelim_project;component/Images/" + value + ".png", UriKind.Relative)),
                                VerticalAlignment = VerticalAlignment.Center,
                                Stretch = Stretch.Fill
                            };
                            player1Piece = value + ".png";
                        }
                    }
                }
                if (_player1ComboBox.SelectedIndex == 0) {
                    _player1PiecesLabel.Content = null;
                }
            }catch(Exception) {  }
        }
        private void Player2ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            try {
                if (_player2ComboBox.SelectedItem != null) {
                    foreach (var value in str) {
                        if (value == _player2ComboBox.SelectedItem.ToString()) {
                            _player2PiecesLabel.Content = new Image {
                                Source = new BitmapImage(new Uri("/prelim_project;component/Images/" + value + ".png", UriKind.Relative)),
                                VerticalAlignment = VerticalAlignment.Center,
                                Stretch = Stretch.Fill
                            };
                            player2Piece = value + ".png";
                        }
                    }

                }
                if (_player2ComboBox.SelectedIndex == 0) {
                    _player2PiecesLabel.Content = null;
                }
            }catch(Exception) {  }
        }
        private void Index00Button_Click(object sender, RoutedEventArgs e) {
            player1Move.Remove(1);
            ClickButton("Index00Button");
        }

        private void Index01Button_Click(object sender, RoutedEventArgs e) {
            player1Move.Remove(2);
            ClickButton("Index01Button");
        }

        private void Index02Button_Click(object sender, RoutedEventArgs e) {
            player1Move.Remove(3);
            ClickButton("Index02Button");
        }

        private void Index10Button_Click(object sender, RoutedEventArgs e) {
            player1Move.Remove(4);
            ClickButton("Index10Button");
        }

        private void Index11Button_Click(object sender, RoutedEventArgs e) {
            player1Move.Remove(5);
            ClickButton("Index11Button");
        }

        private void Index12Button_Click(object sender, RoutedEventArgs e) {
            player1Move.Remove(6);
            ClickButton("Index12Button");
        }

        private void Index20Button_Click(object sender, RoutedEventArgs e) {
            player1Move.Remove(7);
            ClickButton("Index20Button");
        }

        private void Index21Button_Click(object sender, RoutedEventArgs e) {
            player1Move.Remove(8);
            ClickButton("Index21Button");
        }

        private void Index22Button_Click(object sender, RoutedEventArgs e) {
            player1Move.Remove(9);
            ClickButton("Index22Button");
        }

        private void PlayGameButton_Click(object sender, RoutedEventArgs e) {
            try {
                 
                if (_player1ComboBox.SelectedIndex <= 0) {
                    MessageBox.Show("Player1 please select your game pieces", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (_player2ComboBox.SelectedIndex <= 0 && window.gameModeWindow._gamePlay2RadioButton.IsChecked.Equals(false)) {
                    MessageBox.Show("Player2 please select your game pieces", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (_player1NicknameTextBox.Text == "" || _player1NicknameTextBox.Text == "Nickname") {
                    MessageBox.Show("Player1 please enter your nickname", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (_player2NicknameTextBox.Text == "" || _player2NicknameTextBox.Text == "Nickname") {
                    MessageBox.Show("Player2 please enter your nickname", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (_player1NicknameTextBox.Text == _player2NicknameTextBox.Text) {
                    MessageBox.Show("Players nickname can't be the same", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (_player1ComboBox.SelectedItem == _player2ComboBox.SelectedItem) {
                    MessageBox.Show("Players game pieces can't be the same", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if(player1Piece == player2Piece) {
                    MessageBox.Show("Players game pieces can't be the same", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                _player1ComboBox.IsEnabled = false;
                _player1NicknameTextBox.IsEnabled = false;

                _player2ComboBox.IsEnabled = false;
                _player2NicknameTextBox.IsEnabled = false;

                _messageTextBox.Text = _player1NicknameTextBox.Text + " turns to move";
                _messageTextBox.Foreground = Brushes.Black;
                _messageTextBox.IsEnabled = false;

                _playGameButton.IsEnabled = false;
                _playGameButton.Content = "Game has Started!";
                _index00Button.IsEnabled = true;
                _index01Button.IsEnabled = true;
                _index02Button.IsEnabled = true;

                _index10Button.IsEnabled = true;
                _index11Button.IsEnabled = true;
                _index12Button.IsEnabled = true;

                _index20Button.IsEnabled = true;
                _index21Button.IsEnabled = true;
                _index22Button.IsEnabled = true;
                //MessageBox.Show("Game is On, Have fun!!", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }catch(Exception) {  }
        }
        private void Player1NickNameTextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e) {
            try {
                if (e.ClickCount == 1) {
                    _player1NicknameTextBox.Text = "";
                    _player1NicknameTextBox.Foreground = Brushes.Blue;
                    _player1NicknameTextBox.FontSize = 18;
                }
            }catch(Exception) {  }
        }
        private void Player2NickNameTextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e) {
            try {
                if (e.ClickCount == 1) {
                    _player2NicknameTextBox.Text = "";
                    _player2NicknameTextBox.Foreground = Brushes.Red;
                    _player2NicknameTextBox.FontSize = 18;
                }
            }catch(Exception) {  }
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e) {
            countWinPlayer1 = 0;
            countWinPlayer2 = 0;
            countMoves = 0;
            move = false;
            SetButtonImage();
            SetComboBoxAndOthers();
            BackToDefault();
            _player1Score1Button.Opacity = 0.0;
            _player1Score2Button.Opacity = 0.0;
            _player1Score3Button.Opacity = 0.0;
            _player2Score1Button.Opacity = 0.0;
            _player2Score2Button.Opacity = 0.0;
            _player2Score3Button.Opacity = 0.0;
            if (window.gameModeWindow._gamePlay2RadioButton.IsChecked.Equals(true)) {
                window.gameModeWindow.ifEndless = true;
               _player2NicknameTextBox.Text = "Computer";
               _player2NicknameTextBox.IsEnabled = false;
                Random random = new Random();
                int pieces = random.Next(str.Length);
                _player2ComboBox.IsEnabled = false;
                _player2PiecesLabel.Content = new Image {
                    Source = new BitmapImage(new Uri("/prelim_project;component/Images/" + str[pieces] + ".png", UriKind.Relative)),
                    VerticalAlignment = VerticalAlignment.Center,
                    Stretch = Stretch.Fill
                };
                player2Piece = str[pieces] + ".png";
            }
            if (window.gameModeWindow._gameMode1RadioButton.IsChecked.Equals(true)) {
                _player1Score1Button.Opacity = 100.0;
                _player1Score2Button.Opacity = 100.0;
                _player1Score3Button.Opacity = 100.0;
                _player2Score1Button.Opacity = 100.0;
                _player2Score2Button.Opacity = 100.0;
                _player2Score3Button.Opacity = 100.0;
            }
            _index00Button.IsEnabled = false;
            _index01Button.IsEnabled = false;
            _index02Button.IsEnabled = false;

            _index10Button.IsEnabled = false;
            _index11Button.IsEnabled = false;
            _index12Button.IsEnabled = false;

            _index20Button.IsEnabled = false;
            _index21Button.IsEnabled = false;
            _index22Button.IsEnabled = false;
        }

        private void BackToMainButton_Click(object sender, RoutedEventArgs e) {
            countWinPlayer1 = 0;
            countWinPlayer2 = 0;
            countMoves = 0;
            move = false;
            SetButtonImage();
            SetComboBoxAndOthers();
            BackToDefault();
            _player1Score1Button.Opacity = 0.0;
            _player1Score2Button.Opacity = 0.0;
            _player1Score3Button.Opacity = 0.0;
            _player2Score1Button.Opacity = 0.0;
            _player2Score2Button.Opacity = 0.0;
            _player2Score3Button.Opacity = 0.0;
            if (window.gameModeWindow._gamePlay2RadioButton.IsChecked.Equals(true)) {
                window.gameModeWindow.ifEndless = true;
                _player2NicknameTextBox.Text = "Computer";
                _player2NicknameTextBox.IsEnabled = false;
                Random random = new Random();
                int pieces = random.Next(str.Length);
                _player2ComboBox.IsEnabled = false;
                _player2PiecesLabel.Content = new Image {
                    Source = new BitmapImage(new Uri("/prelim_project;component/Images/" + str[pieces] + ".png", UriKind.Relative)),
                    VerticalAlignment = VerticalAlignment.Center,
                    Stretch = Stretch.Fill
                };
                player2Piece = str[pieces] + ".png";
            }
            if (window.gameModeWindow._gameMode1RadioButton.IsChecked.Equals(true)) {
                _player1Score1Button.Opacity = 100.0;
                _player1Score2Button.Opacity = 100.0;
                _player1Score3Button.Opacity = 100.0;
                _player2Score1Button.Opacity = 100.0;
                _player2Score2Button.Opacity = 100.0;
                _player2Score3Button.Opacity = 100.0;
            }
            _index00Button.IsEnabled = false;
            _index01Button.IsEnabled = false;
            _index02Button.IsEnabled = false;

            _index10Button.IsEnabled = false;
            _index11Button.IsEnabled = false;
            _index12Button.IsEnabled = false;

            _index20Button.IsEnabled = false;
            _index21Button.IsEnabled = false;
            _index22Button.IsEnabled = false;
            this.Close();
        }
    }
}
