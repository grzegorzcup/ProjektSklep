using ProjektSklep.Models;

namespace ProjektSklep.Repository
{
    public interface IRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductByID(int ID);
        void AddProduct(Product product);
        void DeleteProduct(Product product);
        void UpdateProduct(Product product);
    }
}
