using Eureka.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.ComponentModel.Composition;

namespace Eureka.Infra.EntityConfiguration
{
    [Export(typeof(IEntityConfiguration))]
    public class IdeiaConfiguration : EntityTypeConfiguration<Ideia>, IEntityConfiguration
    {
        public IdeiaConfiguration()
        {
            HasKey(i => i.IdeiaID);

            Property(i => i.Titulo).IsRequired().HasMaxLength(150);
            Property(i => i.Descricao).IsRequired();
            Property(i => i.Tag).IsOptional();
            Property(i => i.Avaliacao).IsOptional();
            Property(i => i.Usuario).IsRequired();

            //Ignore(i => i.Descricao);
            //HasRequired();
            //HasOptional

            HasMany(i => i.Comentarios).WithRequired().WillCascadeOnDelete(true);
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}