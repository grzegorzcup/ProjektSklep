using ProjektSklep.Models;

namespace ProjektSklep.Services
{
    public interface IShopService
    {
        int Save(Product product);
        List<Product> GetAll();
        Product Get(int id);
        int Delete(int id);
    }
}
