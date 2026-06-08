using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Dzshka
{
    using System;
    using System.Collections.Generic;

    namespace FinancialUtilities
    {
        public class NegativeValueException : Exception
        {
            public NegativeValueException(string message) : base(message) { }
            public NegativeValueException(string message, Exception inner) : base(message, inner) { }
        }

        public class OverdraftException : Exception
        {
            public OverdraftException(string message) : base(message) { }
            public OverdraftException(string message, Exception inner) : base(message, inner) { }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Калькулятор деления \n");
                ExecuteSafeCalculator();


                Console.WriteLine("Нажмите любую клавишу для продолжения");
                Console.ReadKey();
                Console.Clear();

                Console.WriteLine("\n Работа приложения завершена ");
                Console.ReadKey();
            }

            static void ExecuteSafeCalculator()
            {
                List<int> history = new List<int>();
                bool keepRunning = true;

                while (keepRunning)
                {
                    try
                    {
                        Console.Write("Введите первое число: ");
                        int dividend = int.Parse(Console.ReadLine());

                        Console.Write("Введите второе число: ");
                        int divisor = int.Parse(Console.ReadLine());

                        int quotient = dividend / divisor;

                        history.Add(quotient);

                        Console.WriteLine($"Результат: {quotient}");

                        Console.Write("Хотмте продолжить? (да/нет): ");
                        string response = Console.ReadLine().Trim().ToLower();
                        if (response != "да")
                            keepRunning = false;
                    }
                    catch (DivideByZeroException)
                    {
                        Console.WriteLine("Ошибка: попытка деления на ноль");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Ошибка: требуется числовое значение");
                    }
                    finally
                    {
                        Console.WriteLine("Попытка выполнения операции завершена");
                    }
                }

                Console.WriteLine("\nЖурнал успешных операций:");
                for (int i = 0; i < history.Count; i++)
                {
                    Console.WriteLine($"Операция {i + 1}: {history[i]}");
                }
            }
        }
    }
}