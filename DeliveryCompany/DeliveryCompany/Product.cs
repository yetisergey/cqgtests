namespace DeliveryCompany
{
    /// <summary>
    /// Продукт
    /// </summary>
    public class Product
    {
        public Product(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Наименование продукта
        /// </summary>
        public string Name { get; set; }
    }
}