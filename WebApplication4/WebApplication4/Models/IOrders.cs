using System.Collections.Generic;

namespace WebApplication4.Models
{
    public interface IOrders
    {
        string Address { get; set; }
        Customer Customer { get; set; }
        int CustomerId { get; set; }
        decimal Discount { get; set; }
        int Id { get; set; }
        List<OrderPosition> OrderPositions { get; set; }
    }
}