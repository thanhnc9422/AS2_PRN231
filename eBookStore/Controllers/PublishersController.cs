using BusinessObject.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace eBookStore.Controllers
{
    public class PublishersController : Controller
    {
        private readonly HttpClient client = null;
        private string url = "";

        public PublishersController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            url = "https://localhost:7163/api/publisher";
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.IsAdmin = HttpContext.Session.GetInt32("isAdmin");
            ViewBag.UserId = HttpContext.Session.GetInt32("userId");
            HttpResponseMessage respone = await client.GetAsync($"{url}/listPublisher");
            string strData = await respone.Content.ReadAsStringAsync();
            List<Publisher> publisher = JsonConvert.DeserializeObject<List<Publisher>>(strData);
            return View(publisher);
        }
        public async Task<IActionResult> Details(int id)
        {
            HttpResponseMessage respone = await client.GetAsync($"{url}/listPublisher?$filter=pubId%20eq%20{id}");
            string strData = await respone.Content.ReadAsStringAsync();
            List<Publisher> publishers = JsonConvert.DeserializeObject<List<Publisher>>(strData);
            Publisher firstPublisher = publishers[0];
            return View(firstPublisher);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> Create(Publisher publisher)
        {
            HttpResponseMessage respone = await client.PostAsJsonAsync($"{url}/createPublisher", publisher);

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            HttpResponseMessage respone = await client.GetAsync($"{url}/listPublisher?$filter=pubId%20eq%20{id}");
            string strData = await respone.Content.ReadAsStringAsync();
            List<Publisher> publishers = JsonConvert.DeserializeObject<List<Publisher>>(strData);
            Publisher firstPublisher = publishers[0];
            return View(firstPublisher);
        }
        public async Task<IActionResult> EditSave(Publisher publisher)
        {
            HttpResponseMessage respone = await client.PostAsJsonAsync($"{url}/updatePublisher", publisher);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage respone = await client.GetAsync($"{url}/deletePublisher/{id}");
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
