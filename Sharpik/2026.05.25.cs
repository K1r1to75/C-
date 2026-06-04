using Dzshka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dzshka
{
    class Human
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Human(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Имя: {Name}, Возраст: {Age}");
        }
    }

    class Builder : Human
    {
        public string Speciality { get; set; }

        public Builder(string name, int age, string speciality) : base(name, age)
        {
            Speciality = speciality;
        }

        public void Build()
        {
            Console.WriteLine($"{Name} строит здание");
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Специальность строителя: {Speciality}");
        }
    }

    class Sailor : Human
    {
        public string ShipName { get; set; }

        public Sailor(string name, int age, string shipName) : base(name, age)
        {
            ShipName = shipName;
        }

        public void Sail()
        {
            Console.WriteLine($"{Name} плывет на корабле {ShipName}");
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Корабль: {ShipName}");
        }
    }

    class Pilot : Human
    {
        public string PlaneModel { get; set; }

        public Pilot(string name, int age, string planeModel) : base(name, age)
        {
            PlaneModel = planeModel;
        }

        public void Fly()
        {
            Console.WriteLine($"{Name} летит на самолете {PlaneModel}");
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Самолет: {PlaneModel}");
        }
    }

    // Задание 2
    class Passport
    {
        public string CitizenName { get; set; }
        public string Country { get; set; }
        public string PassportNumber { get; set; }

        public Passport(string name, string country, string number)
        {
            CitizenName = name;
            Country = country;
            PassportNumber = number;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Гражданин: {CitizenName}");
            Console.WriteLine($"Страна: {Country}");
            Console.WriteLine($"Номер паспорта: {PassportNumber}");
        }
    }

    class ForeignPassport : Passport
    {
        public string ForeignPassportNumber { get; set; }
        public string[] Visas { get; set; }

        public ForeignPassport(string name, string country, string number, string foreignNumber, string[] visas)
            : base(name, country, number)
        {
            ForeignPassportNumber = foreignNumber;
            Visas = visas;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Номер загранпаспорта: {ForeignPassportNumber}");
            Console.Write("Визы: ");
            if (Visas != null && Visas.Length > 0)
            {
                Console.WriteLine(string.Join(", ", Visas));
            }
            else
            {
                Console.WriteLine("нет виз");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Задание 1");
        Human builder = new Builder("Артём", 52, "Строитель");
        Human sailor = new Sailor("Евгений", 45, "Атлант");
        Human pilot = new Pilot("Александр", 28, "Boeing 787");

        builder.ShowInfo();
        ((Builder)builder).Build();
        Console.WriteLine();

        sailor.ShowInfo();
        ((Sailor)sailor).Sail();
        Console.WriteLine();

        pilot.ShowInfo();
        ((Pilot)pilot).Fly();

        Console.WriteLine("\nЗадание 2");
        string[] visas = { "Китай" };
        ForeignPassport fp = new ForeignPassport("Алексей", "Россия", "4601-729721", "75-0056743", visas);
        fp.ShowInfo();
    }
}