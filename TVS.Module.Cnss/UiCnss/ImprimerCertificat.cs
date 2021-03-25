using Dapper;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TVS.Core;
using TVS.Core.Models;
using TVS.Module.Cnss.UiCnss;
using TVS.Module.Cnss.UiCnss.Controller;
using TVS.Module.Cnss.UiCnss.Views;

namespace CnssModule.Declarations
{
    public partial class ImprimerCertificat : XtraForm
    {
       

        private readonly DeclarationsController _controller;

        private DeclarationView _declaration;
        private List<LigneCnss> _listeCNSS = new List<LigneCnss>();
        private List<int> _listeT = new List<int>();

        private int _employeeNo;
        public string _Matricule;
        public string _RaisonSocial;
      public  string tabMatricule;
      
        private ImprimerCertificat()
        {
            InitializeComponent();
        }

        public ImprimerCertificat(DeclarationsController controller ,List<LigneCnss> listeCNSS , int employeeNo , List<int> listeT)
            : this()
        {
            _controller = controller;
            _listeCNSS = listeCNSS;
            _employeeNo = employeeNo;
            _listeT = listeT;
            InitcbSociete();
            
            
           //var  _categories = _controller.GetAllCategories();
           //var  _currentSociete = controller.GetCurrentSociete();
           //var  _currentExercice = controller.GetCurrentExercice();
            
           // txtExercice.Text = _currentExercice.Annee;
           // txtSociete.Text = _currentSociete.RaisonSocial;
           // txtMatriculeEmploye.Text = _currentSociete.NumeroEmployeur;
        }

        public ImprimerCertificat(DeclarationsController controller)
            : this()
        {
            _controller = controller;
            
            InitcbSociete();

            btValider.Click += Valider;
            btAnnuler.Click += (sender, args) => Close();
 
        }

        private void BindingSouce()
        {
            _declaration = _declaration ?? _controller.InitDeclaration();

            cbExercice.DataBindings.Clear();
            cbExercice.DataBindings.Add("EditValue", _declaration, "Annee", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);
                      

            dxErrorProvider.DataSource = null;
        }

        private void InitcbSociete()
        {                    
          
            cbExercice.Properties.DisplayMember = "Annee";
            cbExercice.Properties.ValueMember = "Id";
            cbExercice.Properties.View.Columns.Add(new GridColumn
            {
                Caption = "",
                FieldName = "Annee",
                Visible = true,
            });
            cbExercice.Properties.NullText = string.Empty;
            cbExercice.Properties.ImmediatePopup = true;
            cbExercice.Properties.View.OptionsView.ShowColumnHeaders = false;
            cbExercice.Properties.ShowFooter = false;
            cbExercice.Properties.View.OptionsView.ShowIndicator = false;
            cbExercice.Properties.PopupFormSize = new Size(20, 50);
            cbExercice.Properties.DataSource = _controller.GetAllExercice().ToList();

            cbExercciceFin.Properties.DisplayMember = "Annee";
            cbExercciceFin.Properties.ValueMember = "Id";
            cbExercciceFin.Properties.View.Columns.Add(new GridColumn
            {
                Caption = "",
                FieldName = "Annee",
                Visible = true,
            });
            cbExercciceFin.Properties.NullText = string.Empty;
            cbExercciceFin.Properties.ImmediatePopup = true;
            cbExercciceFin.Properties.View.OptionsView.ShowColumnHeaders = false;
            cbExercciceFin.Properties.ShowFooter = false;
            cbExercciceFin.Properties.View.OptionsView.ShowIndicator = false;
            cbExercciceFin.Properties.PopupFormSize = new Size(20, 50);
            cbExercciceFin.Properties.DataSource = _controller.GetAllExercice().ToList();

        }


       // GridView viewnum = TVS.Module.Cnss.UiCnss.Views.LigneView;

        public void Valider(object sender, EventArgs e)
        {
            

            // Traverse data rows and change the Price field values.  
          
                string query = @"SELECT distinct lc.nom, lc.Prenom, lc.Brut1 , lc.Brut2 , lc.Brut3 , lc.Page , lc.Ligne ,dc.Trimestre , s.RaisonSocial   , Ex.Annee as  Année  , dc.ExerciceId as Exercice,   lc.NumeroInterne as Matricule  
 ,s.[RaisonSocial] as NomSociete , s.[NumeroEmployeur] as CNSS_Societe  ,lc.[NumeroCnss] as CNSS_Empolye
  FROM  [dbo].[LigneCnss]   lc inner join DeclarationCnss dc on lc.SocieteNo = dc.SocieteId  and lc.DeclarationNo = dc.Id    inner join[dbo].[Societe] s on lc.SocieteNo=s.Id   inner join [dbo].[Exercice]   Ex on dc.ExerciceId=Ex.Id

 where lc.NumeroInterne='" + _Matricule+ "' and s.[RaisonSocial]='" + _RaisonSocial + "' and  year (Ex.Annee)	 BETWEEN '" + cbExercice.Text + "' AND '" + cbExercciceFin.Text+"' order by Ex.Annee, dc.Trimestre ;";
         

            if (query != null)
                {
                    //var Exercice = _currentExercice.Annee;
                    //var Societe = _currentSociete.RaisonSocial;
                    //var MatriculeEmploye = _currentSociete.NumeroEmployeur;

                 //   var bord =viewLigne.GetFocusedRow() as LigneView;

                  //  var num = bord.NumeroInterne.ToString();



                    List<AttestationSalaire> data = new List<AttestationSalaire>();

                    using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString))
                    {
                        if (db.State == ConnectionState.Closed)
                            db.Open();
                    List<AttestationSalaire> a = db.Query<AttestationSalaire>(query, commandType: CommandType.Text).ToList();

                    List<AttestationSalaire> b = a.Where(x => x.Année.Equals(cbExercice.Text) && x.Trimestre < Int16.Parse(cbTrimestre.Text)).ToList();
                    List<AttestationSalaire> c =  a.Where(x => x.Année.Equals(cbExercciceFin.Text) && x.Trimestre > Int16.Parse(cbTrimestreFin.Text)).ToList();

                    foreach (var vb in b )
                    {
                        a.Remove(vb);

                    }

                    foreach (var vc in c)
                    {
                        a.Remove(vc);

                    }


                    foreach (AttestationSalaire at in a)
                        {
                            data.Add(at);
                            //at.Montant =(_colTotal);
                            
                        }


                    }
                    _attestation report = new _attestation();
                    report.DataSource = data;
           

                    ReportPrintTool tool = new ReportPrintTool(report);
                    tool.ShowPreview();

                }
                else
                {
                    MessageBox.Show("", "Attestation CNSS n'existe pas!",
         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
          
         
        }


        private void btAnnuler_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ImprimerCertificat_Load(object sender, EventArgs e)
        {

        }
    }
}