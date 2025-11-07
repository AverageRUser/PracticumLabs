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
        private double _bmiValue;
        private string? _category;
        private DateTime _measurementDate;

        public double Weight { get { return _weight; } set { _weight = value; } }
        public double Height { get { return _height; } set { _height = value; } }
        public string Gender { get { return _gender; } set { _gender = value; } }
        public int Age { get { return _age; } set { _age = value; } }
        public double BmiValue { get { return _bmiValue; } set { _bmiValue = value; } }
        public string Category { get { return _category; } set { _category = value; } }
        public DateTime MeasurementDate { get { return _measurementDate; } set { _measurementDate = value; } }

        public void CalculateBmi()
        {
            _bmiValue = _weight / Math.Pow(_height, 2);

        }
        public void DetermineCategory()
        {
            if (_bmiValue < 16 && _bmiValue > 0)
            {
                _category = "Выраженный дефицит";
            }
            else if (_bmiValue > 16 && _bmiValue < 18.5)
            {
                return "Недостаточный вес";
            }
            else if (_bmiValue > 18.5 && _bmiValue < 25)
            {
                return "Норма";
            }
            else if (_bmiValue > 25 && _bmiValue < 30)
            {
                return "Избыточный вес";
            }
            else if (_bmiValue > 30 && _bmiValue < 35)
            {
                return "Ожирение 1 степени";
            }
            else if (_bmiValue > 35 && _bmiValue < 40)
            {
                return "Ожирение 2 степени";
            }
            else if (_bmiValue > 40)
            {
                return "Ожирение 3 степени";
            }
            else
            {
                return "Неверные данные";
            }

        }
        public void PrintReport()
        {

        }

    }
}
