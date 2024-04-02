using MySql.Data.MySqlClient;
using WebApp.DataBaseSettings;

namespace WebApp.Models.Repositories
{
    public abstract class ARepository<T>
    {
        protected static readonly string s_shemaName = "sh_main";

        private IDBContext _dbContext;

        public ARepository(IDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected MySqlConnection Connection => _dbContext.DefaultConnection;

        public abstract void Insert(T entity);

        public abstract void Update(T entity);

        public abstract void Delete(T entity);

        public abstract IEnumerable<T> ExecuteQuery(string query);
    }
}
