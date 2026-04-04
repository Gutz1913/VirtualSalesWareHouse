using VirtualSalesWareHouse.Common;
using VirtualSalesWareHouse.Data.Entities;

namespace VirtualSalesWareHouse.Models;

public class HomeViewModel
{
    public PaginatedList<Product> Products { get; set; }
    public ICollection<Category> Categories { get; set; }
    public float Quantity { get; set; }
}
