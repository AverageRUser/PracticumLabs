using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumLab4
{
    internal class BmiAnalyzer
    {
        private BmiMeasurement[] _measurements;
        private int _currentIndex;
        private int _measurementCount;

        public BmiMeasurement[] Measurements { get {return _measurements.Take(_measurementCount).ToArray(); } }

        public BmiAnalyzer(int n)
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

        public void ShowHistory()
        {
            if (_measurementCount == 0)
            {
                Console.WriteLine("История измерений пуста.");
                return;
            }

            Console.WriteLine($"=== История измерений (последние {_measurementCount} записей) ===");

            for (int i = 0; i < Measurements.Length; i++)
            {
                if (Measurements[i] != null)
                {
                    Console.WriteLine($"{i + 1}. {Measurements[i].MeasurementDate:dd.MM.yyyy} - ИМТ: {Measurements[i].BmiValue:N2} ({Measurements[i].Category})");
                }
            }
        }

        public void AnalyzeTrends()
        {
            if (_measurementCount < 2)
            {
                Console.WriteLine("Недостаточно данных для анализа динамики (нужно минимум 2 замера).");
                return;
            }

            var validMeasurements = ValidMeasurements();

            var first = validMeasurements.First();
            var last = validMeasurements.Last();

            double change = last.BmiValue - first.BmiValue;
            char sign = change >= 0 ? '+' : '-';

            Console.WriteLine("=== Динамика показателей ===");
            Console.WriteLine($"Период: {first.MeasurementDate:dd.MM.yyyy} - {last.MeasurementDate:dd.MM.yyyy}");
            Console.WriteLine($"Изменение ИМТ: {sign}{Math.Abs(change):N1} ({first.BmiValue:N2} → {last.BmiValue:N2})");
        }
        private BmiMeasurement[] ValidMeasurements()
        {
            BmiMeasurement[] measurements = new BmiMeasurement[_measurementCount];
           for(int i = 0;i < measurements.Length;i++) 
            {
                if (_measurements[i] != null)
                {
                    measurements[i] = _measurements[i];
                }
            }
            return measurements;
        }

        public void CompareMeasurements(int index1, int index2)
        {
            var validMeasurements = ValidMeasurements();

            if (index1 < 0 || index1 >= validMeasurements.Length || index2 < 0 || index2 >= validMeasurements.Length)
            {
                Console.WriteLine("Некорректные индексы измерений.");
                return;
            }

            var m1 = validMeasurements[index1];
            var m2 = validMeasurements[index2];

            Console.WriteLine("=== Сравнение измерений ===");
            Console.WriteLine($"Измерение 1 ({m1.MeasurementDate:dd.MM.yyyy}): ИМТ = {m1.BmiValue:N2} ({m1.Category})");
            Console.WriteLine($"Измерение 2 ({m2.MeasurementDate:dd.MM.yyyy}): ИМТ = {m2.BmiValue:N2} ({m2.Category})");

            double difference = m2.BmiValue - m1.BmiValue;
            if (difference > 0)
                Console.WriteLine($"Изменение: +{difference:N2} (увеличение)");
            else if (difference < 0)
                Console.WriteLine($"Изменение: {difference:N2} (уменьшение)");
            else
                Console.WriteLine("Изменение: 0 (без изменений)");
        }

      
    }
}
