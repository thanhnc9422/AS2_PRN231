using BusinessObject.Model;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using System.Text.Json.Nodes;

namespace eBookStoreWebAPI.Controllers
{
    [Route("api/publisher")]
    [ApiController]
    public class PublisherAPI : ControllerBase
    {
        private PublisherRepository publisherRepository = new PublisherRepository();
        [HttpGet("listPublisher")]
        [EnableQuery]
        public ActionResult<IEnumerable<Publisher>> listPublisher()
        {
            return publisherRepository.listPublisher();

        }
        [HttpGet("deletePublisher/{id}")]
        public ActionResult<IEnumerable<Publisher>> deletePublisher(int id)
        {
            publisherRepository.deletePublisher(id);
            return NoContent();
        }
        [HttpPost("updatePublisher")]
        public ActionResult<IEnumerable<Publisher>> updatePublisher(Publisher publisher)
        {
            publisherRepository.updatePublisher(publisher);
            return NoContent();
        }
        [HttpPost("createPublisher")]
        public ActionResult<IEnumerable<Publisher>> createPublisher(Publisher publisher)
        {
            publisherRepository.createPublisher(publisher);
            return NoContent();
        }
    }
}
