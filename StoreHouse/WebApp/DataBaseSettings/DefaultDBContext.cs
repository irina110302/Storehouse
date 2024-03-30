using MySql.Data.MySqlClient;

namespace WebApp.DataBaseSettings
{
    public class DefaultDBContext : IDBContext
    {
        private readonly string _defaultConnection;

        public DefaultDBContext(string defaultConnection)
        {
            _defaultConnection = defaultConnection;
        }

        public MySqlConnection DefaultConnection => new(_defaultConnection);
    }
}
