using BE.Data.Models;
using System.Collections.Generic;

namespace BE.Interfaces
{
    public interface IBooksRepository : IBaseRepository<Book>
    {
        IEnumerable<Book> SpecialMethod();
    }
}
