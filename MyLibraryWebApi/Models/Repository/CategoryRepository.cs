using MyLibraryWebApi.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibraryWebApi.Models.Repository
{
    public class CategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> Get()
        {
            return _context.Categories.ToList();
        }
        public void Add(Category category)
        {
            _context.Categories.Add(category);
        }
        public void Delete(int id)
        {
            var categoryToDelete = _context.Categories.First(x => x.Id == id);
            _context.Categories.Remove(categoryToDelete);
        }
    }
}
