using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CriadoParaVoceWeb.Models;


namespace CriadoParaVoceWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Caneca()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult TermosDeUso()
        {
            return View();
        }

        public ActionResult FaleConosco(CriadoParaVoceWeb.Models.tbFALE_CONOSCO faleConosco)
        {
            if (ModelState.IsValid)
            {
                using (Models.CriadoParaVoceEntities17 db = new CriadoParaVoceEntities17())
                {
                    faleConosco.DATA_MSG = DateTime.Now;
                    db.tbFALE_CONOSCO.Add(faleConosco);
                    db.SaveChanges();
                    ModelState.Clear();                  
                    faleConosco = null;
                    ViewBag.Mensagem = "Mensagem enviada com sucesso";
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(CriadoParaVoceWeb.Models.USUARIOWEB f)
        {
            if (ModelState.IsValid)//Verifica se é valido
            {
                using (CriadoParaVoceWeb.Models.CriadoParaVoceEntities17 dc = new Models.CriadoParaVoceEntities17())
                {
                    Session.Clear();
                    var v = dc.USUARIOWEB.Where(a => a.Login.Equals(f.Login)
                     && a.senha.Equals(f.senha)).FirstOrDefault();

                    if (v.perfil.Equals("adm"))
                    {
                        Session["usuarioLogadoID"] = v.IdUsuario.ToString();
                        Session["nomeUsuarioLogado"] = v.Login.ToString();
                        Session["perfil"] = v.perfil.ToString();
                        return RedirectToAction("Index", "Home");
                    }

                    if (v.perfil.Equals("usuario"))
                    {
                        Session["usuarioLogadoID"] = v.IdUsuario.ToString();
                        Session["nomeUsuarioLogado"] = v.Login.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewData["LoginApresenta"] = "Login e/ou senha invalido!!!";
                    }
                }
            }
            return View(f);
        }

        public ActionResult Capas()
        {
            return View();
        }

        /*public ActionResult CadastrarFuncionario()
        {
            return View();
        }*/

        /*public ActionResult BuscarLogin()
        {
          *  return View();
        }*/

        public ActionResult Camisas()
        {
            return View();
        }

        public ActionResult BuscarLogin()
        {
            Models.CriadoParaVoceEntities17 db = new Models.CriadoParaVoceEntities17();
            List<Models.USUARIOWEB> listaLogin = db.USUARIOWEB.OrderBy(x => x.IdUsuario).ToList<Models.USUARIOWEB>();
            return View(listaLogin);

        }

        public ActionResult BuscarCategoria()
        {
            Models.CriadoParaVoceEntities17 db = new Models.CriadoParaVoceEntities17();
            List<Models.tbCategoria> listaCategoria = db.tbCategoria.OrderByDescending(x => x.CategoriaID).ToList<Models.tbCategoria>();
            return View(listaCategoria);

        }
        public ActionResult Catalogo()
        {
            Models.CriadoParaVoceEntities17 db = new Models.CriadoParaVoceEntities17();
            List<Models.tbProduto> listaProduto = db.tbProduto.OrderBy(x => x.CodigoProduto).ToList<Models.tbProduto>();
            return View(listaProduto);

        }
        public ActionResult CadastrarFuncionario(Models.tbFuncionario func)
        {
            if (ModelState.IsValid)
            {
                using (Models.CriadoParaVoceEntities17 db = new Models.CriadoParaVoceEntities17())
                {
                    db.tbFuncionario.Add(func);
                    db.SaveChanges();
                    ModelState.Clear();
                    func = null;
                    ViewBag.Mensagem = "Funcionario Registrado com Sucesso!";
                    return RedirectToAction("Index", "HomeController");
                }
            }
            else
            {
                return View();
            }
        }

    }
}