using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Ef.Migration.Declaration.Models;

namespace TVS.Ef.Migration.Declaration.Configurations
{
    class CategorieCnssConfig : EntityTypeConfiguration<TCategorieCnss>
    {
        public CategorieCnssConfig()
        {
            //Clé etranger avec table societe
            HasRequired(x => x.Societe)
                .WithMany(x => x.CategorieCnss)
                .HasForeignKey(x => x.SocieteNo)
                .WillCascadeOnDelete(true);

            Property(x => x.TauxPatronal).HasPrecision(24, 6);
            Property(x => x.AccidentTravail).HasPrecision(24, 6);
            Property(x => x.TauxSalarial).HasPrecision(24, 6);
        }
    }
}