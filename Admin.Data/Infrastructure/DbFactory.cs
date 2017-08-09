namespace Admin.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private AdminDbContext dbContext;

        public AdminDbContext Init()
        {
            return dbContext ?? (dbContext = new AdminDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}