using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumLab4
{
    internal class InputValidator
    {
        public static double FillDouble(string description)
        {
            Console.Write(description);
            while (true)
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
                catch (Exception e)
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
        public static DateTime FillDateTime(string description)
        {
            Console.Write(description);
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                        throw new ArgumentException("Ввод не может быть пустым");

                    if (!DateTime.TryParse(input, out DateTime datetime))
                        throw new FormatException("Неверный формат даты");

                    if (datetime.Day > DateTime.Now.Day && datetime.Month > DateTime.Now.Month)
                        throw new ArgumentOutOfRangeException("Дата не может быть больше текущей");

                    return datetime;
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
    }
}
