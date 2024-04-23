using Dapper;
using WebApp.DataBaseSettings;
using WebApp.Models.Entities;

namespace WebApp.Models.Repositories
{
    public class SupplierRepository : ARepository<Supplier>
    {
        private static readonly string s_tableName = "Supplier";

        public static string SelectAllQuery => $"SELECT * FROM {s_tableName}";

        public SupplierRepository(IDBContext dBContext) : base(dBContext) 
        {
        
        }

        public override void Delete(Supplier entity)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Supplier> ExecuteQuery(string query)
        {
            using var CurrentConnection = Connection;
            return CurrentConnection.Query<Supplier>(query);
        }

        public override void Insert(Supplier entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(Supplier entity)
        {
            throw new NotImplementedException();
        }
    }
}
