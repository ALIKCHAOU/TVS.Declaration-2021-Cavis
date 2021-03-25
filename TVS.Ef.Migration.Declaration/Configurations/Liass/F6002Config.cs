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
    class F6002Config : EntityTypeConfiguration<TF6002>
    {
        public F6002Config()
        {
            HasRequired(x => x.Societe)
                .WithMany(x => x.F6002)
                .HasForeignKey(x => x.SocieteNo)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Exercice)
                .WithMany(x => x.F6002)
                .HasForeignKey(x => x.ExerciceId)
                .WillCascadeOnDelete(false);

            
            Property(x => x.NatureDepot).HasMaxLength(1).HasColumnType("nvarchar");
            Property(x => x.F60020001).HasPrecision(18, 3);
            Property(x => x.F60020002).HasPrecision(18, 3);
            Property(x => x.F60020003).HasPrecision(18, 3);
            Property(x => x.F60020004).HasPrecision(18, 3);
            Property(x => x.F60020005).HasPrecision(18, 3);
            Property(x => x.F60020006).HasPrecision(18, 3);
            Property(x => x.F60020007).HasPrecision(18, 3);
            Property(x => x.F60020008).HasPrecision(18, 3);
            Property(x => x.F60020009).HasPrecision(18, 3);
            Property(x => x.F60020010).HasPrecision(18, 3);
            Property(x => x.F60020011).HasPrecision(18, 3);
            Property(x => x.F60020012).HasPrecision(18, 3);
            Property(x => x.F60020013).HasPrecision(18, 3);
            Property(x => x.F60020014).HasPrecision(18, 3);
            Property(x => x.F60020015).HasPrecision(18, 3);
            Property(x => x.F60020016).HasPrecision(18, 3);
            Property(x => x.F60020017).HasPrecision(18, 3);
            Property(x => x.F60020018).HasPrecision(18, 3);
            Property(x => x.F60020019).HasPrecision(18, 3);
            Property(x => x.F60020020).HasPrecision(18, 3);
            Property(x => x.F60020021).HasPrecision(18, 3);
            Property(x => x.F60020022).HasPrecision(18, 3);
            Property(x => x.F60020023).HasPrecision(18, 3);
            Property(x => x.F60020024).HasPrecision(18, 3);
            Property(x => x.F60020025).HasPrecision(18, 3);
            Property(x => x.F60020026).HasPrecision(18, 3);
            Property(x => x.F60020027).HasPrecision(18, 3);
            Property(x => x.F60020028).HasPrecision(18, 3);
            Property(x => x.F60020029).HasPrecision(18, 3);
            Property(x => x.F60020030).HasPrecision(18, 3);
            Property(x => x.F60020031).HasPrecision(18, 3);
            Property(x => x.F60020032).HasPrecision(18, 3);
            Property(x => x.F60020033).HasPrecision(18, 3);
            Property(x => x.F60020034).HasPrecision(18, 3);
            Property(x => x.F60020035).HasPrecision(18, 3);
            Property(x => x.F60020036).HasPrecision(18, 3);
            Property(x => x.F60020037).HasPrecision(18, 3);
            Property(x => x.F60020038).HasPrecision(18, 3);
            Property(x => x.F60020039).HasPrecision(18, 3);
            Property(x => x.F60020040).HasPrecision(18, 3);
            Property(x => x.F60020041).HasPrecision(18, 3);
            Property(x => x.F60020042).HasPrecision(18, 3);
            Property(x => x.F60020043).HasPrecision(18, 3);
            Property(x => x.F60020044).HasPrecision(18, 3);
            Property(x => x.F60020045).HasPrecision(18, 3);
            Property(x => x.F60020046).HasPrecision(18, 3);
            Property(x => x.F60020047).HasPrecision(18, 3);
            Property(x => x.F60020048).HasPrecision(18, 3);
            Property(x => x.F60020049).HasPrecision(18, 3);
            Property(x => x.F60020050).HasPrecision(18, 3);
            Property(x => x.F60020051).HasPrecision(18, 3);
            Property(x => x.F60020052).HasPrecision(18, 3);
            Property(x => x.F60020053).HasPrecision(18, 3);
            Property(x => x.F60020054).HasPrecision(18, 3);
            Property(x => x.F60020055).HasPrecision(18, 3);
            Property(x => x.F60020056).HasPrecision(18, 3);
            Property(x => x.F60020057).HasPrecision(18, 3);
            Property(x => x.F60020058).HasPrecision(18, 3);
            Property(x => x.F60020059).HasPrecision(18, 3);
            Property(x => x.F60020060).HasPrecision(18, 3);
            Property(x => x.F60020061).HasPrecision(18, 3);
            Property(x => x.F60020062).HasPrecision(18, 3);
            Property(x => x.F60020063).HasPrecision(18, 3);
            Property(x => x.F60020064).HasPrecision(18, 3);
            Property(x => x.F60020065).HasPrecision(18, 3);
            Property(x => x.F60020066).HasPrecision(18, 3);
            Property(x => x.F60020067).HasPrecision(18, 3);
            Property(x => x.F60020068).HasPrecision(18, 3);
            Property(x => x.F60020069).HasPrecision(18, 3);
            Property(x => x.F60020070).HasPrecision(18, 3);
            Property(x => x.F60020071).HasPrecision(18, 3);
            Property(x => x.F60020072).HasPrecision(18, 3);
            Property(x => x.F60020073).HasPrecision(18, 3);
            Property(x => x.F60020074).HasPrecision(18, 3);
            Property(x => x.F60020075).HasPrecision(18, 3);
            Property(x => x.F60020076).HasPrecision(18, 3);
            Property(x => x.F60020077).HasPrecision(18, 3);
            Property(x => x.F60020078).HasPrecision(18, 3);
            Property(x => x.F60020079).HasPrecision(18, 3);
            Property(x => x.F60020080).HasPrecision(18, 3);
            Property(x => x.F60020081).HasPrecision(18, 3);
            Property(x => x.F60020082).HasPrecision(18, 3);
            Property(x => x.F60020083).HasPrecision(18, 3);
            Property(x => x.F60020084).HasPrecision(18, 3);
            Property(x => x.F60020085).HasPrecision(18, 3);
            Property(x => x.F60020086).HasPrecision(18, 3);
            Property(x => x.F60020087).HasPrecision(18, 3);
            Property(x => x.F60020088).HasPrecision(18, 3);
            Property(x => x.F60020089).HasPrecision(18, 3);
            Property(x => x.F60020090).HasPrecision(18, 3);
            Property(x => x.F60020091).HasPrecision(18, 3);
            Property(x => x.F60020092).HasPrecision(18, 3);
            Property(x => x.F60020093).HasPrecision(18, 3);
            Property(x => x.F60020094).HasPrecision(18, 3);
            Property(x => x.F60020095).HasPrecision(18, 3);
            Property(x => x.F60020096).HasPrecision(18, 3);
            Property(x => x.F60020097).HasPrecision(18, 3);
            Property(x => x.F60020098).HasPrecision(18, 3);
            Property(x => x.F60020099).HasPrecision(18, 3);
            Property(x => x.F60020100).HasPrecision(18, 3);
            Property(x => x.F60020101).HasPrecision(18, 3);
            Property(x => x.F60020102).HasPrecision(18, 3);
            Property(x => x.F60020103).HasPrecision(18, 3);
            Property(x => x.F60020104).HasPrecision(18, 3);
            Property(x => x.F60020105).HasPrecision(18, 3);
            Property(x => x.F60020106).HasPrecision(18, 3);

        }
    }
}