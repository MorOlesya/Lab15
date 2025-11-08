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

namespace GameWPF
{
    public partial class MainWindow : Window
    {
        private const int _totalPairs = 10;
        private readonly DispatcherTimer _timer = new DispatcherTimer();
        private int _tenthsOfSecondsElapsed;
        private int _matchesFound;
        private readonly Random _random = new Random();
        TextBlock _lastTextBlockClicked;
        private bool _findingMatch = false;

        List<string> _originalEmojis = new List<string>()
            {
                "🐱", "🐱",
                "🐭", "🐭",
                "🦊", "🦊",
                "🐻‍", "🐻‍",
                "🐔", "🐔",
                "🦆", "🦆",
                "🦋", "🦋",
                "🐝", "🐝",
                "🕸", "🕸",
                "🐌", "🐌"
            };
        public MainWindow()
        {
            InitializeComponent();
            InitializeTimer();
            SetUpGame();
        }
        private void InitializeTimer()
        {

            _timer.Interval = TimeSpan.FromSeconds(0.1);
            _timer.Tick += Timer_Tick;
        }
        private void Timer_Tick(object? sender, EventArgs e)
        {
            _tenthsOfSecondsElapsed++;
            timeTextBlock.Text = $"{_tenthsOfSecondsElapsed / 10f:0.0s}";
            if (_matchesFound == _totalPairs)
            {
                _timer.Stop();
                timeTextBlock.Text += "- Play again?";
            }
        }
        private void AssignRandomEmojis()
        {
            var emojis = new List<string>(_originalEmojis);
            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                if (textBlock.Name != "timeTextBlock")
                {
                    textBlock.Visibility = Visibility.Visible;
                    int index = _random.Next(emojis.Count);
                    string nextEmoji = emojis[index];
                    textBlock.Text = nextEmoji;
                    emojis.RemoveAt(index);
                }
            }
        }
        private void SetUpGame()
        {
            AssignRandomEmojis();
            _timer.Start();
            _tenthsOfSecondsElapsed = 0;
            _matchesFound = 0;
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!(sender is TextBlock clickedTextBlock && clickedTextBlock.Visibility == Visibility.Visible))
                return;

            if (!_findingMatch)
            {
                clickedTextBlock.Visibility = Visibility.Hidden;
                _lastTextBlockClicked = clickedTextBlock;
                _findingMatch = true;
                return;
            }

            if (clickedTextBlock == _lastTextBlockClicked)
                return;

            if (clickedTextBlock.Text == _lastTextBlockClicked.Text)
            {
                clickedTextBlock.Visibility = Visibility.Hidden;
                _matchesFound++;
            }
            else
            {
                _lastTextBlockClicked.Visibility = Visibility.Visible;
            }
            _findingMatch = false;
        }

        private void timeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (_matchesFound == _totalPairs)
            {
                SetUpGame();
            }
        }
    }
}