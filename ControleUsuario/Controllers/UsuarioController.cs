using ControleUsuario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleUsuario.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(string nome, string email, string senha, string permissao)
        {
            Usuario usuario = new Usuario();
            UsuarioDAO bd = new UsuarioDAO();

            usuario.Nome = nome;
            usuario.Email = email;
            usuario.Senha = senha;
            usuario.Permissao = permissao;

            bd.Adicionar(usuario);

            return View();
        }

        public ActionResult Login(string email, string senha)
        {
            Usuario usuario = new Usuario();
            UsuarioDAO bd = new UsuarioDAO();

            usuario = bd.Pesquisar(x => x.Email == email && x.Senha == senha).FirstOrDefault();

            if (usuario != null)
            {
                Session["Permissao"] = usuario.Permissao;
                Session["Nome"] = usuario.Nome;

                return RedirectToAction("Logado", "Usuario");
            }
            else
            {
                TempData["Mensagem"] = "Usuário ou senha incorretos";
                return RedirectToAction("Cadastrar", "Usuario");
            }
        }

        public ActionResult Logado()
        {
            string permissao = Convert.ToString(Session["Permissao"]);

            if (Session["Permissao"] != null)
            {
                if (permissao == "Usuario")
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Admin", "Usuario");
                }
            }
            else
            {
                TempData["Mensagem"] = "Você não está logado";
                return RedirectToAction("Cadastrar", "Usuario");
            }
        }

        public ActionResult Admin()
        {
            string permissao = Convert.ToString(Session["Permissao"]);
            if (Session["Permissao"] != null)
            {
                if (permissao != "Usuario")
                {
                    return View();
                }
                else
                {
                    TempData["Mensagem"] = "Você não tem permissão para estar na página de Admin!";
                    return RedirectToAction("Cadastrar", "Usuario");
                }
            }
            else
            {
                TempData["Mensagem"] = "Você não está logado";
                return RedirectToAction("Cadastrar", "Usuario");
            }
        }

        public ActionResult Sair()
        {
            Session.Abandon();
            return RedirectToAction("Cadastrar", "Usuario");
        }
	}
}