using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace HomeWork_Focus_Timer
{
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _timer = new DispatcherTimer();
        private int _miliseconds = 0;
        List<int> ListOfTime = new List<int>() { 5, 10, 15, 20, 25, 30 };
        
        public MainWindow()
        {
            InitializeComponent();
            InitializeTimer();
            InitializeComboBox();
        }
        private void InitializeTimer()
        {
            _timer.Interval = TimeSpan.FromMilliseconds(15);
            _timer.Tick += Timer_Tick;
        }
        private void InitializeComboBox()
        {
            choiceOfTime.ItemsSource = ListOfTime;
            choiceOfTime.SelectedItem = ListOfTime[0];
        }
        private void CheckTime(int min)
        {
            int time = (int)choiceOfTime.SelectedItem;
            if (time == min)
            {
                _timer.Stop();
                MessageBox.Show("Время прошло!");
            }
        }
        private void Timer_Tick(object? sender, EventArgs e)
        {
            _miliseconds += 15;
            int totalSeconds = _miliseconds / 1000;
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;
            TextTimer.Text = $"{minutes:00}:{seconds:00}";
            CheckTime(minutes);
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            _timer.Start();
            choiceOfTime.IsEnabled = false;
        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
            _miliseconds = 0;
            TextTimer.Text = "00:00";
            choiceOfTime.IsEnabled = true;
        }
        
    }
}