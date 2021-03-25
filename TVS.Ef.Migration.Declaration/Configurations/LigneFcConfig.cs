using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Ef.Migration.Declaration.Models;

namespace TVS.Ef.Migration.Declaration.Configurations
{
    class LigneFcConfig : EntityTypeConfiguration<TLigneFacture>
    {
        public LigneFcConfig()
        {
            HasRequired(x => x.Declaration)
                .WithMany(x => x.Lignes)
                .HasForeignKey(x => x.DeclarationNo)
                .WillCascadeOnDelete(true);

            Property(x => x.PrixVenteHt).HasPrecision(24, 6);
            Property(x => x.MontantDroitConsommation).HasPrecision(24, 6);
            Property(x => x.MontantFodec).HasPrecision(24, 6);
            Property(x => x.MontantTva).HasPrecision(24, 6);
            Property(x => x.TauxDroitConsommation).HasPrecision(24, 6);
            Property(x => x.TauxFodec).HasPrecision(24, 6);
            Property(x => x.TauxTva).HasPrecision(24, 6);
        }
    }
}