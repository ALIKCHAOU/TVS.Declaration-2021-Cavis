using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using System;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Globalization;
using TVS.Config;
using TVS.Config.Modules;
using TVS.Ef.Migration.Declaration;
using TVS.Core;
using TVS.Declaration.Settings;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;
using Rhino.Licensing;
using TVS.Declaration.Modules;


namespace TVS.Declaration
{
    static class Program
    {
        public static IKernel Kernel
        {
            get { return ConfigProgram.Kernel; }
            set { ConfigProgram.Kernel = value; }
        }

        public static bool IsMultiSociete { get; private set; }
        public static bool IsDecBc { get; private set; }
        public static bool IsDecFc { get; private set; }
        public static bool IsVirement { get; private set; }
        public static bool IsCovis { get; private set; }
        public static bool IsCnss { get; private set; }
        public static bool IsEmp { get; private set; }
        public static bool IsLiasse { get; private set; }
        public static string Societe { get; private set; }
        public static CommandContext Context { get; private set; }

        public static DateTime DateExpiration { get; private set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //Dossier Application data
            var dossierName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                Application.ProductName);
            if (!Directory.Exists(dossierName)) Directory.CreateDirectory(dossierName);

            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("fr-FR");
            // Add the event handler for handling UI thread exceptions to the event.
            Application.ThreadException += ThreadException;
            // Set the unhandled exception mode to force all Windows Forms errors to go through our handler.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            // Add the event handler for handling non-UI thread exceptions to the event.
            AppDomain.CurrentDomain.UnhandledException += UnhandledException;

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string path = args.Length != 0 ? args[0] : string.Empty;


//#if DEBUG
//            IsMultiSociete = true;
//#else
            // determinition code hardware du pc actuel
            var codePc = GeneratorCode.Value();

            // verification de la license
            try
            {
                var publicKey = File.ReadAllText("publicKey.xml");
                var validator = new LicenseValidator(publicKey, "lic.tvs", false);
                validator.AssertValidLicense();
                if (validator.Name != codePc)
                    throw new ApplicationException("Licence invalide!");
                var attribute = validator.LicenseAttributes;
                IsMultiSociete = attribute["MultiSocite"] == "0";
                IsCnss = attribute["Cnss"] == "0";
                IsDecBc = attribute["BcSuspension"] == "0";
                IsDecFc = attribute["FcSuspension"] == "0";
                IsEmp = attribute["Employeur"] == "0";
                IsVirement = attribute["Virement"] == "0";
                Societe = attribute["Societe"];
                DateExpiration = validator.ExpirationDate;
                IsLiasse = attribute["Liasse"] == "0";
               // IsCovis = attribute["Covis"] == "0";
            }
            catch (LicenseFileNotFoundException e)
            {

                XtraMessageBox.Show("Fichier de licence introuvable");
                new FrmLicenceInvalide().ShowDialog();
                return;
            }
            catch (LicenseExpiredException e)
            {
                XtraMessageBox.Show("Licence expirée");
                new FrmLicenceInvalide().ShowDialog();
                return;
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message);
                new FrmLicenceInvalide().ShowDialog();
                return;
            }
            //#endif


            // init Ninject dependencies resolver
            Kernel = new StandardKernel();
            Kernel.Bind<IUserControlFactory>().ToFactory().InSingletonScope();
            Kernel.Bind<IFormFactory>().ToFactory().InSingletonScope();

            Kernel.Bind<AppConfiguration>()
                .ToSelf()
                .InSingletonScope();
           

            Kernel.Bind<IConfigurationRepository<GroupConfiguration>>()
                .To<GroupConfigurationRepository>()
                .InSingletonScope();

            // check configs (connection ...)
            // get configs / connection to `Groupe`
            // should return a valid connection
            var appConfig = Kernel.Get<AppConfiguration>();
            GroupConfiguration groupeConfig = appConfig.Load(path);

