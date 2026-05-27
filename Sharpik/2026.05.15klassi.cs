using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dzshka
{
    class Program
    {
        static void Main()
        {
            DrawSquare(7, '*');

            Console.WriteLine(IsPalindrome(1221));
            Console.WriteLine(IsPalindrome(7854));

            int[] original = { 1, 2, 6, -1, 88, 7, 6 };
            int[] filter = { 6, 88, 7 };
            int[] filtered = FilterArray(original, filter);
            Console.WriteLine(string.Join(" ", filtered));

            Website site = new Website("Sitek", "https://sitek.com", "Сайтек", "192.168.1.1");
            site.PrintInfo();

            Journal journal = new Journal("Биология", 1000, "Учебник по биологии", "+79142134567", "nau@mail.ru");
            journal.PrintInfo();

            Shop shop = new Shop("Магазин", "ул. Чкалова д. 14", "Продуктовый", "+79147654321", "shop@mail.ru");
            shop.PrintInfo();
        }

        static void DrawSquare(int side, char symbol)
        {
            for (int i = 0; i < side; i++)
            {
                Console.WriteLine(new string(symbol, side));
            }
        }

        static bool IsPalindrome(int num)
        {
            string s = num.ToString();
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return s == new string(arr);
        }

        static int[] FilterArray(int[] original, int[] filter)
        {
            List<int> result = new List<int>();
            foreach (int x in original)
                if (Array.IndexOf(filter, x) == -1)
                    result.Add(x);
            return result.ToArray();
        }

        class Website
        {
            public string Name, Url, Description, Ip;

            public Website(string name, string url, string desc, string ip)
            {
                Name = name; Url = url; Description = desc; Ip = ip;
            }

            public void PrintInfo() =>
                Console.WriteLine($"{Name}, {Url}, {Description}, {Ip}");
        }

        class Journal
        {
            public string Title, Description, Phone, Email;
            public int Year;

            public Journal(string title, int year, string desc, string phone, string email)
            {
                Title = title; Year = year; Description = desc; Phone = phone; Email = email;
            }

            public void PrintInfo() =>
                Console.WriteLine($"{Title}, {Year}, {Description}, {Phone}, {Email}");
        }

        class Shop
        {
            public string Name, Address, Description, Phone, Email;

            public Shop(string name, string address, string desc, string phone, string email)
            {
                Name = name; Address = address; Description = desc; Phone = phone; Email = email;
            }

            public void PrintInfo() =>
                Console.WriteLine($"{Name}, {Address}, {Description}, {Phone}, {Email}");
        }
    }
}