using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace SoftUniTimer.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// //https://dzone.com/articles/create-a-wpf-msi-installer
    /// System.Speech -> voice recognition app
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Shutdown(object sender, RoutedEventArgs e)
        {
            int seconds = GetSeconds();
            ProcessStartInfo processStartInfo = GetProcess($"/s /t {seconds}");
            Process.Start(processStartInfo);
        }

        private void Abort(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo processStartInfo = GetProcess("/a");
            Process.Start(processStartInfo);
        }

        private void Restart(object sender, RoutedEventArgs e)
        {
            int seconds = GetSeconds();
            ProcessStartInfo processStartInfo = GetProcess($"/r /t {seconds}");
            Process.Start(processStartInfo);
        }
        
        private void Hibernate(object sender, RoutedEventArgs e)
        {
            int seconds = GetSeconds();
            ProcessStartInfo processStartInfo = GetProcess($"/h /t {seconds}");
            Process.Start(processStartInfo);
        }

        private static ProcessStartInfo GetProcess(string command)
        {
            return new ProcessStartInfo("shutdown", command)
            {
                CreateNoWindow = true,
                UseShellExecute = false
            };
        }

        private int GetSeconds()
        {
            var currentTime = timeList.SelectionBoxItem.ToString();

            int time = int.Parse(currentTime.TrimEnd('h', 'm'));

            if (currentTime.EndsWith("h"))
            {
                time *= 60 * 60;
            }
            else if (currentTime.EndsWith("m"))
            {
                time *= 60;
            }

            return time;
        }
    }
}
