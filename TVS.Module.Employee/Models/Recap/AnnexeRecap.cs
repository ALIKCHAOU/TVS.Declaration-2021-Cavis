using System.Collections.Generic;

namespace TVS.Module.Employee.Models.Recap
{
    public enum Annexe
    {
        Annexe1,
        Annexe2,
        Annexe3,
        Annexe4,
        Annexe5,
        Annexe6,
        Annexe7
    }

    public class AnnexeVerfication
    {
        public Annexe Annexe { get; set; }

        public decimal SumAnnexe { get; set; }

        public decimal SumAnnexeRecap { get; set; }

        public decimal Ecart
        {
            get { return SumAnnexeRecap - SumAnnexe; }
        }

        public bool IsVerify
        {
            get { return Ecart == 0; }
        }

        public bool IsDepose { get; set; }
    }

    public class AnnexeRecap
    {
        public EnteteRecap Entete { get; set; }

        public List<LigneRecap> Lignes { get; set; }

        public PiedRecap Pied { get; set; }

        public List<AnnexeVerfication> Verification { get; set; }
    }
}