using System.Collections.Generic;
namespace DeliveryCompany
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class Order
    {
        public Order(Supplier supplier, List<Product> products)
        {
            Supplier = supplier;
            Products = products;
        }

        /// <summary>
        /// Поставщик
        /// </summary>
        public Supplier Supplier { get; set; }

        /// <summary>
        /// Продукты
        /// </summary>
        public List<Product> Products { get; set; }

        /// <summary>
        /// Доставлено
        /// </summary>
        public bool IsDelivered{ get; set; }
    }
}