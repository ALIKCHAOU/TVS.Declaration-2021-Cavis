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
    class F6304Config : EntityTypeConfiguration<TF6304>
    {
        public F6304Config()
        {
            HasRequired(x => x.Societe)
                .WithMany(x => x.F6304)
                .HasForeignKey(x => x.SocieteNo)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Exercice)
                .WithMany(x => x.F6304)
                .HasForeignKey(x => x.ExerciceId)
                .WillCascadeOnDelete(false);


            Property(x => x.NatureDepot).HasMaxLength(1).HasColumnType("nvarchar");
            Property(x => x.F63040001).HasPrecision(18, 3);
            Property(x => x.F63040002).HasPrecision(18, 3);
            Property(x => x.F63040003).HasPrecision(18, 3);
            Property(x => x.F63040004).HasPrecision(18, 3);
            Property(x => x.F63040005).HasPrecision(18, 3);
            Property(x => x.F63040006).HasPrecision(18, 3);
            Property(x => x.F63040007).HasPrecision(18, 3);
            Property(x => x.F63040008).HasPrecision(18, 3);
            Property(x => x.F63040009).HasPrecision(18, 3);
            Property(x => x.F63040010).HasPrecision(18, 3);
            Property(x => x.F63040011).HasPrecision(18, 3);
            Property(x => x.F63040012).HasPrecision(18, 3);
            Property(x => x.F63040013).HasPrecision(18, 3);
            Property(x => x.F63040014).HasPrecision(18, 3);
            Property(x => x.F63040015).HasPrecision(18, 3);
            Property(x => x.F63040016).HasPrecision(18, 3);
            Property(x => x.F63040017).HasPrecision(18, 3);
            Property(x => x.F63040018).HasPrecision(18, 3);
            Property(x => x.F63040019).HasPrecision(18, 3);
            Property(x => x.F63040020).HasPrecision(18, 3);
            Property(x => x.F63040021).HasPrecision(18, 3);
            Property(x => x.F63040022).HasPrecision(18, 3);
            Property(x => x.F63040023).HasPrecision(18, 3);
            Property(x => x.F63040024).HasPrecision(18, 3);
            Property(x => x.F63040025).HasPrecision(18, 3);
            Property(x => x.F63040026).HasPrecision(18, 3);

            Property(x => x.F63041001).HasPrecision(18, 3);
            Property(x => x.F63041002).HasPrecision(18, 3);
            Property(x => x.F63041003).HasPrecision(18, 3);
            Property(x => x.F63041004).HasPrecision(18, 3);
            Property(x => x.F63041005).HasPrecision(18, 3);
            Property(x => x.F63041006).HasPrecision(18, 3);
            Property(x => x.F63041007).HasPrecision(18, 3);
            Property(x => x.F63041008).HasPrecision(18, 3);
            Property(x => x.F63041009).HasPrecision(18, 3);
            Property(x => x.F63041010).HasPrecision(18, 3);
            Property(x => x.F63041011).HasPrecision(18, 3);
            Property(x => x.F63041012).HasPrecision(18, 3);
            Property(x => x.F63041013).HasPrecision(18, 3);
            Property(x => x.F63041014).HasPrecision(18, 3);
            Property(x => x.F63041015).HasPrecision(18, 3);
            Property(x => x.F63041016).HasPrecision(18, 3);
            Property(x => x.F63041017).HasPrecision(18, 3);
            Property(x => x.F63041018).HasPrecision(18, 3);
            Property(x => x.F63041019).HasPrecision(18, 3);
            Property(x => x.F63041020).HasPrecision(18, 3);
            Property(x => x.F63041021).HasPrecision(18, 3);
            Property(x => x.F63041022).HasPrecision(18, 3);
            Property(x => x.F63041023).HasPrecision(18, 3);
            Property(x => x.F63041024).HasPrecision(18, 3);
            Property(x => x.F63041025).HasPrecision(18, 3);
            Property(x => x.F63041026).HasPrecision(18, 3);


        }
    }
}
