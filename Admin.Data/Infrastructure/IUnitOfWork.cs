﻿namespace Admin.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}