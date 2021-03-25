using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Ef.Migration.Declaration.Models;

namespace TVS.Ef.Migration.Declaration.Configurations
{
    class DeclarationBcConfig : EntityTypeConfiguration<TDeclarationBcSuspenssion>
    {
        public DeclarationBcConfig()
        {
            //Clé etranger avec table societe
            HasRequired(x => x.Societe)
                .WithMany(x => x.DeclarationBc)
                .HasForeignKey(x => x.SocieteId)
                .WillCascadeOnDelete(true);

            // clé etranger avec table categorie
            HasRequired(x => x.Exercice)
                .WithMany(x => x.DeclarationBc)
                .HasForeignKey(x => x.ExerciceId)
                .WillCascadeOnDelete(true);
        }
    }
}