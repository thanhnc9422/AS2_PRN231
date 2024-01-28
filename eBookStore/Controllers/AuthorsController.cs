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
    public class AuthorsController : Controller
    {
        private readonly HttpClient client = null;
        private string url = "";

        public AuthorsController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            url = "https://localhost:7163/api/author";
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.IsAdmin = HttpContext.Session.GetInt32("isAdmin");
            ViewBag.UserId = HttpContext.Session.GetInt32("userId");
            HttpResponseMessage respone = await client.GetAsync($"{url}/listAuthor");
            string strData = await respone.Content.ReadAsStringAsync();
            List<Author> author = JsonConvert.DeserializeObject<List<Author>>(strData);
            return View(author);
        }
        public async Task<IActionResult> Details(int id)
        {
            HttpResponseMessage respone = await client.GetAsync($"{url}/listAuthor?$filter=authorId%20eq%20{id}");
            string strData = await respone.Content.ReadAsStringAsync();
            List<Author> authors = JsonConvert.DeserializeObject<List<Author>>(strData);
            Author firstAuthor = authors[0];
            return View(firstAuthor);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> Create(Author author)
        {
            HttpResponseMessage respone = await client.PostAsJsonAsync($"{url}/createAuthor", author);

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            HttpResponseMessage respone = await client.GetAsync($"{url}/listAuthor?$filter=authorId%20eq%20{id}");
            string strData = await respone.Content.ReadAsStringAsync();
            List<Author> authors = JsonConvert.DeserializeObject<List<Author>>(strData);
            Author firstAuthor = authors[0];
            return View(firstAuthor);
        }
        public async Task<IActionResult> EditSave(Author author)
        {
            HttpResponseMessage respone = await client.PostAsJsonAsync($"{url}/updateAuthor", author);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage respone = await client.GetAsync($"{url}/deleteAuthor/{id}");
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
