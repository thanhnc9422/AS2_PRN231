using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Model;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace eBookStore.Controllers
{
    public class UsersController : Controller
    {
        private readonly HttpClient client = null;
        private string url = "";

        public UsersController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            url = "https://localhost:7163/api/user";
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.IsAdmin = HttpContext.Session.GetInt32("isAdmin");
            ViewBag.UserId = HttpContext.Session.GetInt32("userId");
            HttpResponseMessage respone = await client.GetAsync($"{url}/listUser");
            string strData = await respone.Content.ReadAsStringAsync();
            List<User> user = JsonConvert.DeserializeObject<List<User>>(strData);
            return View(user);
        }
        public async Task<IActionResult> Details(int id)
        {
            HttpResponseMessage respone = await client.GetAsync($"{url}/listUser?$filter=userId%20eq%20{id}");
            string strData = await respone.Content.ReadAsStringAsync();
            List<User> user = JsonConvert.DeserializeObject<List<User>>(strData);
            User firstUser = user[0];
            return View(firstUser);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.PubId = new SelectList("123");
            ViewBag.RoleId = new SelectList("123");
            return View();
        }
        public async Task<IActionResult> Create(User user)
        {
            HttpResponseMessage respone = await client.PostAsJsonAsync($"{url}/createUser", user);

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.IsAdmin = HttpContext.Session.GetInt32("isAdmin");
            ViewBag.UserId = HttpContext.Session.GetInt32("userId");
            HttpResponseMessage respone = await client.GetAsync($"{url}/listUser?$filter=userId%20eq%20{id}");
            string strData = await respone.Content.ReadAsStringAsync();
            List<User> users = JsonConvert.DeserializeObject<List<User>>(strData);
            User firstUser = users[0];
            ViewBag.PubId = new SelectList("123");
            ViewBag.RoleId = new SelectList("123");
            return View(firstUser);
        }
        public async Task<IActionResult> EditSave(User user)
        {
            if (HttpContext.Session.GetInt32("isAdmin") == 1)
            {
                HttpResponseMessage respone = await client.PostAsJsonAsync($"{url}/updateUser", user);
                return RedirectToAction(nameof(Index));
            }
            else {
                return Redirect("/books");
            }

        }

        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage respone = await client.GetAsync($"{url}/deleteUser/{id}");
            string strData = await respone.Content.ReadAsStringAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Logout(int id)
        {
            HttpContext.Session.Remove("userId");
            HttpContext.Session.Remove("isAdmin");

            return Redirect("/Authentication");
        }
    }
}
