using Dapper;
using WebApp.DataBaseSettings;
using WebApp.Models.Entities;

namespace WebApp.Models.Repositories
{
    public class SkuRepository : ARepository<Sku>
    {
        private static readonly string s_tableName = "SKU";
        private static readonly string s_productIdField = "ProductId";
        private static readonly string s_skuField = "SKU";
        private static readonly string s_saleKField = "SaleK";

        private static string GetSku(int productId, DateTime productionDate, decimal saleK) => 
            $"(SELECT `GetSku`({productId}, {productionDate}, {saleK}));";

        public static string SelectSKUBySKU(string sku) =>
            $"SELECT * FROM {s_tableName} as `s` WHERE `s`.{s_skuField} = {sku};";

        public static string SelectSKUByData(int productId, DateTime productionDate, decimal saleK) =>
            $"START TRANSACTION;" +
            $"SET @sku = {GetSku(productId, productionDate, saleK)}" +
            $"{SelectSKUBySKU("@sku")}" +
            $"COMMIT;";

        public SkuRepository(IDBContext dBContext) : base(dBContext) 
        { 
            
        }

        public override void Delete(Sku entity)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Sku> ExecuteQuery(string query)
        {
            return Connection.Query<Sku>(query);
        }

        public override void Insert(Sku entity)
        {
            string? sku = Connection
                .Query<string>(GetSku(entity.ProductId, entity.ProductionDate, entity.SaleK))
                .FirstOrDefault();

            entity.SKU = sku ?? string.Empty;
        }

        public override void Update(Sku entity)
        {
            throw new NotImplementedException();
        }
    }
}
