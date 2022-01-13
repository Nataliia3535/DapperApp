using DapperRepository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDapperRepository
{
    class Program
    {
        static void Main(string[] args)
        {
            //string connection = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            //GenericUnitOfWork work = new GenericUnitOfWork(connection);
            //IGenericRepository<Product> repositoryProduct = work.Repository<Product>();
            //List<Product> products = repositoryProduct.GetAll().ToList();
            //foreach (var prod in products)
            //{
            //    Console.WriteLine(prod.Id);
            //    Console.WriteLine(prod.Title);
            //    Console.WriteLine(prod.Price);
            //}
            //repositoryProduct.Add(new Product() {Id=23, Title = "ProductRep1", Price = 1000 });
        }
    }
}
