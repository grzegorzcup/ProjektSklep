using Microsoft.EntityFrameworkCore;

namespace ProjektSklep.Models
{
    [Keyless]
    public class OrderProduct
    {
        
        IList<Product> products;
        public int ProductId { get; set; }
        IList<Order> orders;
        public int OrderId { get; set; }
    }
}
