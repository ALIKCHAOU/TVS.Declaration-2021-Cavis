using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Ef.Migration.Declaration.Models;

namespace TVS.Ef.Migration.Declaration.Configurations
{
    class LigneBcConfig : EntityTypeConfiguration<TLigneBc>
    {
        public LigneBcConfig()
        {
            HasRequired(x => x.Declaration)
                .WithMany(x => x.Lignes)
                .HasForeignKey(x => x.DeclarationNo)
                .WillCascadeOnDelete(true);

            Property(x => x.PrixAchatHorsTaxe).HasPrecision(24, 6);
            Property(x => x.MontantTva).HasPrecision(24, 6);
        }
    }
}