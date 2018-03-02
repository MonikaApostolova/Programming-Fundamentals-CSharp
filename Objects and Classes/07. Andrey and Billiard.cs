using System;
using System.Collections.Generic;
using System.Linq;

class AndreyAndBilliard
{
    static void Main()
    {
        var listOfProductsAvaliable = new List<Product>();
        var result = new List<Client>();
        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {

            string[] product = Console.ReadLine().Split('-');
            string productName = product[0];
            if (listOfProductsAvaliable.Where(p => p.Name == productName).Count() == 0)
            {
                Product currentProduct = new Product() { Name = productName, Price = decimal.Parse(product[1]) };
                listOfProductsAvaliable.Add(currentProduct);
            }
            else
            {
                Product productFromList = listOfProductsAvaliable.Where(p => p.Name == productName).First();
                productFromList.Price = decimal.Parse(product[1]);
            }
        }

        while (true)
        {
            string[] order = Console.ReadLine().Split('-', ',').Where(a => a.Length > 0).ToArray();
            if (order[0] == "end of clients")
                break;
            string customerName = order[0];
            string orderProduct = order[1];
            int orderQuantity = int.Parse(order[2]);
            if (listOfProductsAvaliable.Where(pr => pr.Name == orderProduct).Count() > 0)
            {
                Product product = listOfProductsAvaliable.Where(pr => pr.Name == orderProduct).First();

                if (result.Where(c => c.Name == customerName).Count() > 0)
                {
                    Client clientFromList = result.Where(c => c.Name == customerName).First();

                    if (clientFromList.Products.Where(pr => pr.Key.Name == orderProduct).Count() > 0)
                    {
                        clientFromList.Products[product] += orderQuantity;
                    }
                    else
                    {
                        clientFromList.Products.Add(product, orderQuantity);
                    }
                }
                else
                {
                    Client clientToAdd = new Client() { Name = customerName, Products = new Dictionary<Product, int>() { { product, orderQuantity } } };
                    result.Add(clientToAdd);
                }
            }
        }
        decimal totalBill = 0.0m;
        foreach (var customer in result.OrderBy(c => c.Name))
        {
            Console.WriteLine($"{customer.Name}");
            foreach (var product in customer.Products)
            {
                Console.WriteLine($"-- {product.Key.Name} - {product.Value}");
            }
            totalBill += customer.Bill;
            Console.WriteLine($"Bill: {customer.Bill:F2}");
        }
        Console.WriteLine($"Total bill: {totalBill:F2}");
    }
}

class Product
{
    public string Name { get; set; }

    public decimal Price { get; set; }
}

class Client
{
    public string Name { get; set; }

    public Dictionary<Product, int> Products { get; set; }

    public decimal Bill
    {
        get
        {
            decimal totalPrice = 0.0m;

            foreach (var product in Products)
            {
                decimal productPrice = product.Key.Price;
                int quantity = product.Value;
                totalPrice += productPrice * quantity;
            }

            return totalPrice;
        }
    }
}