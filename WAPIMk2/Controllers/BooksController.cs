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
        public async Task<ActionResult<BooksViewModel>> GetBookById(int id)
        {
            var books = await repo.GetBookByIdAsync(id);
            if (books == null) return NotFound();
            return books;
        }
        [HttpPost]
        public async Task<ActionResult<BooksModel>> AddBook(BooksModel model)
        {
            var books = await repo.AddBookAsyncSimple(model);
            if (books == null) return NotFound();
            return CreatedAtAction(nameof(GetBookById), new { Id = model.Id },
                    books);
        }

        // To make the Put action work JSON body should have all the fields present before the updating field with the same or updating values.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, BooksModel model)
        {
            await repo.UpdateBookAsync(id, model);
            return Ok();
        }
    }
}
