using System.Reflection;

namespace PracticumLab1
{
    internal class Program
    {
       
        public static double FillDouble(string description)
        {
            Console.Write(description);
            while(true) 
            {
                try
                {
                    string input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                        throw new ArgumentException("Ввод не может быть пустым");

                    if (!double.TryParse(input, out double num))
                        throw new FormatException("Неверный формат числа");

                    if (num <= 0)
                        throw new ArgumentOutOfRangeException("Значение должно быть положительным");

                    return num;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}. Введите данные ещё раз:");
                }
            }
        }
        public static int FillInt(string description)
        {
            Console.Write(description);
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                        throw new ArgumentException("Ввод не может быть пустым");

                    if (!int.TryParse(input, out int num))
                        throw new FormatException("Неверный формат числа");

                    if (num <= 0)
                        throw new ArgumentOutOfRangeException("Значение должно быть положительным");

                    return num;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}. Введите данные ещё раз:");
                }
            }
        }
        public static bool isWeightCorrect(double weight)
        {
            try
            {
                if (weight <= 0)
                    throw new ArgumentException("Вес не может быть отрицательным или нулевым");

                if (weight < 30)
                    throw new ArgumentOutOfRangeException("Вес слишком мал (минимум 30 кг)");

                if (weight > 300)
                    throw new ArgumentOutOfRangeException("Вес слишком велик (максимум 300 кг)");

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка веса: {ex.Message}");
                return false;
            }
        }
        public static bool isHeightCorrect(double height)
        {
            try
            {
                if (height <= 0)
                    throw new ArgumentException("Рост не может быть отрицательным или нулевым");

                if (height < 1.0)
                    throw new ArgumentOutOfRangeException("Рост слишком мал (минимум 1.0 м)");

                if (height >= 1.0 && height <= 2.5)
                    return true;
                else
                    throw new ArgumentOutOfRangeException("Нереалистичное значение роста (должно быть 1.0-2.5 м)");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка роста: {ex.Message}");
                return false;
            }
        }
        public static double GetAgeCoefficient(double age)
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
        public static double CalculateBroc(double height, string gender, int age)
        {
            double ageCoefficient = GetAgeCoefficient(age);
           
            double baseWeight = (height * 100 - 100) * 0.95;

            if (gender == "м")
                return baseWeight * ageCoefficient;
            else
                return (baseWeight * 0.9) * ageCoefficient; 
        }
        public static string BMIinfo(double BMI)
       {
            
            if (BMI < 16 && BMI > 0)
            {
                return "Выраженный дефицит";
            }
            else if (BMI > 16 && BMI < 18.5)
            {
                return "Недостаточный вес";
            }
            else if (BMI > 18.5 && BMI < 25)
            {
                return "Норма";
            }
            else if (BMI > 25 && BMI < 30)
            {
                return "Избыточный вес";
            }
            else if (BMI > 30 && BMI < 35)
            {
                return "Ожирение 1 степени";
            }
            else if (BMI > 35 && BMI < 40)
            {
                return "Ожирение 2 степени";
            }
            else if (BMI > 40)
            {
                return "Ожирение 3 степени";
            }
            else
            {
                return "Неверные данные";
            }
        }
        public static string FillGender()
        {
            
            while (true)
            {
                try
                {
                    string gender = Console.ReadLine();
                    if (gender == "м" || gender == "ж")
                        return gender;
                    else
                        Console.WriteLine("Неверно указан пол! Укажите либо м либо ж:");
                }
                catch(Exception e) 
                {
                }
            }
        }
        public static int FillAge()
        {
            while (true)
            {
                int age = FillInt("Укажите возраст: ");
                
                if (age < 120 && age > 0)
                    return age;
                else
                    Console.WriteLine("Неверно указан возраст!");
            }
            
        }
        public static string GetRecommendation(double weight,double BrocWeight)
        {
           
            double difference = weight - BrocWeight;
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
        public static double CalculateBMI(double weight,double height)
        {
            double BMI = weight / Math.Pow(height, 2);
           return BMI;
           
        }
        public static void AnalyzeDynamicBMI(double[] bmiResults, DateTime[] dates)
        {
           
                double average = 0,maxElement = int.MinValue, minElement = int.MaxValue;
                int count = 0, indexMax = 0,indexMin = 0;

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
            char sign = bmiResults[count-1] > bmiResults[count - 2] ? '+' : '-';
            double lastmount = Math.Abs(bmiResults[count - 1] - bmiResults[count-2]);
            Console.WriteLine($"Изменение за последний месяц: {sign} {lastmount:N2}");
        }
        public static void SaveMeasurementToHistory(int measurementIndex,double[] bmiResults, DateTime[] dates, double[] weights, double[] heights, int[] ages, string[] genders, double weight,double height, int age, string gender,double BMI)
        {
            bmiResults[measurementIndex] = Math.Round(BMI, 2);
            dates[measurementIndex] = DateTime.Now;
            weights[measurementIndex] = weight;
            heights[measurementIndex] = height;
            ages[measurementIndex] = age;
            genders[measurementIndex] = gender;

        }
        public static void ShowMeasurementHistory(int measurementIndex, double[] bmiResults, DateTime[] dates, double[] weights, double[] heights, int[] ages, string[] genders)
        {
            Console.WriteLine($"=== История замера №{measurementIndex} ===");
            Console.WriteLine($"Возраст - {ages[measurementIndex]}");
            Console.WriteLine($"Пол - {genders[measurementIndex]}");
            Console.WriteLine($"Вес - {weights[measurementIndex]}");
            Console.WriteLine($"Рост - {heights[measurementIndex]}");
            Console.WriteLine($"ИМТ -  {bmiResults[measurementIndex]}, {BMIinfo(bmiResults[measurementIndex])}");
            Console.WriteLine($"Дата замера - {dates[measurementIndex]}");
        }
       
        public static void Main(string[] args)
        {
            double weight = 0,height =0, BrocWeight = 0,BMI = 0;
            const int n = 10;
            int count = 0;
            double[] weights = new double[n];
            double[] heights = new double[n];
            string[] genders = new string[n];
            int[] ages = new int[n];
            double[] bmiResults = new double[n];
            DateTime[] dates = new DateTime[n];
            int age = 0;
            string gender ="";
            int enter;
            bool exit = false;
            bool calculation = false;
            while (!exit)
            {
                Console.WriteLine("=== Анализатор ИМТ ===");
                Console.WriteLine("1. Расчёт ИМТ");
                Console.WriteLine("2. История замеров");
                Console.WriteLine("3. Анализ динамики");
                Console.WriteLine("4. Рекомендации");
                Console.WriteLine("5. Выход");
                Console.WriteLine("======================");
                Console.Write("Выберите действие: ");
                if (int.TryParse(Console.ReadLine(), out enter))
                {
                    switch (enter)
                    {
                        case 1:
                            calculation = true;
                            while (calculation)
                            {
                                try
                                {


                                    do
                                    {
                                        weight = FillDouble("\nВведите вес(в кг): ");
                                    }
                                    while (!isWeightCorrect(weight));

                                    do
                                    {
                                        height = FillDouble("Введите рост(в сантиметрах или в метрах): ");
                                        //Автоматическое преобразование сантиметров в метры
                                        if (height > 100)
                                        {
                                            height = height / 100;

                                        }
                                    }
                                    while (!isHeightCorrect(height));

                                    Console.Write("Укажите пол (м/ж): ");
                                    gender = FillGender();
                               

                                    age = FillAge();
                                    BMI = CalculateBMI(weight,height);
                                    BrocWeight = CalculateBroc(height, gender, age);
                                    Console.WriteLine("\n=== Результаты ===");
                                    Console.WriteLine($"Ваш ИМТ = {BMI:N2} - " + BMIinfo(BMI));
                                    Console.WriteLine($"Идеальный вес (по Броку) - {BrocWeight:N2} кг");
                                  
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Ошибка! - " + ex.Message);
                                }
                               
                                Console.WriteLine("\n1. Новый расчёт");
                                Console.WriteLine("2. Сохранить замер");
                                Console.WriteLine("3. Вернуться в меню");
                                int input;
                                bool isInputCorrect = false;
                                while(!isInputCorrect)
                                {
                                    int.TryParse(Console.ReadLine(), out input);
                                    switch (input)
                                    {
                                        case 1:
                                            Console.WriteLine("=== Новый расчёт ===");
                                            
                                            isInputCorrect = true;
                                            break;
                                        case 2:
                                            Console.WriteLine("Результат сохранён!");
                                           
                                            SaveMeasurementToHistory(count,bmiResults,dates,weights,heights,ages,genders,weight,height,age,gender,BMI);
                                            count++;
                                            if (count == bmiResults.Length)
                                            {
                                                count = 0;
                                            }
                                            isInputCorrect = true;
                                            calculation = false;
                                            break;
                                        case 3:
                                            calculation = false;
                                            isInputCorrect = true;
                                            break;
                                        default:
                                            Console.WriteLine("Некорректно введённое значение!");
                                            break;
                                    }
                                }
                               
                            }
                            break;
                        case 2:
                            if (bmiResults[0] == 0)
                                Console.WriteLine("Замеров нет");
                            else
                            {
                                while (true)
                                {
                                    int mIndex = FillInt("Укажите номер замера(от 1 до 10): ") - 1;
                                    if (bmiResults[mIndex] == 0)
                                    {
                                        Console.WriteLine("Нет данных по этому замеру, введите другой ");
                                    }
                                    else
                                    {
                                        ShowMeasurementHistory(mIndex, bmiResults, dates, weights, heights, ages, genders);
                                        break;
                                    }
                                }
                            }
                            break;
                        case 3:
                            if (bmiResults[0] == 0)
                                Console.WriteLine("Замеров нет");
                            else
                            AnalyzeDynamicBMI(bmiResults,dates);
                            break;
                        case 4:
                            if (bmiResults[0] == 0)
                                Console.WriteLine("Замеров нет");
                            else
                            {
                                Console.WriteLine($"Замер № {count-1}");
                                Console.WriteLine("Рекомендации - " + GetRecommendation(weights[count-1], CalculateBroc(heights[count-1], genders[count-1], ages[count-1])));
                            }
                            break;
                        case 5:
                           
                                Console.WriteLine("Вы уверены? д/н");
 
                                string confirm = Console.ReadLine();
                                if(confirm == "д")
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
