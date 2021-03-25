using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Ef.Migration.Declaration.Configurations;
using TVS.Ef.Migration.Declaration.Configurations.Dec2016;
using TVS.Ef.Migration.Declaration.Configurations.Liass;
using TVS.Ef.Migration.Declaration.Models;
using TVS.Ef.Migration.Declaration.Models.Dec2016;
using TVS.Ef.Migration.Declaration.Models.Liass;

namespace TVS.Ef.Migration.Declaration
{
    public class DeclarationContext : DbContext
    {
        public DbSet<TSociete> Societes { get; set; }
        public DbSet<TExercice> Exercices { get; set; }
        public DbSet<T2016Annexe1> T2016Annexe1 { get; set; }
        public DbSet<T2016Annexe2> T2016Annexe2 { get; set; }
        public DbSet<T2016Annexe3> T2016Annexe3 { get; set; }
        public DbSet<T2016Annexe4> T2016Annexe4 { get; set; }
        public DbSet<T2016Annexe5> T2016Annexe5 { get; set; }
        public DbSet<T2016Annexe6> T2016Annexe6 { get; set; }
        public DbSet<T2016Annexe7> T2016Annexe7 { get; set; }
        public DbSet<TCategorieCnss> CategorieCnsses { get; set; }
        public DbSet<TDeclarationFactureSuspenssion> DeclarationFactureSuspenssions { get; set; }
        public DbSet<TDeclarationCnss> DeclarationCnsses { get; set; }
        public DbSet<TDeclarationBcSuspenssion> DeclarationBcSuspenssions { get; set; }
        public DbSet<TLigneBc> LigneBc { get; set; }
        public DbSet<TLigneCnss> LigneCnsses { get; set; }
        public DbSet<TLigneFacture> LigneFactures { get; set; }
        public DbSet<TEmployee> Employees { get; set; }
        public DbSet<TUser> User { get; set; }
        public DbSet<TVirementLigne> VirementLignes { get; set; }
        public DbSet<TVirementEntete> VirementEntet { get; set; }
        public DbSet<TSocieteBanque> SocieteBanque { get; set; }

        public DbSet<TF6001> F6001 { get; set; }
        public DbSet<TF6002> F6002 { get; set; }
        public DbSet<TF6003> F6003 { get; set; }
        public DbSet<TF6004> F6004 { get; set; }
        public DbSet<TF6005> F6005 { get; set; }
        public DbSet<TUtilisateurSociete> UtilisateurSociete { get; set; }

        public DbSet<TF6301> F6301 { get; set; }
        public DbSet<TF6303> F6303 { get; set; }
        public DbSet<TF6304> F6304 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SocieteConfig());
            modelBuilder.Configurations.Add(new T2016Annexe1Config());
            modelBuilder.Configurations.Add(new T2016Annexe2Config());
            modelBuilder.Configurations.Add(new T2016Annexe3Config());
            modelBuilder.Configurations.Add(new T2016Annexe4Config());
            modelBuilder.Configurations.Add(new T2016Annexe5Config());
            modelBuilder.Configurations.Add(new T2016Annexe6Config());
            modelBuilder.Configurations.Add(new T2016Annexe7Config());
            modelBuilder.Configurations.Add(new LigneBcConfig());
            modelBuilder.Configurations.Add(new LigneCnssConfig());
            modelBuilder.Configurations.Add(new LigneFcConfig());
            modelBuilder.Configurations.Add(new DeclarationBcConfig());
            modelBuilder.Configurations.Add(new DeclarationFcConfig());
            modelBuilder.Configurations.Add(new DeclarationCnssConfig());
            modelBuilder.Configurations.Add(new EmployeeConfig());
            modelBuilder.Configurations.Add(new CategorieCnssConfig());
            modelBuilder.Configurations.Add(new VirementEnteteConfig());
            modelBuilder.Configurations.Add(new VirementLigneConfig());
            modelBuilder.Configurations.Add(new F6001Config());
            modelBuilder.Configurations.Add(new F6002Config());
            modelBuilder.Configurations.Add(new F6003Config());
            modelBuilder.Configurations.Add(new F6004Config());
            modelBuilder.Configurations.Add(new F6004ModeleAutorsieConfig());
            modelBuilder.Configurations.Add(new F6005Config());

            modelBuilder.Configurations.Add(new F6301Config());
            modelBuilder.Configurations.Add(new F6303Config());
            modelBuilder.Configurations.Add(new F6304Config());



        }
    }
}