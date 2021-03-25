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
    class F6003Config : EntityTypeConfiguration<TF6003>
    {
        public F6003Config()
        {
            HasRequired(x => x.Societe)
                .WithMany(x => x.F6003)
                .HasForeignKey(x => x.SocieteNo)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Exercice)
                .WithMany(x => x.F6003)
                .HasForeignKey(x => x.ExerciceId)
                .WillCascadeOnDelete(false);




            Property(x => x.NatureDepot).HasMaxLength(1).HasColumnType("nvarchar");
            Property(x => x.F60030001).HasPrecision(18, 3);
            Property(x => x.F60030002).HasPrecision(18, 3);
            Property(x => x.F60030003).HasPrecision(18, 3);
            Property(x => x.F60030004).HasPrecision(18, 3);
            Property(x => x.F60030005).HasPrecision(18, 3);
            Property(x => x.F60030006).HasPrecision(18, 3);
            Property(x => x.F60030007).HasPrecision(18, 3);
            Property(x => x.F60030008).HasPrecision(18, 3);
            Property(x => x.F60030009).HasPrecision(18, 3);
            Property(x => x.F60030010).HasPrecision(18, 3);
            Property(x => x.F60030011).HasPrecision(18, 3);
            Property(x => x.F60030012).HasPrecision(18, 3);
            Property(x => x.F60030013).HasPrecision(18, 3);
            Property(x => x.F60030014).HasPrecision(18, 3);
            Property(x => x.F60030015).HasPrecision(18, 3);
            Property(x => x.F60030016).HasPrecision(18, 3);
            Property(x => x.F60030017).HasPrecision(18, 3);
            Property(x => x.F60030018).HasPrecision(18, 3);
            Property(x => x.F60030019).HasPrecision(18, 3);
            Property(x => x.F60030020).HasPrecision(18, 3);
            Property(x => x.F60030021).HasPrecision(18, 3);
            Property(x => x.F60030022).HasPrecision(18, 3);
            Property(x => x.F60030023).HasPrecision(18, 3);
            Property(x => x.F60030024).HasPrecision(18, 3);
            Property(x => x.F60030025).HasPrecision(18, 3);
            Property(x => x.F60030026).HasPrecision(18, 3);
            Property(x => x.F60030027).HasPrecision(18, 3);
            Property(x => x.F60030028).HasPrecision(18, 3);
            Property(x => x.F60030029).HasPrecision(18, 3);
            Property(x => x.F60030030).HasPrecision(18, 3);
            Property(x => x.F60030031).HasPrecision(18, 3);
            Property(x => x.F60030032).HasPrecision(18, 3);
            Property(x => x.F60030033).HasPrecision(18, 3);
            Property(x => x.F60030034).HasPrecision(18, 3);
            Property(x => x.F60030035).HasPrecision(18, 3);
            Property(x => x.F60030036).HasPrecision(18, 3);
            Property(x => x.F60030037).HasPrecision(18, 3);
            Property(x => x.F60030038).HasPrecision(18, 3);
            Property(x => x.F60030039).HasPrecision(18, 3);
            Property(x => x.F60030040).HasPrecision(18, 3);
            Property(x => x.F60030041).HasPrecision(18, 3);
            Property(x => x.F60030042).HasPrecision(18, 3);
            Property(x => x.F60030043).HasPrecision(18, 3);
            Property(x => x.F60030044).HasPrecision(18, 3);
            Property(x => x.F60030045).HasPrecision(18, 3);
            Property(x => x.F60030046).HasPrecision(18, 3);
            Property(x => x.F60030047).HasPrecision(18, 3);
            Property(x => x.F60030048).HasPrecision(18, 3);
            Property(x => x.F60030049).HasPrecision(18, 3);
            Property(x => x.F60030050).HasPrecision(18, 3);
            Property(x => x.F60030051).HasPrecision(18, 3);
            Property(x => x.F60030052).HasPrecision(18, 3);
            Property(x => x.F60030053).HasPrecision(18, 3);
            Property(x => x.F60030054).HasPrecision(18, 3);
            Property(x => x.F60030055).HasPrecision(18, 3);
            Property(x => x.F60030056).HasPrecision(18, 3);
            Property(x => x.F60030057).HasPrecision(18, 3);
            Property(x => x.F60030058).HasPrecision(18, 3);
            Property(x => x.F60030059).HasPrecision(18, 3);
            Property(x => x.F60030060).HasPrecision(18, 3);
            Property(x => x.F60030061).HasPrecision(18, 3);
            Property(x => x.F60030062).HasPrecision(18, 3);
            Property(x => x.F60030063).HasPrecision(18, 3);
            Property(x => x.F60030064).HasPrecision(18, 3);
            Property(x => x.F60030065).HasPrecision(18, 3);
            Property(x => x.F60030066).HasPrecision(18, 3);
            Property(x => x.F60030067).HasPrecision(18, 3);
            Property(x => x.F60030068).HasPrecision(18, 3);
            Property(x => x.F60030069).HasPrecision(18, 3);
            Property(x => x.F60030070).HasPrecision(18, 3);
            Property(x => x.F60030071).HasPrecision(18, 3);
            Property(x => x.F60030072).HasPrecision(18, 3);
            Property(x => x.F60030073).HasPrecision(18, 3);
            Property(x => x.F60030074).HasPrecision(18, 3);
            Property(x => x.F60030075).HasPrecision(18, 3);
            Property(x => x.F60030076).HasPrecision(18, 3);
            Property(x => x.F60030077).HasPrecision(18, 3);
            Property(x => x.F60030078).HasPrecision(18, 3);
            Property(x => x.F60030079).HasPrecision(18, 3);
            Property(x => x.F60030080).HasPrecision(18, 3);
            Property(x => x.F60030081).HasPrecision(18, 3);
            Property(x => x.F60030082).HasPrecision(18, 3);
            Property(x => x.F60030083).HasPrecision(18, 3);
            Property(x => x.F60030084).HasPrecision(18, 3);
            Property(x => x.F60030085).HasPrecision(18, 3);
            Property(x => x.F60030086).HasPrecision(18, 3);
            Property(x => x.F60030087).HasPrecision(18, 3);
            Property(x => x.F60030088).HasPrecision(18, 3);
            Property(x => x.F60030089).HasPrecision(18, 3);
            Property(x => x.F60030090).HasPrecision(18, 3);
            Property(x => x.F60030091).HasPrecision(18, 3);
            Property(x => x.F60030092).HasPrecision(18, 3);
            Property(x => x.F60030093).HasPrecision(18, 3);
            Property(x => x.F60030094).HasPrecision(18, 3);
            Property(x => x.F60030095).HasPrecision(18, 3);
            Property(x => x.F60030096).HasPrecision(18, 3);
            Property(x => x.F60030097).HasPrecision(18, 3);
            Property(x => x.F60030098).HasPrecision(18, 3);
            Property(x => x.F60030099).HasPrecision(18, 3);
            Property(x => x.F60030100).HasPrecision(18, 3);
            Property(x => x.F60030101).HasPrecision(18, 3);
            Property(x => x.F60030102).HasPrecision(18, 3);
            Property(x => x.F60030103).HasPrecision(18, 3);
            Property(x => x.F60030104).HasPrecision(18, 3);
            Property(x => x.F60030105).HasPrecision(18, 3);
            Property(x => x.F60030106).HasPrecision(18, 3);
            Property(x => x.F60030107).HasPrecision(18, 3);
            Property(x => x.F60030108).HasPrecision(18, 3);
            Property(x => x.F60030109).HasPrecision(18, 3);
            Property(x => x.F60030110).HasPrecision(18, 3);
            Property(x => x.F60030111).HasPrecision(18, 3);
            Property(x => x.F60030112).HasPrecision(18, 3);
            Property(x => x.F60030113).HasPrecision(18, 3);
            Property(x => x.F60030114).HasPrecision(18, 3);
            Property(x => x.F60030115).HasPrecision(18, 3);
            Property(x => x.F60030116).HasPrecision(18, 3);
            Property(x => x.F60030117).HasPrecision(18, 3);
            Property(x => x.F60030118).HasPrecision(18, 3);
            Property(x => x.F60030119).HasPrecision(18, 3);
            Property(x => x.F60030120).HasPrecision(18, 3);
            Property(x => x.F60030121).HasPrecision(18, 3);
            Property(x => x.F60030122).HasPrecision(18, 3);
            Property(x => x.F60030123).HasPrecision(18, 3);
            Property(x => x.F60030124).HasPrecision(18, 3);
            Property(x => x.F60030125).HasPrecision(18, 3);
            Property(x => x.F60030126).HasPrecision(18, 3);
            Property(x => x.F60030127).HasPrecision(18, 3);
            Property(x => x.F60030128).HasPrecision(18, 3);
            Property(x => x.F60030129).HasPrecision(18, 3);
            Property(x => x.F60030130).HasPrecision(18, 3);
            Property(x => x.F60030131).HasPrecision(18, 3);
            Property(x => x.F60030132).HasPrecision(18, 3);
            Property(x => x.F60030133).HasPrecision(18, 3);
            Property(x => x.F60030134).HasPrecision(18, 3);
            Property(x => x.F60030135).HasPrecision(18, 3);
            Property(x => x.F60030136).HasPrecision(18, 3);
            Property(x => x.F60030137).HasPrecision(18, 3);
            Property(x => x.F60030138).HasPrecision(18, 3);
            Property(x => x.F60030139).HasPrecision(18, 3);
            Property(x => x.F60030140).HasPrecision(18, 3);
            Property(x => x.F60030141).HasPrecision(18, 3);
            Property(x => x.F60030142).HasPrecision(18, 3);
            Property(x => x.F60030143).HasPrecision(18, 3);
            Property(x => x.F60030144).HasPrecision(18, 3);
            Property(x => x.F60030145).HasPrecision(18, 3);
            Property(x => x.F60030146).HasPrecision(18, 3);
            Property(x => x.F60030147).HasPrecision(18, 3);
            Property(x => x.F60030148).HasPrecision(18, 3);
            Property(x => x.F60030149).HasPrecision(18, 3);
            Property(x => x.F60030150).HasPrecision(18, 3);
            Property(x => x.F60030151).HasPrecision(18, 3);
            Property(x => x.F60030152).HasPrecision(18, 3);
            Property(x => x.F60030153).HasPrecision(18, 3);
            Property(x => x.F60030154).HasPrecision(18, 3);
            Property(x => x.F60030155).HasPrecision(18, 3);
            Property(x => x.F60030156).HasPrecision(18, 3);
            Property(x => x.F60030157).HasPrecision(18, 3);
            Property(x => x.F60030158).HasPrecision(18, 3);
            Property(x => x.F60030159).HasPrecision(18, 3);
            Property(x => x.F60030160).HasPrecision(18, 3);
            Property(x => x.F60030161).HasPrecision(18, 3);
            Property(x => x.F60030162).HasPrecision(18, 3);
            Property(x => x.F60030163).HasPrecision(18, 3);
            Property(x => x.F60030164).HasPrecision(18, 3);
            Property(x => x.F60030165).HasPrecision(18, 3);
            Property(x => x.F60030166).HasPrecision(18, 3);
            Property(x => x.F60030167).HasPrecision(18, 3);
            Property(x => x.F60030168).HasPrecision(18, 3);
            Property(x => x.F60030169).HasPrecision(18, 3);
            Property(x => x.F60030170).HasPrecision(18, 3);
            Property(x => x.F60030171).HasPrecision(18, 3);
            Property(x => x.F60030172).HasPrecision(18, 3);
            Property(x => x.F60030173).HasPrecision(18, 3);
            Property(x => x.F60030174).HasPrecision(18, 3);
            Property(x => x.F60030175).HasPrecision(18, 3);
            Property(x => x.F60030176).HasPrecision(18, 3);
            Property(x => x.F60030177).HasPrecision(18, 3);
            Property(x => x.F60030178).HasPrecision(18, 3);

        }
    }
}