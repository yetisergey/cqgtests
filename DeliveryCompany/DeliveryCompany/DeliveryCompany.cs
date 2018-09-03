namespace DeliveryCompany
{
    using Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Компания по доставке
    /// </summary>
    public class DeliveryCompany : IDeliveryCompany
    {
        private List<IClient> Clients = new List<IClient>();

        /// <summary>
        /// callback на доставку товаров у конкретного поставщика
        /// </summary>
        public void Update(Supplier supplier, List<Product> products)
        {
            NotifyClients(supplier, products);
        }

        /// <summary>
        /// Отправить поставщикам агрегированные товары
        /// </summary>
        public void Send()
        {
            var orders = Clients.SelectMany(u => u.Orders).ToList();
            var suppliers = orders.Select(order => order.Supplier).Distinct().ToList();

            foreach (var supplier in suppliers)
            {
                supplier.AddObserver(this);
                var combinedOrders = orders.Where(o => o.Supplier == supplier)
                    .SelectMany(o => o.Products)
                    .Distinct()
                    .ToList();
                supplier.GetCombinedOrders(combinedOrders);
            }
        }

        /// <summary>
        /// Добавить клиента
        /// </summary>
        /// <param name="client"></param>
        public void AddClient(IClient client)
        {
            Clients.Add(client);
        }

        /// <summary>
        /// Оповестить клиентов
        /// </summary>
        public void NotifyClients(Supplier supplier, List<Product> products)
        {
            var notifingClients = Clients.Where(client => client.Orders.Where(o => o.Supplier == supplier && o.Products.All(p => products.Contains(p))).Count() > 0).ToList();

            foreach (var client in notifingClients) {
                client.Update(client.Orders.Where(o => o.Supplier == supplier && o.Products.All(p => products.Contains(p))).ToList());
            }
                
        }
    }
}