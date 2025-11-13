using PracticumLab4;
using System.Collections.Generic;

internal class ShowBmiData
{
    public static void ShowHistoryBmi(StorageMeasurements bmi)
    {
        Console.Clear();
        int count = bmi.Measurements.Length;
        if (count == 0)
        {
            Console.WriteLine("История измерений пуста.");
            return;
        }

        Console.WriteLine($"=== История измерений (последние {count} записей) ===");

        for (int i = 0; i < count; i++)
        {
            if (bmi.Measurements[i] != null)
            {
                Console.WriteLine($"{i + 1}. {bmi.Measurements[i].MeasurementDate.Date} - ИМТ: {bmi.Measurements[i].BmiValue:N2} ({bmi.Measurements[i].Category})");
            }
        }
        Console.ReadLine();
    }
    public static void ShowComparison(ComparisonResult result)
    {
        Console.Clear();
        Console.WriteLine("=== Сравнение измерений ===");
        Console.WriteLine("=== Сравнение измерений ===");
        Console.WriteLine($"Измерение 1 ({result.First.MeasurementDate:dd.MM.yyyy}): ИМТ = {result.First.BmiValue:N2} ({result.First.Category})");
        Console.WriteLine($"Измерение 2 ({result.Second.MeasurementDate:dd.MM.yyyy}): ИМТ = {result.Second.BmiValue:N2} ({result.Second.Category})");

        string changeSign = result.Difference > 0 ? "+" : "";
        string trend = result.Difference > 0 ? "увеличение" : result.Difference < 0 ? "уменьшение" : "без изменений";
        Console.WriteLine($"Изменение: {changeSign}{result.Difference:N2} ({trend})");
        Console.ReadLine();
    }
    public static void ShowAnalyzeTrend(TrendResult trend)
    {
        char sign = trend.Change >= 0 ? '+' : '-';
        Console.WriteLine("=== Динамика показателей ===");
        Console.WriteLine($"Период: {trend.First.MeasurementDate:dd.MM.yyyy} - {trend.Last.MeasurementDate:dd.MM.yyyy}");
        Console.WriteLine($"Изменение ИМТ: {sign}{Math.Abs(trend.Change):N2} ({trend.First.BmiValue:N2} -> {trend.Last.BmiValue:N2})");
    }
    
        public static void ShowMeasurement(BmiMeasurement bmiMeasurement)
    {
        Console.Clear();
         Console.WriteLine($"=== Отчёт о замере от {bmiMeasurement.MeasurementDate:dd.MM.yyyy} ===");
            Console.WriteLine($"Возраст: {bmiMeasurement.Age} лет");
            Console.WriteLine($"Пол: {bmiMeasurement.Gender}");
            Console.WriteLine($"Вес: {bmiMeasurement.Weight} кг");
            Console.WriteLine($"Рост: {bmiMeasurement.Height} м");
            Console.WriteLine($"ИМТ: {bmiMeasurement.BmiValue:N2} - {bmiMeasurement.Category}");
            Console.WriteLine($"Идеальный вес (по Броку): {BmiCalculator.CalculateBroc(bmiMeasurement):N2} кг");
            Console.WriteLine($"Рекомендации: {bmiMeasurement.GetRecommendation()}");
            Console.WriteLine("=================================");
        Console.ReadLine();
    }
    public static void ShowFindMeasurements(BmiMeasurement[] measurements)
    {
        Console.Clear();
        if (measurements.Length > 0)
        {
            Console.WriteLine($"=== Найдено замеров: {measurements.Length} ===");
            for (int i = 0; i < measurements.Length; i++)
            {
                if (measurements[i] != null)
                {
                    Console.WriteLine($"{i + 1}. {measurements[i].MeasurementDate.Date} - ИМТ: {measurements[i].BmiValue:N2} ({measurements[i].Category})");
                }
            }
            Console.WriteLine("=================================");

            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Замер не найден");
        }
    }

}