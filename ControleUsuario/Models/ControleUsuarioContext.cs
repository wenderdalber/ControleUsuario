using ControleUsuario.Models.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ControleUsuario.Models
{
    public class ControleUsuarioContext : DbContext
    {
        public ControleUsuarioContext()
            : base("ControleUsuarioConnectionString")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsuarioMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}