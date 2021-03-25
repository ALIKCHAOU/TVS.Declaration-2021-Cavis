using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using TVS.Ef.Migration.Declaration.Models;

namespace TVS.Ef.Migration.Declaration
{
    internal sealed class CustomDatabaseInitializer : IDatabaseInitializer<DeclarationContext>
    {
        public void InitializeDatabase(DeclarationContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            // check if the database exists
            if (context.Database.Exists())
            {
                // intitialize database migrator
                var migrator = new DbMigrator(new DeclarationDbMigrationConfiguration());
                // load pending migrations
                List<string> migrations = migrator.GetPendingMigrations().ToList();
                // check if the database is compatible with the model
                bool compatible = context.Database.CompatibleWithModel(true);

                // if the database exists and does not matche the model
                // but we don't have any migration to apply then throw an exception
                if (!compatible && !migrations.Any())
                    throw new InvalidOperationException("Database is not compatible with the Model!");

                // if the database exists and matches the model
                // and we don't have any migrations to apply, leaaaaaaaaaaaaave go away =)
                if (compatible && !migrations.Any())
                {
                    Console.WriteLine("Database matches the model.");
                    return;
                }

                // the database does not matche the model
                // or we got some migrations to apply
                Console.WriteLine("Migrations to apply: {0}", migrations.Count());
                migrator.Update();
                Console.WriteLine("Database migrated.");
                return;
            }
            // database does not exist
            try
            {
                context.Database.CreateIfNotExists();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            Console.WriteLine("Database created.");
            // intialize database
            Seed(context);
        }

        private void Seed(DeclarationContext context)
        {
            InitializeExercice(context);
            InitializeSociete(context);
        }

        private void InitializeExercice(DeclarationContext context)
        {
            var exercice = new TExercice
            {
                Annee = "2016",
                IsArchive = false,
                IsCloturer = false,
            };
            try
            {
                context.Exercices.Add(exercice);
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var newException = new FormattedDbEntityValidationException(e);
                throw newException;
            }
        }

        private void InitializeSociete(DeclarationContext context)
        {
            var societe = new TSociete
            {
                Adresse = string.Empty,
                CodeBureau = "00",
                CodePostal = "3000",
                CurrentExerciceNo = 1,
                MatriculFiscal = "00000000",
                NumeroEmployeur = "12345678",
                CleEmployeur = "00",
                RaisonSocial = "TVS",
                Pays = "Tunisie",
                Ville = "Tunis",
                Activite = "Activité",
                MatriculCategorie = "M",
                MatriculCle = "C",
                MatriculEtablissement = "000",
                MatriculCodeTva = "E",
                //RibSociete = string.Empty
            };
            try
            {
                context.Societes.Add(societe);
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var newException = new FormattedDbEntityValidationException(e);
                throw newException;
            }
        }
    }
}