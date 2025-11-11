using System;

namespace PracticumLab4
{
    internal class StorageMeasurements
    {
        private int _measurementCount; //Количество заполненных замеров
            private int _currentIndex;
        private BmiMeasurement[] _measurements;
        public BmiMeasurement[] Measurements { get { return _measurements.Take(_measurementCount).ToArray(); } }
        public int Length {  get { return _measurements.Length; } }


        public StorageMeasurements(int n)
        {
            _measurements = new BmiMeasurement[n];
            _currentIndex = 0;
            _measurementCount = 0;
        }

        public void AddMeasurement(BmiMeasurement measurement)
        {
            _measurements[_currentIndex] = measurement;
            _currentIndex = (_currentIndex + 1) % _measurements.Length;
            _measurementCount = Math.Min(_measurementCount + 1, _measurements.Length);
        }


    }
}