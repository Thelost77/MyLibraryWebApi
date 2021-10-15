using Microsoft.EntityFrameworkCore;
using MyLibraryWebApi.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace MyLibraryWebApi.Models.Repository
{
    public class BookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Book> GetAllBooks(int categoryId = 0, string title = null)
        {
            var books = _context.Books.Include(x => x.Category)
                .AsQueryable();

            if (categoryId != 0)
                books = books.Where(x => x.CategoryId == categoryId);

            if (!string.IsNullOrWhiteSpace(title))
                books = books.Where(x => x.Title.Contains(title));

            return books.OrderBy(x => x.Title).ToList();

        }
        public IEnumerable<Book> Get()
        {
            return _context.Books.ToList().OrderBy(x => x.Title);
        }
        public IEnumerable<Book> Get(int numberOfRecords, int pageNumber = 1)
        {
            var listOfBooks = _context.Books.Skip(numberOfRecords * (pageNumber - 1)).ToList();
            return listOfBooks.Take(numberOfRecords).OrderBy(x => x.Title);
        }

        public Book Get(int id)
        {
            return _context.Books.FirstOrDefault(x => x.Id == id);
        }
        public void Add(Book book)
        {
            _context.Books.Add(book);
        }

        public void Update(Book book)
        {
            var bookToUpdate = _context.Books.First(x => x.Id == book.Id);

            bookToUpdate.CategoryId = book.CategoryId;
            bookToUpdate.Pages = book.Pages;
            bookToUpdate.Author = book.Author;
            bookToUpdate.BookPicture = book.BookPicture;
            bookToUpdate.Title = book.Title;

            _context.Books.Update(bookToUpdate);
        }
        public void Delete(int id)
        {
            var bookToDelete = _context.Books.First(x => x.Id == id);
            _context.Books.Remove(bookToDelete);
        }
    }
}
