using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Ef.Migration.Declaration.Models;
using TVS.Ef.Migration.Declaration.Models.Dec2016;

namespace TVS.Ef.Migration.Declaration.Configurations.Dec2016
{
    class T2016Annexe6Config : EntityTypeConfiguration<T2016Annexe6>
    {
        public T2016Annexe6Config()
        {
            HasRequired(x => x.Societe)
                .WithMany(x => x.T2016Annexe6)
                .HasForeignKey(x => x.SocieteId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Exercice)
                .WithMany(x => x.T2016Annexe6)
                .HasForeignKey(x => x.ExerciceId)
                .WillCascadeOnDelete(false);
            Property(x => x.E12).HasPrecision(18, 3);
            Property(x => x.E13).HasPrecision(18, 3);
            Property(x => x.E14).HasPrecision(18, 3);
            Property(x => x.E15).HasPrecision(18, 3);
            Property(x => x.E16).HasPrecision(18, 3);
            Property(x => x.E17).HasPrecision(18, 3);
            Property(x => x.E18).HasPrecision(18, 3);
            Property(x => x.E19).HasPrecision(18, 3);
        }
    }
}