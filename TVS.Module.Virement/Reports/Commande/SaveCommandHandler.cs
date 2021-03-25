using System;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraReports.UserDesigner;

namespace TVS.Module.Virement
{
    public class SaveCommandHandler : ICommandHandler
    {
        private readonly XRDesignPanel _panel;
        private const string Cfilter = "(*.repx)|*.repx";
        private const string Ctitle = "Enregistrer";
        private const string Cext = "repx";

        public SaveCommandHandler(XRDesignPanel panel)
        {
            if (panel == null) throw new ArgumentNullException("panel");
            _panel = panel;
        }

        public void HandleCommand(ReportCommand command, object[] args)
        {
            if (_panel.ReportState == ReportState.Saved) return;
            var report = _panel.Report;
            // save the report changes
            if ((command == ReportCommand.Closing ||
                command == ReportCommand.SaveFile) && File.Exists(report.SourceUrl))
            {
                Save(report.SourceUrl);
                return;
            }
            // save a new report
            var dialog = new SaveFileDialog
            {
                Title = Ctitle,
                DefaultExt = Cext,
                FileName = report.DisplayName,
                Filter = Cfilter
            };

            if (dialog.ShowDialog() != DialogResult.OK) return;
            if (string.IsNullOrEmpty(dialog.FileName)) return;
            Save(dialog.FileName);
        }

        public bool CanHandleCommand(ReportCommand command, ref bool useNextHandler)
        {
            useNextHandler = !(command == ReportCommand.SaveFile ||
                command == ReportCommand.SaveFileAs ||
                command == ReportCommand.Closing);
            return !useNextHandler;
        }

        private void Save(string path)
        {
            _panel.Report.SaveLayoutToXml(path);
            _panel.ReportState = ReportState.Saved;
            _panel.Report.SourceUrl = path;
        }
    }
}