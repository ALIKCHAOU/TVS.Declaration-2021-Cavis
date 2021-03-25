using DevExpress.XtraWaitForm;
using System;

namespace TVS.Config
{
    public partial class WaitFormDec : WaitForm
    {
        public WaitFormDec()
        {
            InitializeComponent();
            this.progressPanel1.AutoHeight = true;
            this.SetDescription("Traitement en cours...");
            this.SetCaption("Veuillez patienter");
        }

        #region Overrides

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            this.progressPanel1.Caption = caption;
        }

        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            this.progressPanel1.Description = description;
        }

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion Overrides

        public enum WaitFormCommand
        {
        }
    }
}