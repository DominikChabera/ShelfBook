using AutoMapper;
using ShelfBook.Dtos;
using ShelfBook.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShelfBook.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext _context;
        public BooksController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Books
        public ActionResult Index()
        {

            var books = _context.Books
                .Include(b => b.Price)
                .Include(b => b.Image)
                .Include(b => b.Genre)
                .Include(b => b.Author)
                .Include(b => b.PublishingHouse).ToList().Select(Mapper.Map<Book, BookDto>);
            return View(books);
        }

        [HttpGet]
        [Route("Books/EditBook/{Id}")]
        public ActionResult EditBook(int Id)
        {
            var book = _context.Books
                .Include(b => b.Price)
                .Include(b => b.Image)
                .Include(b => b.Genre)
                .Include(b => b.Author)
                .Include(b => b.PublishingHouse)
                .Single(b => b.Id == Id);
            return PartialView("_Edit", Mapper.Map<Book, BookDto>(book));
        }
        [AcceptVerbs(HttpVerbs.Put)]
        public ActionResult UpdateBook(int Id, string title, string genre, string authorFullName, string iSBN, string publishingHouse, decimal normalPrice, decimal promotialPrice, HttpPostedFileBase image)
        {
            Book book = _context.Books
                .Include(b => b.Price)
                .Include(b => b.Image)
                .Include(b => b.Genre)
                .Include(b => b.Author)
                .Include(b => b.PublishingHouse)
                .Single(b => b.Id == Id);
            Genre genreInDb = _context.Genres.SingleOrDefault(n => n.Name.Equals(genre, StringComparison.OrdinalIgnoreCase));
            Author autorInDb = _context.Authors.SingleOrDefault(n => n.ViewFullName.Equals(authorFullName, StringComparison.OrdinalIgnoreCase));
            PublishingHouse publishingHouseInDb = _context.PublishingHouses.SingleOrDefault(n => n.Name.Equals(publishingHouse, StringComparison.OrdinalIgnoreCase));
            Price priceInDb = _context.Prices.SingleOrDefault(n => n.Id == book.PriceId);
            if (image != null)
            {
                book.Image = SetImagePatch(image);
                _context.SaveChanges();
            }
            if (!book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                book.Title = title;
            if (!book.Genre.Name.Equals(genre, StringComparison.OrdinalIgnoreCase))
            {
                if (genreInDb == null)
                {
                    Genre newGenre = new Genre() { Name = genre };
                    _context.Genres.Add(newGenre);
                    _context.SaveChanges();
                    genreInDb = _context.Genres.Single(n => n.Name.Equals(genre, StringComparison.OrdinalIgnoreCase));
                }
                book.Genre = genreInDb;
            }
            if (!book.Author.ViewFullName.Equals(authorFullName, StringComparison.OrdinalIgnoreCase))
                book.Author = autorInDb;
            if (!book.PublishingHouse.Name.Equals(publishingHouse, StringComparison.OrdinalIgnoreCase))
            {
                if (publishingHouseInDb == null)
                {
                    PublishingHouse newPublishingHouse = new PublishingHouse() { Name = publishingHouse };
                    _context.PublishingHouses.Add(newPublishingHouse);
                    _context.SaveChanges();
                    publishingHouseInDb = _context.PublishingHouses.Single(n => n.Name.Equals(publishingHouse, StringComparison.OrdinalIgnoreCase));
                }
                book.PublishingHouse = publishingHouseInDb;
            }
            if (priceInDb != null)
            {
                if (priceInDb.PromotionalPrice != promotialPrice || priceInDb.NormalPrice != normalPrice)
                {
                    priceInDb.PromotionalPrice = promotialPrice;
                    priceInDb.NormalPrice = normalPrice;
                }
            }
            if (!book.ISBN.Equals(iSBN, StringComparison.OrdinalIgnoreCase))
                book.ISBN = iSBN;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("Books/AddNewBook")]
        public ActionResult AddNewBook(string title, string genre, string authorFirstName, string authorSecondName, string authorSurname, string authorFullName, string iSBN, string publishingHouse, decimal normalPrice, decimal promotialPrice, HttpPostedFileBase image)
        {
            Book book = new Book();
            Genre genreInDb = _context.Genres.SingleOrDefault(n => n.Name.Equals(genre, StringComparison.OrdinalIgnoreCase));
            Author autorInDb = _context.Authors.SingleOrDefault(n => n.ViewFullName.Equals(authorFullName, StringComparison.OrdinalIgnoreCase));
            PublishingHouse publishingHouseInDb = _context.PublishingHouses.SingleOrDefault(n => n.Name.Equals(publishingHouse, StringComparison.OrdinalIgnoreCase));
            book.Title = title;
            book.ISBN = iSBN;
            if (image != null)
            {
                book.Image = SetImagePatch(image);
                book.Image.Title = title;
                _context.SaveChanges();
            }
            if (genreInDb == null)
            {
                Genre newGenre = new Genre() { Name = genre };
                _context.Genres.Add(newGenre);
                _context.SaveChanges();
                genreInDb = _context.Genres.Single(n => n.Name.Equals(genre, StringComparison.OrdinalIgnoreCase));
            }
            book.Genre = genreInDb;
            if (autorInDb == null)
            {
                Author newAutor = new Author()
                {
                    FirstName = authorFirstName,
                    SecondName = authorSecondName,
                    Surname = authorSurname,
                    ViewFullName = authorFullName
                };
                _context.Authors.Add(newAutor);
                _context.SaveChanges();
                autorInDb = _context.Authors.Single(n => n.ViewFullName.Equals(authorFullName, StringComparison.OrdinalIgnoreCase));
            }
            book.Author = autorInDb;
            if (publishingHouseInDb == null)
            {
                PublishingHouse newPublishingHouse = new PublishingHouse() { Name = publishingHouse };
                _context.PublishingHouses.Add(newPublishingHouse);
                _context.SaveChanges();
                publishingHouseInDb = _context.PublishingHouses.Single(n => n.Name.Equals(publishingHouse, StringComparison.OrdinalIgnoreCase));
            }
            book.PublishingHouse = publishingHouseInDb;
            Price price = new Price()
            {
                NormalPrice = normalPrice,
                PromotionalPrice = promotialPrice
            };
            _context.Prices.Add(price);
            _context.SaveChanges();
            book.Price = price;
            _context.Books.Add(book);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("Books/AddNewBookView")]
        public ActionResult AddNewBookView()
        {
            return PartialView("_Add");
        }
        [HttpDelete]
        [Route("Books/DeleteBook/{Id}")]
        public ActionResult DeleteBook(int Id)
        {
            var book = _context.Books
                        .Include(b => b.Price)
                        .Include(b => b.Image)
                        .Single(b => b.Id == Id);
            var price = _context.Prices.Single(b => b.Id == book.PriceId);
            var image = _context.Images.Single(b => b.Id == book.ImageId);
            _context.Prices.Remove(price);
            _context.Images.Remove(image);
            _context.Books.Remove(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        private Image SetImagePatch(HttpPostedFileBase image)
        {
            Image picture = new Image();
            var filename = Path.GetFileName(image.FileName);
            var path = Path.Combine(Server.MapPath("~/Content/Images/"), filename);
            string[] Documents = Directory.GetFiles(Server.MapPath("~/Content/Images/"));
            List<string> f = new List<string>();
            foreach (var item in Documents)
            {
                f.Add(item.Replace(Server.MapPath("~/Content/Images/"), ""));
            }
            bool addImage = f.Any(x => x.Contains(filename));
            if (!addImage)
            {
                image.SaveAs(path);
            }
            picture.ImagePath = "~/Content/Images/" + filename;
            return picture;
        }
    }
}