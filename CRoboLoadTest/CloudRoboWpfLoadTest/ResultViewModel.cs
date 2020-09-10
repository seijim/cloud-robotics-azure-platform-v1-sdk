using System;
using System.Collections.Generic;
using OxyPlot;
using OxyPlot.Series;


namespace CloudRoboWpfLoadTest
{
    public class ResultViewModel
    {
        public string Title { get; private set; }
        public IList<DataPoint> Points { get; set; }

        public ResultViewModel()
        {
            this.Title = "Transition of Throughput (Transactions per minute)";
            this.Points = new List<DataPoint>
                              {
                                  new DataPoint(0, 4),
                                  new DataPoint(10, 13),
                                  new DataPoint(20, 15),
                                  new DataPoint(30, 16),
                                  new DataPoint(40, 12),
                                  new DataPoint(50, 12)
                              };
        }
    }
}
