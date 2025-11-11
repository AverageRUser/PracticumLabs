using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumLab4
{
    public struct ComparisonResult
    {
        public double Difference { get; }
      
        public BmiMeasurement First { get; }
        public BmiMeasurement Second { get; }
        public ComparisonResult(BmiMeasurement first, BmiMeasurement second,double difference)
        {
            
            First = first;
            Second = second;
            Difference = difference;
        }
    }
    internal static class MeasurementComparator
    {
        public static ComparisonResult Compare(BmiMeasurement m1, BmiMeasurement m2)
        {
            double difference = m2.BmiValue - m1.BmiValue;

            return new ComparisonResult(m1, m2, difference);
        }
       
    }
}
