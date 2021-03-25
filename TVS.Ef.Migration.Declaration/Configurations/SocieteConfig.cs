using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Ef.Migration.Declaration.Models;

namespace TVS.Ef.Migration.Declaration.Configurations
{
    class SocieteConfig : EntityTypeConfiguration<TSociete>
    {
        public SocieteConfig()
        {
            HasOptional(n => n.CurrentExercice)
                .WithMany(s => s.Societees)
                .HasForeignKey(n => n.CurrentExerciceNo)
                .WillCascadeOnDelete(false);
        }
    }
}