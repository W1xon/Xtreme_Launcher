using Launcher_NFS.Model;
using System;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Launcher_NFS.View
{
    /// <summary>
    /// Логика взаимодействия для ResourcesWindow.xaml
    /// </summary>
    public partial class ResourcesWindow : Window
    {
        private DispatcherTimer timer = new DispatcherTimer();
        private int scrollViewerValue;
        public ResourcesWindow()
        {
            InitializeComponent();
            TextBlockListRes.Text = FileProvider.ReadFile($"{string.Join("\\", Assembly.GetExecutingAssembly().Location.Split('\\').Where(x => !x.Contains(".exe")).ToList())}\\ResList.txt");
            timer.Tick += UpdateScrollText;
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Start();
        }
        private void UpdateScrollText(object sender, EventArgs e)
        {
            scrollViewerValue += 2;
            if (scrollViewerValue < ScrollViewer.ScrollableHeight)
            {
                ScrollViewer.ScrollToVerticalOffset(scrollViewerValue);
            }
            else
                timer.Stop();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlayClick();
            scrollViewerValue = 0;
            timer.Stop();
            Close();
        }
    }
}
