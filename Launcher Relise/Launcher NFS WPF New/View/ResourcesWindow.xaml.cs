using Launcher_NFS_WPF_New.Model;
using System;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Launcher_NFS_WPF_New.View
{
    /// <summary>
    /// Логика взаимодействия для ResourcesWindow.xaml
    /// </summary>
    public partial class ResourcesWindow : Window
    {
        private ButtonSoundler soundPlayer = new ButtonSoundler("View\\Res\\BtnClick.wav");
        private DispatcherTimer timer = new DispatcherTimer();
        private int scrollViewerValue;
        public ResourcesWindow()
        {
            InitializeComponent();
            TextBlockListRes.Text = FileManager.ReadFile($"{string.Join("\\", Assembly.GetExecutingAssembly().Location.Split('\\').Where(x => !x.Contains(".exe")).ToList())}\\ResList.txt");
            timer.Tick += UpdateScrollText;
            timer.Interval = TimeSpan.FromMilliseconds(5);
            timer.Start(); 
        }
        private void UpdateScrollText(object sender, System.EventArgs e)
        {
            scrollViewerValue += 3;
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
            soundPlayer.Play();
            scrollViewerValue = 0;
            timer.Stop();
            Close();
        }

        private void media_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            // Получаем сообщение об ошибке из исключения
            string errorMessage = e.ErrorException.Message;

            // Отображаем сообщение об ошибке в MessageBox
            MessageBox.Show(errorMessage, "Ошибка воспроизведения", MessageBoxButton.OK);
        }

    }
}
