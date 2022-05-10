using MetricsDeskTopClient.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MetricsDeskTopClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private bool _getInfo;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void CpuControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void HddControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void RamControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            SetValue(sender, e);
        }

        private async Task SetValue(object sender, RoutedEventArgs e)
        {
            _getInfo = true;
            Start.IsEnabled = false;
            while (_getInfo)
            {
                cpu.UpdateOnСlick(sender, e);
                hdd.UpdateOnСlick(sender, e);
                dotnet.UpdateOnСlick(sender, e);
                ram.UpdateOnСlick(sender, e);
                network.UpdateOnСlick(sender, e);
                await Task.Delay(5 * 1000);
                //System.Threading.Thread.Sleep(1000);

            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _getInfo = false;
            Start.IsEnabled = true;
        }
    }
}
