using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumLab4
{
    public struct TrendResult
    {
        public double Change { get;}
        public BmiMeasurement First { get; }
        public BmiMeasurement Last { get; }
        public TrendResult(double change, BmiMeasurement first, BmiMeasurement last)
        {
            Change = change;
            First = first;
            Last = last;
        }
    }
    internal class BmiAnalyzer
    {

        public TrendResult AnalyzeTrends(StorageMeasurements measurements)
        {
            if (measurements.Length < 2)
            {
                throw new Exception("Недостаточно данных для анализа динамики (нужно минимум 2 замера).");
            }

            var validMeasurements = measurements.Measurements.OrderBy(i => i.MeasurementDate);

            var first = validMeasurements.First();
            var last = validMeasurements.Last();

            double change = last.BmiValue - first.BmiValue;

            return new TrendResult(change,first,last);

        }


    }
}
