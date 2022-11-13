using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WAPIMk2.Data;
using WAPIMk2.Models;
using WAPIMk2.Repository;
using WAPIMk2.ViemModel;

namespace WAPIMk2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepo repo;

        public BooksController(IBooksRepo _repo)
        {
            this.repo = _repo;
        }

        [HttpGet]
        public async Task<List<BooksViewModel>> GetAllBooks()
        {
            var books = await repo.GetAllBooks();
            return books;
        }
        [HttpGet("{id}")]
        public async Task<BooksViewModel> GetAllBooks(int id)
        {
            var books = await repo.GetBookByIdAsync(id);
            return books;
        }
    }
}
