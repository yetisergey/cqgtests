namespace DeliveryCompany
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Клиент
    /// </summary>
    public class Client : IClient
    {
        /// <summary>
        /// Имя клиента
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Добавить заказ
        /// </summary>
        /// <param name="orders"></param>
        public void AddOrder(List<Order> orders)
        {
            Orders = orders;
        }

        /// <summary>
        /// Заказы клиента
        /// </summary>
        public List<Order> Orders { get; set; }

        /// <summary>
        /// callback на получение статуса о доставке
        /// </summary>
        public void Update(List<Order> orders)
        {
            foreach (var item in Orders)
                if (orders.Contains(item))
                {
                    item.IsDelivered = true;
                    Console.WriteLine($"Доставлено - {this.Name} - {item.Supplier.Name} - {string.Join(", ", item.Products.Select(u => u.Name))}");
                }
        }
    }
}