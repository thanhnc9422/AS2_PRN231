using BusinessObject.Model;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using System.Text.Json.Nodes;

namespace eBookStoreWebAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserAPI : ControllerBase
    {
        private UserRepository userRepository = new UserRepository();
        [HttpGet("listUser")]
        [EnableQuery]
        public ActionResult<IEnumerable<User>> listUser()
        {
            List<User> users = userRepository.listUser();
            return userRepository.listUser();
            
        }
        [HttpGet("deleteUser/{id}")]
        public ActionResult<IEnumerable<User>> deleteUser(int id)
        {
            userRepository.deleteUser(id);
            return NoContent();
        }
        [HttpPost("updateUser")]
        public ActionResult<IEnumerable<User>> updateUser(User user)
        {
            userRepository.updateUser(user);
            return NoContent();
        }
        [HttpPost("createUser")]
        public ActionResult<IEnumerable<User>> createUser(User user)
        {
            userRepository.createUser(user);
            return NoContent();
        }
    }
}
