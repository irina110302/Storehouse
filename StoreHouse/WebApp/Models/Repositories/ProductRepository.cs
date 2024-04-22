using Dapper;
using WebApp.DataBaseSettings;
using WebApp.Models.Entities;

namespace WebApp.Models.Repositories
{
    public class ProductRepository : ARepository<Product>
    {
        private static readonly string s_tableName = "Product";
        private static readonly string s_idField = "Id";
        private static readonly string s_nameField = "Name";
        private static readonly string s_manufacturerField = "Manufacturer";
        private static readonly string s_colorField = "ColorId";

        private static readonly string s_colorTableName = "Color";
        private static readonly string s_colorIdField = "Id";
        private static readonly string s_colorNameField = "Id";

        public static string SelectAllQuery => 
            $"SELECT `p`.{s_idField}, `p`.{s_nameField}, `p`.{s_manufacturerField}, `c`.* " +
            $"FROM {s_tableName} as `p`" +
            $"LEFT OUTER JOIN {s_colorTableName} as `c` " +
            $"ON `p`.{s_colorField} = `c`.{s_colorIdField}";

        public static string SelectById(int id) => 
            $"{SelectAllQuery} WHERE `p`.{s_colorIdField} = {id}";

        public static string SelectProductByStorehouse(int storehouseId) =>
            $"";

        public ProductRepository(IDBContext dBContext) : base(dBContext) 
        { 
            
        }

        public override void Delete(Product entity)
        {
            var query = 
                $"DELETE FROM {s_tableName} as `p` " +
                $"WHERE `p`.{s_idField} = {entity.Id}";

            Connection.Execute(query);
        }

        public override IEnumerable<Product> ExecuteQuery(string query)
        {
            return Connection.Query<Product, Color, Product>(
                query, 
                (product, color) => 
                {
                    product.Color = color;
                    return product;
                }
            );
        }

        public override void Insert(Product entity)
        {
            var query =
                $"INSERT INTO {s_tableName} ({s_nameField},{s_manufacturerField},{s_colorField}) " +
                $"VALUES " +
                $"('{entity.Name}', '{entity.Manufacturer}', {(entity.Color is null ? "NULL" : entity.Color?.Id)})";

            Connection.Execute(query);
        }

        public override void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
