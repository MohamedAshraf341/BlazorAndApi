using BE.Data.Models;
using BE.Interfaces;
using System.Collections.Generic;
using System;

namespace BE.Data.Repository
{
    public class BooksRepository : BaseRepository<Book>, IBooksRepository
    {
        private readonly ApplicationDbContext _context;

        public BooksRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Book> SpecialMethod()
        {
            throw new NotImplementedException();
        }
    }
}
