using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumLab4
{
    internal class BmiCalculator
    {
        public static double CalculateBroc(BmiMeasurement bmiMeasurement)
        {
            double ageCoefficient = GetAgeCoefficient(bmiMeasurement.Age);

            double baseWeight = (bmiMeasurement.Height * 100 - 100) * 0.95;

            if (bmiMeasurement.Gender == "m")
                return baseWeight * ageCoefficient;
            else
                return (baseWeight * 0.9) * ageCoefficient;
        }
      
        private static double GetAgeCoefficient(double age)
        {
            if (age < 25)
                return 0.95;
            else if (age >= 25 && age < 45)
                return 1;
            else if (age >= 45 && age < 55)
                return 1.05;
            else
                return 1.1;
        }
        public static double CalculateBmi(BmiMeasurement bmiMeasurement)
        {
            return bmiMeasurement.Weight / Math.Pow(bmiMeasurement.Height, 2);

        }
    }
}
