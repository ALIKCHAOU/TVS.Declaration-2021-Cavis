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
    class F6301Config : EntityTypeConfiguration<TF6301>
    {
        public F6301Config()
        {
            HasRequired(x => x.Societe)
                .WithMany(x => x.F6301)
                .HasForeignKey(x => x.SocieteNo)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Exercice)
                .WithMany(x => x.F6301)
                .HasForeignKey(x => x.ExerciceId)
                .WillCascadeOnDelete(false);


            Property(x => x.NatureDepot).HasMaxLength(1).HasColumnType("nvarchar");
            Property(x => x.F63010001).HasPrecision(18, 3);
            Property(x => x.F63010002).HasPrecision(18, 3);
            Property(x => x.F63010003).HasPrecision(18, 3);
            Property(x => x.F63010004).HasPrecision(18, 3);
            Property(x => x.F63010005).HasPrecision(18, 3);
            Property(x => x.F63010006).HasPrecision(18, 3);
            Property(x => x.F63010007).HasPrecision(18, 3);
            Property(x => x.F63010008).HasPrecision(18, 3);
            Property(x => x.F63010009).HasPrecision(18, 3);
            Property(x => x.F63010010).HasPrecision(18, 3);
            Property(x => x.F63010011).HasPrecision(18, 3);
            Property(x => x.F63010012).HasPrecision(18, 3);
            Property(x => x.F63010013).HasPrecision(18, 3);
            Property(x => x.F63010014).HasPrecision(18, 3);
            Property(x => x.F63010015).HasPrecision(18, 3);
            Property(x => x.F63010016).HasPrecision(18, 3);
            Property(x => x.F63010017).HasPrecision(18, 3);
            Property(x => x.F63010018).HasPrecision(18, 3);
            Property(x => x.F63010019).HasPrecision(18, 3);

            Property(x => x.F63011001).HasPrecision(18, 3);
            Property(x => x.F63011002).HasPrecision(18, 3);
            Property(x => x.F63011003).HasPrecision(18, 3);
            Property(x => x.F63011004).HasPrecision(18, 3);
            Property(x => x.F63011005).HasPrecision(18, 3);
            Property(x => x.F63011006).HasPrecision(18, 3);
            Property(x => x.F63011007).HasPrecision(18, 3);
            Property(x => x.F63011008).HasPrecision(18, 3);
            Property(x => x.F63011009).HasPrecision(18, 3);
            Property(x => x.F63011010).HasPrecision(18, 3);
            Property(x => x.F63011011).HasPrecision(18, 3);
            Property(x => x.F63011012).HasPrecision(18, 3);
            Property(x => x.F63011013).HasPrecision(18, 3);
            Property(x => x.F63011014).HasPrecision(18, 3);
            Property(x => x.F63011015).HasPrecision(18, 3);
            Property(x => x.F63011016).HasPrecision(18, 3);
            Property(x => x.F63011017).HasPrecision(18, 3);
            Property(x => x.F63011018).HasPrecision(18, 3);
            Property(x => x.F63011019).HasPrecision(18, 3);







        }
    }
}