            if (!string.IsNullOrEmpty(path))
            {
                try
                {
                    appConfig.Load(path);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (groupeConfig == null)
            {
                XtraMessageBox.Show("Configuration invalide!");
                // demarrer la fenetre principale
                //var frm = new FrmNouveauFichier(appConfig);
                //frm.ShowDialog();
                return;
            }
            // RebindGroupConnection(groupeConfig);


            Application.SetCompatibleTextRenderingDefault(false);
            var main = Kernel.Get<FrmMain>();
            var service = GetService();
            var frmAuthentification = new FrmOuverture(service);
            if (frmAuthentification.ShowDialog() != DialogResult.Yes)
            {
                return;
            }
            Context = new CommandContext
            {
                MainForm = main,
                Container = InitializeContainer(),
                Exercice = service.Exercice,
                Societe = service.Societe,
                User = service.User,
                ConnectionProvider = Kernel.Get<IConnectionProvider>()
            };
         
            // demarrer la fenetre principale
            Application.Run(Context.MainForm);
            //   Application.Run(new XtraForm1());
        }

        private static void ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            XtraMessageBox.Show(e.Exception.Message, "AMEN CONSEIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception;
            if (ex == null)
            {
                MessageBox.Show("Unhandled Exception");
                return;
            }

            XtraMessageBox.Show(ex.Message, "AMENCONSEIL- Unhandled Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void MigrateDataBase()
        {
            var context = Kernel.Get<IGroupContextManager>();
            bool exists = context.DatabaseExists();

            if (!exists)
                context.DatabaseInitialize(); //throw new InvalidOperationException("Opération invalide!");

            bool compatible = context.DatabaseCompatibleWithModel();

            if (!compatible || context.HasPendingMigration())
                context.DatabaseInitialize();
        }

        public static DeclarationService RebindGroupConnection(GroupConfiguration config)
        {
            if (config == null) throw new InvalidOperationException("Configuration invalid!");

            Kernel = new StandardKernel(new DeclarationModuleWin(config), new CoreModule());

            Kernel.Bind<AppConfiguration>()
                .ToSelf()
                .InSingletonScope();

            Kernel.Bind<IConfigurationRepository<GroupConfiguration>>()
                .To<GroupConfigurationRepository>()
                .InSingletonScope();

            // CnssModule.InitModule.Init();

            //Kernel.Bind<IConfigurationRepository<GroupConfiguration>>()
            //             .To<GroupConfigurationXmlRepository>()
            //             .InSingletonScope();
            Kernel.Bind(x => x.FromThisAssembly()
                .SelectAllInterfaces()
                .EndingWith("Factory")
                .BindToFactory()
                .Configure(c => c.InSingletonScope()));
            var connnectionProvider = Kernel.Get<IConnectionProvider>();
            connnectionProvider.ConnectionString = config.GetConnection();
            var groupConfig = Kernel.Get<IGroupContextManager>();
            groupConfig.ChangeGroupConfiguration(config);
            return Kernel.Get<DeclarationService>();
        }

        public static DeclarationService GetService()
        {
            return Kernel.Get<DeclarationService>();
        }

        private static CompositionContainer InitializeContainer()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));
            LoadPlugins("TVS.Module.*", catalog);
            //LoadPlugins("*.Command.dll", catalog);
            //LoadPlugins("*.Command.dll", catalog);
            return new CompositionContainer(catalog);
        }

        private static void LoadPlugins(string searchPattern, AggregateCatalog catalog)
        {
            if (searchPattern == null)
                throw new ArgumentNullException("searchPattern");

            if (catalog == null)
                throw new ArgumentNullException("catalog");

            // don't use DirectoryCatalog, that causes problems if the plugins are from the Internet zone
            // see http://stackoverflow.com/questions/8063841/mef-loading-plugins-from-a-network-shared-folder
            var appPath = Path.GetDirectoryName(typeof(Program).Module.FullyQualifiedName);
            if (appPath == null) return;

            //MessageBox.Show(string.Format("path: {0}", appPath));
            foreach (var plugin in Directory.GetFiles(appPath, searchPattern, SearchOption.TopDirectoryOnly))
            {
                //MessageBox.Show(plugin);
                var shortName = Path.GetFileNameWithoutExtension(plugin);
                if (shortName == null) continue;
                //MessageBox.Show(shortName);
                try
                {
                    var asm = Assembly.LoadFile(plugin);
                    asm.GetTypes();
                    catalog.Catalogs.Add(new AssemblyCatalog(asm));
                }
                catch (Exception ex)
                {
                    // Cannot show MessageBox here, because WPF would crash with a XamlParseException
                    // Remember and show exceptions in text output, once MainWindow is properly initialized
                    // StartupExceptions.Add(new ExceptionData { Exception = ex, PluginName = shortName });
                }
            }
        }
    }
}