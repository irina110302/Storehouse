﻿using Dapper;
using WebApp.DataBaseSettings;
using WebApp.Models.Entities;

namespace WebApp.Models.Repositories
{
    public class StorehouseRepository : ARepository<Storehouse>
    {
        private static readonly string s_tableName = "Storehouse";
        private static readonly string s_idField = "Id";
        private static readonly string s_addressField = "Address";

        public static string SelectAllQuery => $"SELECT * FROM {s_tableName}";

        public StorehouseRepository(IDBContext dbContext) : base(dbContext) 
        {
            
        }   

        public override void Delete(Storehouse entity)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Storehouse> ExecuteQuery(string query)
        {
            using var CurrentConnection = Connection;
            return CurrentConnection.Query<Storehouse>(query); 
        }

        public override void Insert(Storehouse entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(Storehouse entity)
        {
            throw new NotImplementedException();
        }
    }
}
