using System;  
using System.Collections.Generic;  
using System.Diagnostics;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;
using pruebaTecnica2.Models;

namespace pruebaTecnica2.Controllers
{
    public class TerceroController : Controller
    {
        TercerosDataAccessLayer terceroObjeto = new TercerosDataAccessLayer();

        public IActionResult Index(){
            List<Terceros> listaTerceros = new List<Terceros>();
            listaTerceros = terceroObjeto.ObtenerTodosTerceros().ToList();

            return View(listaTerceros);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Terceros terceros)
        {
            if(ModelState.IsValid){
                terceroObjeto.CrearTerceros(terceros);
                return RedirectToAction("Index");
            }
            return View(terceros);
        }
    }
    
}