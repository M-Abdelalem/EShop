using Npgsql;
using System.Data;

namespace Discount.ApI
{
    public class RepositoryBase
    {
        public IDbConnection _connection;

        public RepositoryBase(IDbConnection connection)
        {
            _connection = connection;

        }

    }
}
