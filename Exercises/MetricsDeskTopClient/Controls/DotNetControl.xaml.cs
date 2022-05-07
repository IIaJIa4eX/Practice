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
    /// <summary>
    /// Логика взаимодействия для DotNetControl.xaml
    /// </summary>
    public partial class DotNetControl : UserControl, INotifyPropertyChanged
    {
        private MetricsAgentClient _metricsAgentClient;
        public event PropertyChangedEventHandler PropertyChanged;
        private double maxPeriodValue = 0;
        private SeriesCollection _columnSeriesValues;
        private List<double> _metrics;
        private List<DonNetMetricsApiResponse> fullInfoMetric;
        public DotNetControl()
        {
            InitializeComponent();

            DataContext = this;
            _metricsAgentClient = new MetricsAgentClient(new HttpClient());
            _metrics = new List<double>();
            fullInfoMetric = new List<DonNetMetricsApiResponse>();

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

        private void CheckCount(DonNetMetricsApiResponse item)
        {
            if (_metrics.Count < 5 && !fullInfoMetric.Any(x => x.Time == item.Time))
            {
                _metrics.Add(item.Value);
                fullInfoMetric.Add(item);
            }
            else if (_metrics.Count >= 5 && !fullInfoMetric.Any(x => x.Time == item.Time))
            {
                _metrics.RemoveAt(0);
                _metrics.Add(item.Value);
                fullInfoMetric.RemoveAt(0);
                fullInfoMetric.Add(item);
            }

        }

        private void UpdateOnСlick(object sender, RoutedEventArgs e)
        {
            var dotNetMetric = _metricsAgentClient.GetLastDonNetMetrics(new DonNetHeapMetrisApiRequest()
            {
                ClientBaseAddress = "http://localhost:8000"
            });


            if (dotNetMetric != null)
            {


                CheckCount(dotNetMetric);
                double value = dotNetMetric.Value * 0.001;


                PercentTextBlock.Text = $"{value:F2}";


                ColumnSeriesValues = new SeriesCollection()
                {
                    new ColumnSeries()
                    {
                        Values = new ChartValues<double>(_metrics)
                    }
                };
            }
        }

        private void TimePowerChart_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
