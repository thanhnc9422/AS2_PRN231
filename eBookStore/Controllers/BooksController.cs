using BusinessObject.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace eBookStore.Controllers
{
    public class BooksController : Controller
    {
        private readonly HttpClient client = null;
        private string url = "";

        public BooksController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            url = "https://localhost:7163/api/book";
        }
        public async Task<IActionResult> Index(string search)
        {
            ViewBag.IsAdmin = HttpContext.Session.GetInt32("isAdmin");
            ViewBag.UserId = HttpContext.Session.GetInt32("userId");
            HttpResponseMessage respone = new HttpResponseMessage();
            if (search != null)
            {
                if (int.TryParse(search, out int number))
                {
                    respone = await client.GetAsync($"{url}/listBook?$filter=price%20eq%20{Int32.Parse(search)}");

                }
                else
                {
                 respone = await client.GetAsync($"{url}/listBook?$filter=contains(title,%27{search}%27)");
                }
            }
            else {             
               respone = await client.GetAsync($"{url}/listBook");     
            }
            string strData = await respone.Content.ReadAsStringAsync();
            List<Book> book = JsonConvert.DeserializeObject<List<Book>>(strData);
            return View(book);
        }
        public async Task<IActionResult> Details(int id)
        {
            HttpResponseMessage respone = await client.GetAsync($"{url}/listBook?$filter=bookId%20eq%20{id}");
            string strData = await respone.Content.ReadAsStringAsync();
            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(strData);
            Book firstBook = books[0];
            return View(firstBook);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.PubId = new SelectList("123");
            return View();
        }
        public async Task<IActionResult> Create(Book book)
        {
            HttpResponseMessage respone = await client.PostAsJsonAsync($"{url}/createBook", book);

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            HttpResponseMessage respone = await client.GetAsync($"{url}/listBook?$filter=bookId%20eq%20{id}");
            string strData = await respone.Content.ReadAsStringAsync();
            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(strData);
            Book firstBook = books[0];
            ViewBag.PubId = new SelectList("123");
            return View(firstBook);
        }
        public async Task<IActionResult> EditSave(Book book)
        {
            HttpResponseMessage respone = await client.PostAsJsonAsync($"{url}/updateBook", book);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage respone = await client.GetAsync($"{url}/deleteBook/{id}");
            string strData = await respone.Content.ReadAsStringAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Logout(int id)
        {
            HttpContext.Session.Remove("userId");
            HttpContext.Session.Remove("isAdmin");

            return Redirect("/Authentication");
        }
        public async Task<IActionResult> Search(string search)
        {
            return RedirectToAction(nameof(Index), new { search = search});
        }
    }
}
