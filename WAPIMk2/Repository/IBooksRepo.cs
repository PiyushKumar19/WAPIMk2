using Microsoft.AspNetCore.Mvc;
using WAPIMk2.Models;
using WAPIMk2.ViemModel;

namespace WAPIMk2.Repository
{
    public interface IBooksRepo
    {
        public Task<List<BooksViewModel>> GetAllBooks();
        public Task<BooksViewModel> GetBookByIdAsync(int id);
        public Task<ActionResult<BooksViewModel>> AddBookAsync(BooksViewModel model);
        public Task<ActionResult<BooksModel>> AddBookAsyncSimple(BooksModel model);
        public Task UpdateBookAsync(int id, BooksModel model);
    }
}
