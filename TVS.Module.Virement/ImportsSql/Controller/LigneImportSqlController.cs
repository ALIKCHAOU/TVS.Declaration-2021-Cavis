using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Core;
using TVS.Core.Models;
using TVS.Module.Virement.ImportsSql.Views;
using TVS.Module.Virement.UiVirement.Views;

namespace TVS.Module.Virement.ImportsSql.Controller
{
    public class LigneImportSqlController
    {
        private readonly DeclarationService _service;
        private readonly DeclarationView _entete;
        public LigneImportSqlController(DeclarationService service , DeclarationView entete)
        {
            if (service == null) throw new ArgumentNullException("service");
            _service = service;
            _entete = entete;
        }
       
    }
}
