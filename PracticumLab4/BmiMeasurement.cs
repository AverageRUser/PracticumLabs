using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumLab4
{
    internal class BmiMeasurement
    {
        private double _weight;
        private double _height;
        private string? _gender;
        private int _age;

        public double Weight { get { return _weight; } set {_weight = value; } }
        public double Height { get { return _height; } set { _height = value; } }
        public string Gender { get { return _gender; } set { _gender = value; } }
        public int Age { get { return _age; } set { _age = value; } }
        public double BmiValue { get; private set; }
        public string Category { get; private set; }
        public DateTime MeasurementDate { get; private set; }
        public BmiMeasurement(double weight, double height, string gender, int age)
        {
            Weight = weight;
            Height = height;
            Gender = gender;
            Age = age;
            MeasurementDate = DateTime.Now;
            CalculateBmi();
            DetermineCategory();
        }

        public void CalculateBmi()
        {
            BmiValue = _weight / Math.Pow(_height, 2);

        }
        public void DetermineCategory()
        {
            if (BmiValue < 16 && BmiValue > 0)
            {
                Category = "Выраженный дефицит";
            }
            else if (BmiValue > 16 && BmiValue < 18.5)
            {
                Category = "Недостаточный вес";
            }
            else if (BmiValue > 18.5 && BmiValue < 25)
            {
                Category = "Норма";
            }
            else if (BmiValue > 25 && BmiValue < 30)
            {
                Category = "Избыточный вес";
            }
            else if (BmiValue > 30 && BmiValue < 35)
            {
                Category = "Ожирение 1 степени";
            }
            else if (BmiValue > 35 && BmiValue < 40)
            {
                Category = "Ожирение 2 степени";
            }
            else if (BmiValue > 40)
            {
                Category = "Ожирение 3 степени";
            }
            else
            {
                Category = "Неверные данные";
            }

        }
        public void PrintReport()
        {
            Console.WriteLine($"=== Отчёт о замере от {MeasurementDate:dd.MM.yyyy} ===");
            Console.WriteLine($"Возраст: {Age} лет");
            Console.WriteLine($"Пол: {Gender}");
            Console.WriteLine($"Вес: {Weight} кг");
            Console.WriteLine($"Рост: {Height} м");
            Console.WriteLine($"ИМТ: {BmiValue:N2} - {Category}");
            Console.WriteLine($"Идеальный вес (по Броку): {CalculateBroc():N2} кг");
            Console.WriteLine($"Рекомендации: {GetRecommendation()}");
            Console.WriteLine("=================================");
        }
        public double GetAgeCoefficient(double age)
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
        public double CalculateBroc()
        {
            double ageCoefficient = GetAgeCoefficient(_age);

            double baseWeight = (_height * 100 - 100) * 0.95;

            if (_gender == "м")
                return baseWeight * ageCoefficient;
            else
                return (baseWeight * 0.9) * ageCoefficient;
        }

        public string GetRecommendation()
        {
            double brocWeight = CalculateBroc();
            double difference = _weight - brocWeight;
            double differencePercent = (difference / brocWeight) * 100;

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
    }
}
