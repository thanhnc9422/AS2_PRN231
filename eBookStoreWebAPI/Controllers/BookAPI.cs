using BusinessObject.Model;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using System.Text.Json.Nodes;

namespace eBookStoreWebAPI.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookAPI : ControllerBase
    {
        private BookRepository bookRepository = new BookRepository();
        [HttpGet("listBook")]
        [EnableQuery]
        public ActionResult<IEnumerable<Book>> listBook()
        {
            return bookRepository.listBook();

        }
        [HttpGet("deleteBook/{id}")]
        public ActionResult<IEnumerable<Book>> deleteBook(int id)
        {
            bookRepository.deleteBook(id);
            return NoContent();
        }
        [HttpPost("updateBook")]
        public ActionResult<IEnumerable<Book>> updateBook(Book book)
        {
            bookRepository.updateBook(book);
            return NoContent();
        }
        [HttpPost("createBook")]
        public ActionResult<IEnumerable<Book>> createBook(Book book)
        {
            bookRepository.createBook(book);
            return NoContent();
        }
    }
}
