using MySql.Data.MySqlClient;

namespace WebApp.DataBaseSettings
{
    public interface IDBContext
    {
        public MySqlConnection DefaultConnection { get; }
    }
}
