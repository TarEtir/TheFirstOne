using System.Collections.Generic;

namespace WebApplication4.Models
{
    public interface ICategory
    {
        int Id { get; set; }
        string Name { get; set; }
        List<Product> Products { get; set; }
    }
}