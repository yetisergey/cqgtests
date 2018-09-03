namespace DeliveryCompany.Interfaces
{
    using System.Collections.Generic;

    public interface ISupplier
    {
        void AddObserver(IDeliveryCompany o);
        void NotifyObservers(List<Product> products);
    }
}