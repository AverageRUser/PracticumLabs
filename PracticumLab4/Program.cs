namespace PracticumLab4
{
    internal class Program
    {
       

        /*
        public static void AnalyzeDynamicBMI(double[] bmiResults, DateTime[] dates)
        {

            double average = 0, maxElement = int.MinValue, minElement = int.MaxValue;
            int count = 0, indexMax = 0, indexMin = 0;

            for (int i = 0; i < bmiResults.Length; i++)
            {
                if (bmiResults[i] != 0)
                    count++;

            }
            for (int i = 0; i < bmiResults.Length; i++)
            {
                average += bmiResults[i];
            }

            for (int j = 0; j < count; j++)
            {
                if (maxElement < bmiResults[j])
                {
                    maxElement = bmiResults[j];
                    indexMax = j;
                }
            }
            for (int k = 0; k < count; k++)
            {
                if (minElement > bmiResults[k])
                {
                    minElement = bmiResults[k];
                    indexMin = k;
                }
            }
            Console.WriteLine("Всего замеров: " + count);
            Console.WriteLine($"Средний ИМТ: {average / count:N2}");
            Console.WriteLine($"Максимальный ИМТ: {maxElement} ({dates[indexMin]})");
            Console.WriteLine($"Минимальный ИМТ:  {minElement} ({dates[indexMax]})");
            char sign = bmiResults[count - 1] > bmiResults[count - 2] ? '+' : '-';
            double lastmount = Math.Abs(bmiResults[count - 1] - bmiResults[count - 2]);
            Console.WriteLine($"Изменение за последний месяц: {sign} {lastmount:N2}");
        }

       */
        public static void Main(string[] args)
        {
            double BrocWeight = 0, BMI = 0,weight,height;
            BmiAnalyzer analyzer = new BmiAnalyzer(10);
            int count = 0;
            int age = 0;
            string gender = "";
            int enter;
            bool exit = false;
            bool calculation = false;
            while (!exit)
            {
                Console.WriteLine("=== Анализатор ИМТ ===");
                Console.WriteLine("1. Расчёт ИМТ");
                Console.WriteLine("2. История замеров");
                Console.WriteLine("3. Анализ динамики");
                Console.WriteLine("4. Сравнить замеры");
                Console.WriteLine("5. Выход");
                Console.WriteLine("======================");
                Console.Write("Выберите действие: ");
                if (int.TryParse(Console.ReadLine(), out enter))
                {
                    switch (enter)
                    {
                        case 1:

                            try
                            {


                                do
                                {
                                    weight = InputValidator.FillDouble("\nВведите вес(в кг): ");
                                }
                                while (!InputValidator.isWeightCorrect(weight));

                                do
                                {
                                    height = InputValidator.FillDouble("Введите рост(в сантиметрах или в метрах): ");
                                    //Автоматическое преобразование сантиметров в метры
                                    if (height > 100)
                                    {
                                        height = height / 100;

                                    }
                                }
                                while (!InputValidator.isHeightCorrect(height));

                                Console.Write("Укажите пол (м/ж): ");
                                gender = InputValidator.FillGender();


                                age = InputValidator.FillAge();
                                analyzer.AddMeasurement(new BmiMeasurement(weight, height, gender, age));
                                Console.WriteLine("Замер сохранен!");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Ошибка! - " + ex.Message);
                            }

                                

                            
                            break;
                        case 2:
                            analyzer.ShowHistory();
                            var measurements = analyzer.Measurements;

                            if (measurements.Length > 0)
                            {
                                while (true)
                                {
                                    int mIndex = InputValidator.FillInt($"Укажите номер замера чтобы получить больше информации(от 1 до {measurements.Length}): ") - 1;
                                    if (mIndex > measurements.Length )
                                    {
                                        Console.WriteLine("Индекс вне диапазона массива. Введите другой индекс!");
                                    }
                                    else
                                    {
                                        measurements[mIndex].PrintReport();
                                        break;
                                    }
                                }
                               
                               
                            }
                            break;
                        case 3:
                            analyzer.AnalyzeTrends();
                            break;
                        case 4:
                            var measurementCompare = analyzer.Measurements;
                            if (measurementCompare.Length < 2)
                            {
                                Console.WriteLine("Недостаточно замеров для сравнения (нужно минимум 2).");
                                return;
                            }

                            analyzer.ShowHistory();
                            Console.WriteLine();

                            while (true)
                            {
                                int index1 = InputValidator.FillInt("Введите номер первого замера: ") - 1;
                                int index2 = InputValidator.FillInt("Введите номер второго замера: ") - 1;
                                if (index1 > measurementCompare.Length || index2 > measurementCompare.Length)
                                {
                                    Console.WriteLine("Индекс вне диапазона массива. Введите другой индекс!");
                                }
                                else
                                {
                                    analyzer.CompareMeasurements(index1, index2);
                                    break;
                                }
                            }
                        
                            break;

                        case 5:

                            Console.WriteLine("Вы уверены? д/н");

                            string confirm = Console.ReadLine();
                            if (confirm == "д")
                            {
                                exit = true;
                            }


                            break;
                        default:
                            Console.WriteLine("Неверная операция! ");
                            break;
                    }
                }
            }
        }
    }
}
