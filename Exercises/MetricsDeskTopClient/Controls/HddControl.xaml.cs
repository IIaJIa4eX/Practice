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
    /// Логика взаимодействия для HddControl.xaml
    /// </summary>
    public partial class HddControl : UserControl, INotifyPropertyChanged
    {
        private MetricsAgentClient _metricsAgentClient;
        public event PropertyChangedEventHandler PropertyChanged;
        private float maxPeriodValue = 0;
        private SeriesCollection _columnSeriesValues;
        private List<float> _metrics;
        private List<AllHddMetricsApiResponse> fullInfoMetric;
        public HddControl()
        {
            InitializeComponent();

            DataContext = this;
            _metricsAgentClient = new MetricsAgentClient(new HttpClient());
            _metrics = new List<float>();
            fullInfoMetric = new List<AllHddMetricsApiResponse>();

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

        private void CheckCount(AllHddMetricsApiResponse item)
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
            var hddMetric = _metricsAgentClient.GetLastHddMetrics(new GetAllHddMetricsApiRequest()
            {
                ClientBaseAddress = "http://localhost:8000"
            });


            if (hddMetric != null)
            {


                CheckCount(hddMetric);
                float value = hddMetric.Value;

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
