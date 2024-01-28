using BusinessObject.Model;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using System.Text.Json.Nodes;

namespace eBookStoreWebAPI.Controllers
{
    [Route("api/author")]
    [ApiController]
    public class AuthorAPI : ControllerBase
    {
        private AuthorRepository authorRepository = new AuthorRepository();
        [HttpGet("listAuthor")]
        [EnableQuery]
        public ActionResult<IEnumerable<Author>> listAuthor()
        {
            return authorRepository.listAuthor();

        }
        [HttpGet("deleteAuthor/{id}")]
        public ActionResult<IEnumerable<Author>> deleteAuthor(int id)
        {
            authorRepository.deleteAuthor(id);
            return NoContent();
        }
        [HttpPost("updateAuthor")]
        public ActionResult<IEnumerable<Author>> updateAuthor(Author author)
        {
            authorRepository.updateAuthor(author);
            return NoContent();
        }
        [HttpPost("createAuthor")]
        public ActionResult<IEnumerable<Author>> createAuthor(Author author)
        {
            authorRepository.createAuthor(author);
            return NoContent();
        }
    }
}
