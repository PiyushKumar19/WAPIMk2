using WAPIMk2.Models;
using WAPIMk2.ViemModel;

namespace WAPIMk2.Repository
{
    public interface IBooksRepo
    {
        public Task<List<BooksViewModel>> GetAllBooks();
        public Task<BooksViewModel> GetBookByIdAsync(int id);
    }
}
