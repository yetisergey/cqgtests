namespace Program
{
    using DeliveryCompany;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            var dc = new DeliveryCompany();

            var products = new List<Product>() {
                new Product("a"),
                new Product("b"),
                new Product("c")
            };

            var SupplierA = new Supplier()
            {
                Name = "A",
                Products = products
            };

            var SupplierB = new Supplier()
            {
                Name = "B",
                Products = products
            };

            var SupplierC = new Supplier()
            {
                Name = "C",
                Products = products
            };

            var SupplierD = new Supplier()
            {
                Name = "D",
                Products = products
            };

            var client1 = new Client() { Name = "client1" };
            client1.AddOrder(new List<Order>
                {
                   new Order(SupplierA, new List<Product> { new Product("a"), new Product("b")  }),
                   new Order(SupplierB, new List<Product> { new Product("a"), new Product("b")  })
                });

            var client2 = new Client() { Name = "client2" };
            client2.AddOrder(new List<Order>
                {
                    new Order(SupplierC,new List<Product> { new Product("a") }),
                    new Order(SupplierB,new List<Product> { new Product("b"), new Product("c") })
                });

            var client3 = new Client() { Name = "client3" };
            client3.AddOrder(new List<Order>
                {
                    new Order(SupplierB,new List<Product> { new Product("a") }),
                    new Order(SupplierD,new List<Product> { new Product("b"), new Product("c") })
                });



            dc.AddClient(client1);
            dc.AddClient(client2);
            dc.AddClient(client3);

            dc.Send();
        }
    }
}