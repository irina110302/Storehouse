using Dapper;
using WebApp.DataBaseSettings;
using WebApp.Models.Entities;

namespace WebApp.Models.Repositories
{
    public class ProductInSupplyRepository : ARepository<ProductInSupply>
    {
        private static readonly string s_tableName = "Product_In_Supply";
        private static readonly string s_idField = "Id";
        private static readonly string s_skuField= "SKU";
        private static readonly string s_supplyIdField= "SupplyId";
        private static readonly string s_priceField= "Price";
        private static readonly string s_amountField= "Amount";

        public static string SelectAllQuery => $"SELECT * FROM {s_tableName}";

        public static string SelectBySupplyId(int supplyId) =>
            $"{SelectAllQuery} as `p` WHERE `p`.{s_supplyIdField} = {supplyId}";

        public ProductInSupplyRepository(IDBContext dBContext) : base(dBContext)
        {

        }

        public override void Delete(ProductInSupply entity)
        {
            string query =
                $"DELETE FROM {s_tableName}" +
                $"WHERE {s_tableName}.{s_idField} = {entity.Id}";

            Connection.Execute(query);
        }

        public override IEnumerable<ProductInSupply> ExecuteQuery(string query)
        {
            return Connection.Query<ProductInSupply>(query);
        }

        public override void Insert(ProductInSupply entity)
        {
            string query =
                $"INSERT INTO {s_tableName} ({s_skuField},{s_supplyIdField},{s_priceField},{s_amountField})" +
                $"VALUES ({entity.Sku},{entity.SupplyId},{entity.Price},{entity.Amount})";

            Connection.Execute(query);
        }

        public override void Update(ProductInSupply entity)
        {
            throw new NotImplementedException();
        }
    }
}
