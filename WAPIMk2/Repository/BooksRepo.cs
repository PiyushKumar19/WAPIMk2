using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using WAPIMk2.Data;
using WAPIMk2.Models;
using WAPIMk2.ViemModel;

namespace WAPIMk2.Repository
{
    public class BooksRepo: IBooksRepo
    {
        private readonly DatabaseContext context;

        public BooksRepo(DatabaseContext _context)
        {
            context = _context;
        }
        public async Task<List<BooksViewModel>> GetAllBooks()
        {
            var books = await context.Books.Select(x=> new BooksViewModel()
            { 
                Id=x.Id,
                Title=x.Title,
                Description=x.Description,
                Price=x.Price
            }).ToListAsync();
            return books;
        }

        public async Task<BooksViewModel> GetBookByIdAsync(int id)
        {
            // Where method is used to find the key in any column, primary or not primary.
            var records = await context.Books.Where(x => x.Id == id).Select(x => new BooksViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description
            }).FirstOrDefaultAsync();
            return records;
        }

        public async Task<ActionResult<BooksViewModel>> AddBookAsync(BooksViewModel model)
        {
            var book = new BooksModel()
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                Price = model.Price
            };
            await context.AddAsync(book);
            await context.SaveChangesAsync();
            return model;

        }
        public async Task<ActionResult<BooksModel>> AddBookAsyncSimple(BooksModel model)
        {
            await context.AddAsync(model);
            await context.SaveChangesAsync();
            return model;

        }

        public async Task UpdateBookAsync(int id, BooksModel model)
        {
            var book = await context.Books.FindAsync(id);
            if (book != null)
            {
                book.Title = model.Title;
                book.Description = model.Description;
                book.Price = model.Price;
                await context.SaveChangesAsync();
            }
        }
    }
}
