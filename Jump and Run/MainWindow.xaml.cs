
using System.Windows;
using System.Windows.Threading;

namespace Jump_and_Run
{
    public partial class MainWindow : Window
    {
        private Controller Ctrl;

        public MainWindow()
        {
            InitializeComponent();
            Ctrl = new Controller();
            Ctrl.Startgame();

            DataContext = Ctrl;

            var t = new DispatcherTimer();
            t.Tick += Maintimer;
            t.Interval = new System.TimeSpan(0, 0, 0, 0, 1);
            t.Start();
        }

        private void Maintimer(object sender, System.EventArgs e)
        {
            Ctrl.Timer();
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Escape)
                System.Windows.Application.Current.Shutdown();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            Ctrl.Startgame();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}