using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ControleUsuario.Models.Mappings
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("Usuario");

            HasKey(x => x.Id);

            Property(x => x.Nome).HasMaxLength(200).IsRequired();
            Property(x => x.Email).IsRequired();
            Property(x => x.Senha).IsRequired();
            Property(x => x.Permissao).IsRequired();
        }

    }
}