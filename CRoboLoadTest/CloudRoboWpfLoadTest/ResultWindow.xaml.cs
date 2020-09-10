using System;
using System.Windows;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using OxyPlot;
using OxyPlot.Series;


namespace CloudRoboWpfLoadTest
{
    /// <summary>
    /// ResultWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class ResultWindow : Window
    {
        public DispatcherTimer dispatcherTimer;
        private DateTime startTime;
        private List<DataPoint> prevDataPoints = null;
        public string ChartTitle { get; private set; }


        public ResultWindow()
        {
            InitializeComponent();

            this.DataContext = this;
            this.ChartTitle = "Transition of Throughput (Transactions per minute)";

            dispatcherTimer = new DispatcherTimer(DispatcherPriority.Normal);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            startTime = DateTime.Now;
            dispatcherTimer.Start();
        }

        void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            TimeSpan ts = currentTime - startTime;
            textTime.Text = ts.Hours.ToString("00") + ":" + ts.Minutes.ToString("00") + ":" + ts.Seconds.ToString("00");

            int throughput = 0;
            int threadCount = 0;
            var results = MainWindow.dictionaryOfThreadResult;
            var stopFlag = MainWindow.stopFlag;
            if (stopFlag)
            {
                throughput = 0;
                threadCount = 0;
                this.dispatcherTimer.Stop();
            }
            else
            {
                foreach (var result in results)
                {
                    var threadResult = result.Value;
                    if (threadResult.IsEnabled)
                    {
                        ++threadCount;
                        throughput += threadResult.ThroughputPer60Sec;
                    }
                }
            }
            textThroughput.Text = throughput.ToString();
            textThreadCount.Text = $"Thread Count [{threadCount}]";

            // Current data point
            DataPoint dataPoint = new DataPoint(0, throughput);
            var dataPoints = new List<DataPoint>();
            dataPoints.Add(dataPoint);

            // Previous data point
            if (prevDataPoints != null)
            {
                int count = 0;
                foreach(var dp in prevDataPoints)
                {
                    ++count;
                    if (count > 60) break;
                    var newDp = new DataPoint(count, dp.Y);
                    dataPoints.Add(newDp);
                }
            }
            // Refresh data
            // = dataPoints;
            plotLine1.ItemsSource = dataPoints;
            prevDataPoints = dataPoints;
        }
    }
}
