namespace PracticumLab4
{
    internal class Program
    {



        public static void Main(string[] args)
        {
            double weight, height;

            StorageMeasurements storageMeasurements = new StorageMeasurements(10);
            BmiAnalyzer analyzer = new BmiAnalyzer();
            int age = 0;
            string gender = "";
            int enter;
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("=== Анализатор ИМТ ===");
                Console.WriteLine("1. Расчёт ИМТ");
                Console.WriteLine("2. История замеров");
                Console.WriteLine("3. Анализ динамики");
                Console.WriteLine("4. Сравнить замеры");
                Console.WriteLine("5. Поиск замера по критерию");
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
                                        height /= 100;

                                    }
                                }
                                while (!InputValidator.isHeightCorrect(height));

                                Console.Write("Укажите пол (m/f): ");
                                gender = InputValidator.FillGender();


                                age = InputValidator.FillAge();
                                DateTime dateTime = InputValidator.FillDateTime("Введите дату:");
                                storageMeasurements.AddMeasurement(new BmiMeasurement(weight, height, gender, age, dateTime));

                                Console.WriteLine("Замер сохранен!");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Ошибка! - " + ex.Message);
                            }

                            break;
                        case 2:
                            ShowBmiData.ShowHistoryBmi(storageMeasurements);
                            var measurements = storageMeasurements.Measurements;

                            if (measurements.Length > 0)
                            {
                                while (true)
                                {
                                    int mIndex = InputValidator.FillInt($"Укажите номер замера чтобы получить больше информации(от 1 до {measurements.Length}): ") - 1;
                                    if (mIndex > measurements.Length)
                                    {
                                        Console.WriteLine("Индекс вне диапазона массива. Введите другой индекс!");
                                    }
                                    else
                                    {
                                        ShowBmiData.ShowMeasurement(measurements[mIndex]);
                                        break;
                                    }
                                }


                            }
                            break;
                        case 3:
                            var trend = analyzer.AnalyzeTrends(storageMeasurements);
                            ShowBmiData.ShowAnalyzeTrend(trend);
                            break;
                        case 4:
                            var measurementCompare = storageMeasurements.Measurements;
                            if (measurementCompare.Length < 2)
                            {
                                Console.WriteLine("Недостаточно замеров для сравнения (нужно минимум 2).");
                                return;
                            }

                            ShowBmiData.ShowHistoryBmi(storageMeasurements);
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
                                    var compare = MeasurementComparator.Compare(storageMeasurements.Measurements[index1], storageMeasurements.Measurements[index2]);
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
