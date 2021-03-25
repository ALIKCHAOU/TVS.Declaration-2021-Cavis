using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Ef.Migration.Declaration.Models;
using TVS.Ef.Migration.Declaration.Models.Dec2016;
using TVS.Ef.Migration.Declaration.Models.Liass;

namespace TVS.Ef.Migration.Declaration.Configurations.Liass
{
    class F6004ModeleAutorsieConfig : EntityTypeConfiguration<TF6004ModeleAutorsie>
    {
        public F6004ModeleAutorsieConfig()
        {
            HasRequired(x => x.Societe)
                .WithMany(x => x.F6004ModeleAutorsie)
                .HasForeignKey(x => x.SocieteNo)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Exercice)
                .WithMany(x => x.F6004ModeleAutorsie)
                .HasForeignKey(x => x.ExerciceId)
                .WillCascadeOnDelete(false);


            Property(x => x.NatureDepot).HasMaxLength(1).HasColumnType("nvarchar");
            Property(x => x.F60040001).HasPrecision(18, 3);
            Property(x => x.F60040002).HasPrecision(18, 3);
            Property(x => x.F60040003).HasPrecision(18, 3);
            Property(x => x.F60040004).HasPrecision(18, 3);
            Property(x => x.F60040005).HasPrecision(18, 3);
            Property(x => x.F60040006).HasPrecision(18, 3);
            Property(x => x.F60040007).HasPrecision(18, 3);
            Property(x => x.F60040008).HasPrecision(18, 3);
            Property(x => x.F60040009).HasPrecision(18, 3);
            Property(x => x.F60040010).HasPrecision(18, 3);
            Property(x => x.F60040011).HasPrecision(18, 3);
            Property(x => x.F60040012).HasPrecision(18, 3);
            Property(x => x.F60040013).HasPrecision(18, 3);
            Property(x => x.F60040014).HasPrecision(18, 3);
            Property(x => x.F60040015).HasPrecision(18, 3);
            Property(x => x.F60040016).HasPrecision(18, 3);
            Property(x => x.F60040017).HasPrecision(18, 3);
            Property(x => x.F60040018).HasPrecision(18, 3);
            Property(x => x.F60040019).HasPrecision(18, 3);
            Property(x => x.F60040020).HasPrecision(18, 3);
            Property(x => x.F60040021).HasPrecision(18, 3);
            Property(x => x.F60040022).HasPrecision(18, 3);
            Property(x => x.F60040023).HasPrecision(18, 3);
            Property(x => x.F60040024).HasPrecision(18, 3);
            Property(x => x.F60040025).HasPrecision(18, 3);
            Property(x => x.F60040026).HasPrecision(18, 3);
            Property(x => x.F60040027).HasPrecision(18, 3);
            
            Property(x => x.F60041001).HasPrecision(18, 3);
            Property(x => x.F60041002).HasPrecision(18, 3);
            Property(x => x.F60041003).HasPrecision(18, 3);
            Property(x => x.F60041004).HasPrecision(18, 3);
            Property(x => x.F60041005).HasPrecision(18, 3);
            Property(x => x.F60041006).HasPrecision(18, 3);
            Property(x => x.F60041007).HasPrecision(18, 3);
            Property(x => x.F60041008).HasPrecision(18, 3);
            Property(x => x.F60041009).HasPrecision(18, 3);
            Property(x => x.F60041010).HasPrecision(18, 3);
            Property(x => x.F60041011).HasPrecision(18, 3);
            Property(x => x.F60041012).HasPrecision(18, 3);
            Property(x => x.F60041013).HasPrecision(18, 3);
            Property(x => x.F60041014).HasPrecision(18, 3);
            Property(x => x.F60041015).HasPrecision(18, 3);
            Property(x => x.F60041016).HasPrecision(18, 3);
            Property(x => x.F60041017).HasPrecision(18, 3);
            Property(x => x.F60041018).HasPrecision(18, 3);
            Property(x => x.F60041019).HasPrecision(18, 3);
            Property(x => x.F60041020).HasPrecision(18, 3);
            Property(x => x.F60041021).HasPrecision(18, 3);
            Property(x => x.F60041022).HasPrecision(18, 3);
            Property(x => x.F60041023).HasPrecision(18, 3);
            Property(x => x.F60041024).HasPrecision(18, 3);
            Property(x => x.F60041025).HasPrecision(18, 3);
            Property(x => x.F60041026).HasPrecision(18, 3);
            Property(x => x.F60041027).HasPrecision(18, 3);
            
        }
    }
}