using BE.Data.Models;
using System;

namespace BE.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Author> Authors { get; }
        IBooksRepository Books { get; }
        int Complete();
    }
}
