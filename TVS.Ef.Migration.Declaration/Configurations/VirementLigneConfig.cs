using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Ef.Migration.Declaration.Models;

namespace TVS.Ef.Migration.Declaration.Configurations
{
    class VirementLigneConfig : EntityTypeConfiguration<TVirementLigne>
    {
        public VirementLigneConfig()
        {
            HasRequired(x => x.Entete)
                .WithMany(x => x.Lignes)
                .HasForeignKey(x => x.EnteteId)
                .WillCascadeOnDelete(true);

            Property(x => x.NetAPaye).HasPrecision(24, 3);
        }
    }
}
