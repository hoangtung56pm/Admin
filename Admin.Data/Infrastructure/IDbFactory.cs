using System;

namespace Admin.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        AdminDbContext Init();
    }
}