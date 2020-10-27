using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CriadoParaVoceWeb.Controllers
{
    public class AdministradorController : Controller
    {
        // GET: Administrador
        public ActionResult RelatorioMensal()
        {
            return View();
        }
    }
}