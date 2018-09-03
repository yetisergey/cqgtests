namespace DeliveryCompany.Interfaces
{
    using System.Collections.Generic;
    public interface IDeliveryCompany
    {
        void AddClient(IClient o);
        void NotifyClients(Supplier supplier, List<Product> products);
        void Update(Supplier supplier, List<Product> products);
    }
}