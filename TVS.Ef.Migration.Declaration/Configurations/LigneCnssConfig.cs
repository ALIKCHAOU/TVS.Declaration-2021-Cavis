using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Ef.Migration.Declaration.Models;

namespace TVS.Ef.Migration.Declaration.Configurations
{
    class LigneCnssConfig : EntityTypeConfiguration<TLigneCnss>
    {
        public LigneCnssConfig()
        {
            HasRequired(x => x.Categorie)
                .WithMany(x => x.LignesCnss)
                .HasForeignKey(x => x.CategorieNo)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Declaration)
                .WithMany(x => x.Lignes)
                .HasForeignKey(x => x.DeclarationNo)
                .WillCascadeOnDelete(true);

            Property(x => x.Brut1).HasPrecision(24, 6);
            Property(x => x.Brut2).HasPrecision(24, 6);
            Property(x => x.Brut3).HasPrecision(24, 6);
        }
    }
}