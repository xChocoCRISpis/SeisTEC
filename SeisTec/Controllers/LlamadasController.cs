using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeisTec.Models;
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
        public ActionResult Index()
        {
            var llamadas = _llamadasService.Get();
            return View(llamadas);
        }

        public IActionResult AddNewTelefono()
        {
            _llamadasService.AddNewTelefono();
            return RedirectToAction(nameof(Index));
        }

        // GET: LlamadasController/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var llamada = _llamadasService.Get(id);
            if (llamada == null)
            {
                return NotFound();
            }
            return View(llamada);
        }

        // GET: LlamadasController/Create
        public ActionResult Create(int id)
        {
            var llamadaModel = new LlamadasModel { IdTelefono = id };
            return View(llamadaModel);
        }

        // POST: LlamadasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LlamadasModel model)
        {
            if (ModelState.IsValid)
            {
                // Verificar si la lista de llamadas no está vacía
                if (model.Llamada != null && model.Llamada.Count > 0)
                {
                    _llamadasService.AddLlamada(model.IdTelefono, model.Llamada[0]);
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
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
