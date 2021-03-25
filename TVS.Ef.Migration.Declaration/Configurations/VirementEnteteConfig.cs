using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Ef.Migration.Declaration.Models;

namespace TVS.Ef.Migration.Declaration.Configurations
{
    class VirementEnteteConfig : EntityTypeConfiguration<TVirementEntete>
    {
        public VirementEnteteConfig()
        {
            Property(x => x.Total).HasPrecision(24, 6);
        }
    }
}
