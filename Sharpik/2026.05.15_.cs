using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dzshka
{

    // 1
    struct Article
    {
        public int ProductCode;
        public string ProductName;
        public decimal Price;
    }

    // 2
    struct Client
    {
        public int ClientCode;
        public string FullName;
        public string Address;
        public string Phone;
        public int OrderCount;
        public decimal TotalOrderAmount;
    }

    // 3
    struct RequestItem
    {
        public Article Product;
        public int Quantity;
    }

    // 4
    struct Request
    {
        public int OrderCode;
        public Client Client;
        public DateTime OrderDate;
        public List<RequestItem> Items;

        public decimal TotalAmount
        {
            get
            {
                if (Items == null || Items.Count == 0)
                    return 0;
                return Items.Sum(item => item.Product.Price * item.Quantity);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Article phone  = new Article { ProductCode = 1, ProductName = "Телефон", Price = 15000 };
            Article pc = new Article { ProductCode = 2, ProductName = "Компьютер", Price = 50000 };

            Client client = new Client
            {
                ClientCode = 100,
                FullName = "{Халиулин Алексей Александрович}",
                Address = "ул Чкалова д 15",
                Phone = "+79244714430",
                OrderCount = 5,
                TotalOrderAmount = 15000m
            };

            RequestItem item1 = new RequestItem { Product = phone, Quantity = 2 };
            RequestItem item2 = new RequestItem { Product = pc, Quantity = 1 };

            Request order = new Request
            {
                OrderCode = 1001,
                Client = client,
                OrderDate = DateTime.Now,
                Items = new List<RequestItem> { item1, item2 }
            };

            Console.WriteLine($"Заказ №{order.OrderCode}");
            Console.WriteLine($"Клиент: {order.Client.FullName}");
            Console.WriteLine($"Дата: {order.OrderDate}");
            Console.WriteLine($"Сумма заказа: {order.TotalAmount} руб.");
        }
    }
}
