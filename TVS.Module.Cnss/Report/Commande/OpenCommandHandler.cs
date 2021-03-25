using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using TVS.Module.Cnss.Report.Datasets;

namespace TVS.Module.Cnss.Report.Command
{
    public class OpenCommandHandler : ICommandHandler
    {
        private readonly XRDesignMdiController _xrDesigner;

        private const string COpenDialogFileExtensionFilter = "(*.repx)|*.repx";
        private const string COpenDialogFileFormTitle = "Ouvrir";
        private const string Cextension = "repx";
        private const string DataAdapterName = "DataAdapter1";
        private const string NameProperty = "Name";
        public OpenCommandHandler(XRDesignMdiController xrDesigner, CompositionContainer container)
        {
            if (xrDesigner == null)
                throw new ArgumentNullException("xrDesigner");

            if (container == null)
                throw new ArgumentNullException("container");

            _xrDesigner = xrDesigner;
            container.ComposeParts(this);
        }

        public bool CanHandleCommand(ReportCommand command, ref bool useNextHandler)
        {
            useNextHandler = command != ReportCommand.OpenFile;
            return !useNextHandler;
        }

        public void HandleCommand(ReportCommand command, object[] args)
        {
            // open file dialogue
            var dialog = new OpenFileDialog
            {
                Title = COpenDialogFileFormTitle,
                DefaultExt = Cextension,
                Filter = COpenDialogFileExtensionFilter,
                InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "AMEN CONSEIL\\Declaration\\Etats")
            };

            if (dialog.ShowDialog() != DialogResult.OK) return;
            if (string.IsNullOrEmpty(dialog.FileName)) return;
            if (!File.Exists(dialog.FileName)) return;

            // initialize the report file (XtraReport)
            var xreport = XtraReport.FromFile(dialog.FileName, true);
            xreport.SourceUrl = dialog.FileName;
            var reportTypeName = xreport.Tag.ToString();

            // load the report initializer (ITresorerieReport)


                // set report data properties
                var source = new DsAttestation();
                // set data adapter if the report is type of `ITresorerieReportView`
              
                xreport.DataSource = source;
                xreport.DataMember = "LigneCNSS";
   
            // open the report
            _xrDesigner.OpenReport(xreport);

            // set report designer properties [DataAdapter/Dataset]
            foreach (var comp in xreport.Container.Components.OfType<SqlDataAdapter>())
            {
                xreport.Container.Remove(comp);
            }
            var pd = TypeDescriptor.GetProperties(xreport.DataSource)[NameProperty];
            pd.SetValue(xreport.DataSource, ((DataSet)xreport.DataSource).DataSetName);

            foreach (var comp in xreport.Container.Components.OfType<SqlDataAdapter>())
            {
                pd = TypeDescriptor.GetProperties(comp)[NameProperty];
                pd.SetValue(comp, DataAdapterName);
            }
        }
    }
}