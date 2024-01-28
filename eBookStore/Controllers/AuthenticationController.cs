using BusinessObject.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace eBookStore.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly HttpClient client = null;
        private string url = "";
        private readonly IConfiguration _configuration;

        public AuthenticationController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            url = "https://localhost:7163/api/user";
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        public async Task<IActionResult> CreateSave(User user)
        {
            HttpResponseMessage respone = await client.PostAsJsonAsync($"{url}/createUser", user);

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Login(User user)
        {
            if (user.EmailAddress.Equals("admin") && user.Password.Equals("123"))
            {
                HttpContext.Session.SetInt32("isAdmin", 1);
                HttpContext.Session.SetInt32("userId", 0);
                return Redirect("/books");
            }
            else
            {

                HttpResponseMessage respone = await client.GetAsync($"{url}/listUser?$filter=emailAddress%20eq%20%27{user.EmailAddress}%27%20and%20password%20eq%20%27{user.Password}%27");
                string strData = await respone.Content.ReadAsStringAsync();
                if (strData != "[]")
                {
                    List<User> users = JsonConvert.DeserializeObject<List<User>>(strData);
                    User firstUser = users[0];
                    HttpContext.Session.SetInt32("userId", firstUser.UserId);
                    return Redirect("/books");
                }
                else
                {
                    ViewBag.ErrorLogin = "Login fail, check again your emailAddress and password";

                    return RedirectToAction(nameof(Index));
                }
            }
        }
    }
}
