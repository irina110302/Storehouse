﻿using Dapper;
using WebApp.DataBaseSettings;
using WebApp.Models.Entities;

namespace WebApp.Models.Repositories
{
    public class SupplyRepository : ARepository<Supply>
    {
        private static readonly string s_tableName = "Supply";
        private static readonly string s_idField = "Id";
        private static readonly string s_storehouseIdField = "StorehouseId";
        private static readonly string s_supplierIdField = "SupplierId";

        public static string SelectAllQuery => 
            $"SELECT *, GetTotalSupplyPrice({s_idField}) as 'TotalPrice' FROM {s_tableName}";

        public static string SelectById(int id) => 
            $"{SelectAllQuery} WHERE {s_tableName}.{s_idField} = {id}";

        public SupplyRepository(IDBContext dBContext) : base(dBContext) 
        { 
        }

        public override void Delete(Supply entity)
        {
            string query =
                $"DELETE FROM {s_tableName} " +
                $"WHERE {s_tableName}.{s_idField} = {entity.Id}";

            using var CurrentConnection = Connection;
            CurrentConnection.Execute(query);
        }

        public override IEnumerable<Supply> ExecuteQuery(string query)
        {
            using var CurrentConnection = Connection;
            return CurrentConnection.Query<Supply>(query);
        }

        public override void Insert(Supply entity)
        {
            string query = 
                $"INSERT INTO {s_tableName} ({s_storehouseIdField},{s_supplierIdField}) " +
                $"VALUES ({entity.StorehouseId}, {entity.SupplierId})";

            using var CurrentConnection = Connection;
            CurrentConnection.Execute(query);
        }

        public override void Update(Supply entity)
        {
            throw new NotImplementedException();
        }
    }
}
