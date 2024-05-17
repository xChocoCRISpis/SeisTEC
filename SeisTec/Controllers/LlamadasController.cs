using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.Linq;
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
        //Get:AddTelefono
        public ActionResult AddTelefono()
        {
            var llamadaModel = new LlamadasModel { };
            return View(llamadaModel);
        }

        // POST: LlamadasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddTelefono(LlamadasModel model)
        {
            Console.WriteLine("\n\n\nSolicitud POST para agregar telefono\n\n\n");

            var idExiste=_llamadasService.GetIdTel(model.IdTelefono);

            if(idExiste == null && model.IdTelefono>0)
            {
                var nuevaLlamada = model.Llamada != null && model.Llamada.Count > 0 ? model.Llamada[0] : new llamada();
                //Console.WriteLine("\n\n\nModelo con daots\n\n\n");

                _llamadasService.AddNewTelefono(model.IdTelefono, nuevaLlamada);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["Mensaje"] = ("El telefono ya existe, o el id es inválido");
                return View(model);
            }
            //Console.WriteLine("\n" + model.IdTelefono +"\n");
            /*foreach (var llamada in model.Llamada)
            {
                Console.WriteLine(llamada.Fecha);
                Console.WriteLine(llamada.Inicio);
                Console.WriteLine(llamada.Fin);
                Console.WriteLine(llamada.Duracion);
                Console.WriteLine(llamada.Compania);
                Console.WriteLine(llamada.TelefonoId);
            }
            */
           
             //Console.WriteLine("\n\n\nModelo valido\n\n\n");
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
