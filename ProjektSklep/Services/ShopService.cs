using ProjektSklep.Models;
using System.Collections.Generic;
using System.Linq;
using ProjektSklep.Data;
using Microsoft.EntityFrameworkCore;

namespace ProjektSklep.Services
{
    public class ShopService : IShopService
    {
        private readonly ProjektSklepContext _context;

        public ShopService(ProjektSklepContext context)
        {
            _context = context;
        }

        public int Delete(int id)
        {
            var products = _context.Products.Include(c => c.Category).Include(d => d.Client).ToList();
            var product = products.Find(c=> c.ProductID == id);
            _context.Products.Remove(product);
            _context.SaveChanges();

            return id;
        }
        public int Edit(Product product)
        {
            using(var context = _context)
            {
                context.Products.Attach(product);
                context.Entry(product).Property(c=>c.Name).IsModified=true ;
                context.Entry(product).Property(c => c.Description).IsModified = true;
                context.Entry(product).Property(c=>c.Cena).IsModified=true;
                context.SaveChanges();
            }
            return product.ProductID;
        }

        public Product Get(int id)
        {
            var products = _context.Products.Include(c => c.Category).Include(d=>d.Client).ToList();
            var product = products.Find(c => c.ProductID == id);
            return product;
        }

        public List<Product> GetAll()
        {
            var products = _context.Products.Include(c => c.Category).Include(d => d.Client).ToList();

            return products;
        }

        public int Save(Product product)
        {
            _context.Products.Add(product);

            if (_context.SaveChanges() > 0)
            {
                System.Console.WriteLine("SUKCES");
            };

            return product.ProductID;
        }
    }
}