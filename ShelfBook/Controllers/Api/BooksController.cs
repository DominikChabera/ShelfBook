using ShelfBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShelfBook.Controllers.Api
{
    public class BooksController : ApiController
    {
        private ApplicationDbContext _context;
        public BooksController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<Book> GetBook()
        {
            return _context.Books.ToList();
        }
    }
}
