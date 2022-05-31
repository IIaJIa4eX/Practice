using LiveCharts;
using LiveCharts.Wpf;
using MetricsDeskTopClient.Client;
using MetricsDeskTopClient.Requests;
using MetricsDeskTopClient.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
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

namespace MetricsDeskTopClient.Controls
{
    //to review
    /// <summary>
    /// Логика взаимодействия для CpuControl.xaml
    /// </summary>
    public partial class CpuControl : UserControl, INotifyPropertyChanged
    {

        private MetricsAgentClient _metricsAgentClient;
        public event PropertyChangedEventHandler PropertyChanged;
        private float maxPeriodValue = 0;
        private SeriesCollection _columnSeriesValues;
        private List<float> _metrics;
        private List<AllCpuMetricsApiResponse> fullInfoMetric;
        public CpuControl()
        {
            InitializeComponent();

            DataContext = this;
            _metricsAgentClient = new MetricsAgentClient(new HttpClient());
            _metrics = new List<float>();
            fullInfoMetric = new List<AllCpuMetricsApiResponse>();
            
        }


        public SeriesCollection ColumnSeriesValues
        {
            get
            {
                return _columnSeriesValues;
            }
            set
            {

                _columnSeriesValues = value;
               
                OnPropertyChanged("ColumnSeriesValues");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CheckCount(AllCpuMetricsApiResponse item)
        {
            if(_metrics.Count < 5 && !fullInfoMetric.Any(x => x.Time == item.Time))
            {
                _metrics.Add(item.Value);
                fullInfoMetric.Add(item);
            }
            else if(_metrics.Count >= 5 && !fullInfoMetric.Any(x => x.Time == item.Time))
            {
                _metrics.RemoveAt(0);
                _metrics.Add(item.Value);
                fullInfoMetric.RemoveAt(0);
                fullInfoMetric.Add(item);
            }

        }

        private void SetValues()
        {
            
            if (fullInfoMetric.Count > 0)
            {
                MetricsTextBlock.Children.Clear();
                foreach (AllCpuMetricsApiResponse item in fullInfoMetric)
                {
                    MetricsTextBlock.Children.Add(new TextBlock() {Text = $"{item.Value:F2}%  {item.Time.DateTime}" });
                }
            }
        }

        public void UpdateOnСlick(object sender, RoutedEventArgs e)
        {
            var cpuMetric = _metricsAgentClient.GetLastCpuMetrics(new GetAllCpuMetricsApiRequest()
            {
                ClientBaseAddress = "http://localhost:8000"
            });


            if (cpuMetric != null)
            {


                CheckCount(cpuMetric);
                SetValues();
                float value = cpuMetric.Value;

                PercentTextBlock.Text = $"{value:F2}";
                

                ColumnSeriesValues = new SeriesCollection()
                {
                    new ColumnSeries()
                    {
                        Values = new ChartValues<float>(_metrics)
                    }
                };
            }
           
        }

        public void UpdateInfo()
        {
            var cpuMetric = _metricsAgentClient.GetLastCpuMetrics(new GetAllCpuMetricsApiRequest()
            {
                ClientBaseAddress = "http://localhost:8000"
            });


            if (cpuMetric != null)
            {


                CheckCount(cpuMetric);
                SetValues();
                float value = cpuMetric.Value;

                PercentTextBlock.Text = $"{value:F2}";


                ColumnSeriesValues = new SeriesCollection()
                {
                    new ColumnSeries()
                    {
                        Values = new ChartValues<float>(_metrics)
                    }
                };
            }
        }
    }
}
