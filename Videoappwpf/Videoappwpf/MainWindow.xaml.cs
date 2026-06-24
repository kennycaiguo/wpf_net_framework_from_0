using Microsoft.Win32;
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

namespace Videoappwpf
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            player.Play();
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            player?.Pause();
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            player?.Stop();
        }

        private void player_MediaOpened(object sender, RoutedEventArgs e)
        {
            player?.Play();
        }

        private void player_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            MessageBox.Show("Error Loading Media...");
        }
    }
}
