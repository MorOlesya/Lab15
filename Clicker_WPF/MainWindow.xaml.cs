using System.Windows;

namespace Clicker_WPF
{
    public partial class MainWindow : Window
    {
        private int _counter = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _counter++;
            CounterText.Text = $"Счётчик: {_counter}";
        }
    }
}