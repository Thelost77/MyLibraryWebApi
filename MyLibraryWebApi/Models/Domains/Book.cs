using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibraryWebApi.Models.Domains
{
    public class Book
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public string BookPicture { get; set; }
        public int CategoryId { get; set; }
        public bool IfOwned { get; set; }
        public bool IfRead { get; set; }
        public Category Category { get; set; }
        public User User { get; set; }
    }
}
