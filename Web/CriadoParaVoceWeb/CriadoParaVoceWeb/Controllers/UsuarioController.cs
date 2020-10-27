using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CriadoParaVoceWeb.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult ProdutoUser()
        {
            return View();
        }

        public ActionResult Perfil()
        {
            return View();
        }
    }
}