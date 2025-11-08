using System.Windows;

namespace Clicker_WPF
{
    public partial class MainWindow : Window
    {
        private int _counter = 0;
        public MainWindow()
        {
            InitializeComponent();
            UpdateCounterText();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _counter++;
            UpdateCounterText();
        }
        private void Button_Reset(object sender, RoutedEventArgs e)
        {
            _counter++;
            UpdateCounterText();
        }
        private void UpdateCounterText()
        {
            CounterText.Text = $"Счётчик: {_counter}";
        }
    }
}