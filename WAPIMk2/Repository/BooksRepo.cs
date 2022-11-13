using Microsoft.EntityFrameworkCore;
using WAPIMk2.Data;
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
    }
}
