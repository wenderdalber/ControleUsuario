using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleUsuario.Models
{
    public class UsuarioDAO
    {
        public void Adicionar(Usuario usuario)
        {
            using (ControleUsuarioContext banco = new ControleUsuarioContext())
            {
                if (banco.Usuarios.Count() > 0)
                {
                    usuario.Id = banco.Usuarios.Max(x => x.Id) + 1;
                }
                else
                {
                    usuario.Id = 1;
                }
                banco.Usuarios.Add(usuario);
                banco.SaveChanges();
            }
        }

        public void Alterar(Usuario usuario, int id)
        {
            using (ControleUsuarioContext banco = new ControleUsuarioContext())
            {
                Usuario usuarioAlterado = banco.Usuarios.Where(x => x.Id == id).FirstOrDefault();
                usuarioAlterado.Email = usuario.Email;
                usuarioAlterado.Nome = usuario.Nome;
                usuarioAlterado.Permissao = usuario.Permissao;
                if (usuario.Senha != "")
                    usuarioAlterado.Senha = usuario.Senha;
                banco.SaveChanges();
            }
        }

        public void Remover(Usuario usuario)
        {
            using (ControleUsuarioContext banco = new ControleUsuarioContext())
            {
                banco.Usuarios.Remove(usuario);
                banco.SaveChanges();
            }
        }

        public IEnumerable<Usuario> Pesquisar(System.Linq.Expressions.Expression<Func<Usuario, bool>> where)
        {
            using (ControleUsuarioContext banco = new ControleUsuarioContext())
            {
                return banco.Usuarios.Where(where).ToList();
            }
        }
    }
}