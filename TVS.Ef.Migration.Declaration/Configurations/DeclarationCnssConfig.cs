using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Ef.Migration.Declaration.Models;

namespace TVS.Ef.Migration.Declaration.Configurations
{
    class DeclarationCnssConfig : EntityTypeConfiguration<TDeclarationCnss>
    {
        public DeclarationCnssConfig()
        {
            //Clé etranger avec table societe
            HasRequired(x => x.Societe)
                .WithMany(x => x.DeclarationCnss)
                .HasForeignKey(x => x.SocieteId)
                .WillCascadeOnDelete(true);

            // clé etranger avec table categorie
            HasRequired(x => x.Exercice)
                .WithMany(x => x.DeclarationCnss)
                .HasForeignKey(x => x.ExerciceId)
                .WillCascadeOnDelete(true);
        }
    }
}