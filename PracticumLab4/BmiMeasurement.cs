using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumLab4
{
    public class BmiMeasurement
    {
        public double Weight { get; private set; }
        public double Height { get; private set; }
        public string Gender { get; private set; }
        public int Age { get; private set; }
        public double BmiValue { get; private set; }
        public double BrocWeight { get; private set; }
        public string Category { get; private set; }
        public DateTime MeasurementDate { get; private set; }

        public BmiMeasurement(double weight, double height, string gender, int age, DateTime dateTime)
        {
            Weight = weight;
            Height = height;
            Gender = gender;
            Age = age;
            MeasurementDate = dateTime;
            BmiValue = BmiCalculator.CalculateBmi(this);
            BrocWeight = BmiCalculator.CalculateBroc(this);
            Category = DetermineCategory();
        }
        public string GetRecommendation()
        {

            double difference = Weight - BrocWeight;
            double differencePercent = (difference / BrocWeight) * 100;

            if (Math.Abs(differencePercent) < 5)
                return $"Ваш вес близок к идеальному \nОтклонение от идеального веса - {differencePercent:N1}%";
            else if (differencePercent >= 5 && differencePercent < 15)
                return $"Небольшое отклонение - рекомендуется корректировка питания \nОтклонение от идеального веса - {differencePercent:N1} %";
            else if (differencePercent >= 15 && differencePercent < 30)
                return $"Умеренное отклонение, рекомендуется снижение калорийности питания \nОтклонение от идеального веса - {differencePercent:N1} %";
            else if (differencePercent >= 30)
                return $"Значительное отклонение - рекомендуется обратиться к врачу! \nОтклонение от идеального веса - {differencePercent:N1} %";
            else if (differencePercent <= -5 && differencePercent > -15)
                return $"Небольшой дефицит, увеличьте калорийность питания \nОтклонение от идеального веса - {Math.Abs(differencePercent):N1} %";
            else if (differencePercent <= -15 && differencePercent > -25)
                return $"Умеренный дефицит, требуется коррекция рациона \nОтклонение от идеального веса - {Math.Abs(differencePercent):N1} %";
            else
                return $"Выраженный дефицит, рекомендуется срочно обратиться к специалисту \nОтклонение от идеального веса - {Math.Abs(differencePercent):N1} %";
        }


        public string DetermineCategory()
        {
            if (BmiValue < 16 && BmiValue > 0)
            {
                return "Выраженный дефицит";
            }
            else if (BmiValue > 16 && BmiValue < 18.5)
            {
                return "Недостаточный вес";
            }
            else if (BmiValue > 18.5 && BmiValue < 25)
            {
                return "Норма";
            }
            else if (BmiValue > 25 && BmiValue < 30)
            {
                return "Избыточный вес";
            }
            else if (BmiValue > 30 && BmiValue < 35)
            {
                return "Ожирение 1 степени";
            }
            else if (BmiValue > 35 && BmiValue < 40)
            {
                return "Ожирение 2 степени";
            }
            else if (BmiValue > 40)
            {
                return "Ожирение 3 степени";
            }
            else
            {
                return "Неверные данные";
            }

        }


    }
}
