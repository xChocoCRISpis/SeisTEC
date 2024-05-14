using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeisTec.Services;

namespace SeisTec.Controllers
{
    public class LlamadasController : Controller
    {
        private readonly LlamadasService _llamadasService;

        // Constructor con inyección de dependencias
        public LlamadasController(LlamadasService llamadasService)
        {
            _llamadasService = llamadasService ?? throw new ArgumentNullException(nameof(llamadasService));
        }

        // GET: LlamadasController
        // GET: LlamadasController
        public ActionResult Index()
        {
            var llamadas = _llamadasService.Get();
            return View(llamadas);
        }

        // GET: LlamadasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LlamadasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LlamadasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LlamadasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LlamadasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LlamadasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LlamadasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
