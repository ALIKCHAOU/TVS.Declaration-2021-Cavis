using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Ef.Migration.Declaration.Models;

namespace TVS.Ef.Migration.Declaration.Configurations
{
    class EmployeeConfig : EntityTypeConfiguration<TEmployee>
    {
        public EmployeeConfig()
        {
            HasRequired(n => n.Societe)
                .WithMany(s => s.Employees)
                .HasForeignKey(n => n.SocieteNo)
                .WillCascadeOnDelete(true);

            HasRequired(n => n.Categorie)
                .WithMany(s => s.Employees)
                .HasForeignKey(n => n.CategorieNo)
                .WillCascadeOnDelete(false);
        }
    }
}