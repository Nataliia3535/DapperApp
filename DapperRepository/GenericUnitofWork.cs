using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DapperRepository
{
    public class GenericUnitOfWork
    {
        private string connectionString;

        public GenericUnitOfWork(string connectionString)
        {
            this.connectionString = connectionString;

        }


        private IDbConnection CreateConnection()

        {

            return new SqlConnection(connectionString);

        }


        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();



        public IGenericRepository<T> Repository<T>() where T : class

        {


            if (repositories.Keys.Contains(typeof(T)) == true)

            {

                return repositories[typeof(T)] as IGenericRepository<T>;

            }

            IGenericRepository<T> repo = new DapperGenericRepository<T>(typeof(T).Name, CreateConnection());

            repositories.Add(typeof(T), repo);

            return repo;

        }

    }
}
