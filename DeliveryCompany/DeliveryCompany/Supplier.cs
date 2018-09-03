namespace DeliveryCompany
{
    using Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Поставщик
    /// </summary>
    public class Supplier : ISupplier
    {
        /// <summary>
        /// Имя поставщика
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Товары для поставки
        /// </summary>
        public List<Product> Products { get; set; }

        /// <summary>
        /// Наблюдатели
        /// </summary>
        private List<IDeliveryCompany> deliveryCompanies = new List<IDeliveryCompany>();

        /// <summary>
        /// Получить комбинированные заказы
        /// </summary>
        /// <param name="products"></param>
        public void GetCombinedOrders(List<Product> products)
        {
            // оповещаем компании по доставке
            var productsFromSupplier = products.Where(product => Products.Any(u => u.Name == product.Name)).ToList();
            NotifyObservers(productsFromSupplier);
        }

        /// <summary>
        /// Добавить наблюдателя
        /// </summary>
        /// <param name="deliveryCompany"></param>
        public void AddObserver(IDeliveryCompany deliveryCompany)
        {
            deliveryCompanies.Add(deliveryCompany);
        }

        /// <summary>
        /// Оповестить пользователей
        /// </summary>
        /// <param name="products"></param>
        public void NotifyObservers(List<Product> products)
        {
            foreach (IDeliveryCompany observer in deliveryCompanies)
                observer.Update(this, products);
        }
    }
}