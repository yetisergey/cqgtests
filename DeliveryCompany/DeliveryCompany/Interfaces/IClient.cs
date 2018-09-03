namespace DeliveryCompany.Interfaces
{
    using System.Collections.Generic;

    public interface IClient
    {
        List<Order> Orders { get; set; }
        void Update(List<Order> orders);
    }
}