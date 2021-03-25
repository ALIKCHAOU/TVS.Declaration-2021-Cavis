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
    class F6303Config : EntityTypeConfiguration<TF6303>
    {
        public F6303Config()
        {
            HasRequired(x => x.Societe)
                .WithMany(x => x.F6303)
                .HasForeignKey(x => x.SocieteNo)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Exercice)
                .WithMany(x => x.F6303)
                .HasForeignKey(x => x.ExerciceId)
                .WillCascadeOnDelete(false);


            Property(x => x.NatureDepot).HasMaxLength(1).HasColumnType("nvarchar");
            Property(x => x.F63030001).HasPrecision(18, 3);
            Property(x => x.F63030002).HasPrecision(18, 3);
            Property(x => x.F63030003).HasPrecision(18, 3);
            Property(x => x.F63030004).HasPrecision(18, 3);
            Property(x => x.F63030005).HasPrecision(18, 3);
            Property(x => x.F63030006).HasPrecision(18, 3);
            Property(x => x.F63030007).HasPrecision(18, 3);
            Property(x => x.F63030008).HasPrecision(18, 3);
            Property(x => x.F63030009).HasPrecision(18, 3);
            Property(x => x.F63030010).HasPrecision(18, 3);
            Property(x => x.F63030011).HasPrecision(18, 3);
            Property(x => x.F63030012).HasPrecision(18, 3);
            Property(x => x.F63030013).HasPrecision(18, 3);
            Property(x => x.F63030014).HasPrecision(18, 3);
            Property(x => x.F63030015).HasPrecision(18, 3);
            Property(x => x.F63030016).HasPrecision(18, 3);
            Property(x => x.F63030017).HasPrecision(18, 3);
            Property(x => x.F63030018).HasPrecision(18, 3);

            Property(x => x.F63031001).HasPrecision(18, 3);
            Property(x => x.F63031002).HasPrecision(18, 3);
            Property(x => x.F63031003).HasPrecision(18, 3);
            Property(x => x.F63031004).HasPrecision(18, 3);
            Property(x => x.F63031005).HasPrecision(18, 3);
            Property(x => x.F63031006).HasPrecision(18, 3);
            Property(x => x.F63031007).HasPrecision(18, 3);
            Property(x => x.F63031008).HasPrecision(18, 3);
            Property(x => x.F63031009).HasPrecision(18, 3);
            Property(x => x.F63031010).HasPrecision(18, 3);
            Property(x => x.F63031011).HasPrecision(18, 3);
            Property(x => x.F63031012).HasPrecision(18, 3);
            Property(x => x.F63031013).HasPrecision(18, 3);
            Property(x => x.F63031014).HasPrecision(18, 3);
            Property(x => x.F63031015).HasPrecision(18, 3);
            Property(x => x.F63031016).HasPrecision(18, 3);
            Property(x => x.F63031017).HasPrecision(18, 3);
            Property(x => x.F63031018).HasPrecision(18, 3);


        }
    }
}
