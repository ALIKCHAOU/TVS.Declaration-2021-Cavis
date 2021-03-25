using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Ef.Migration.Declaration.Models
{
    [Table("Utilisateur")]
    public class TUser
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public int IsAdmin { get; set; }
        public int DecEmp { get; set; }
        public int DecEmpAnnexe1 { get; set; }
        public int Cnss { get; set; }
        public int Vente { get; set; }
        public int Achat { get; set; }
        public int Virement { get; set; }
        public int Liasse { get; set; }
    }
}
