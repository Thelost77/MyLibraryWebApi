using MyLibraryWebApi.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibraryWebApi
{
    public class UnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Book = new BookRepository(context);
            Category = new CategoryRepository(context);
            User = new UserRepository(context);
        }
        public BookRepository Book { get; }
        public CategoryRepository Category { get; }
        public UserRepository User { get; }
        public void Complete()
        {
            _context.SaveChanges();
        }

    }
}
