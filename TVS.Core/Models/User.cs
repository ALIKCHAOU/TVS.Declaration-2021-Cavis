using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Mail { get; set; }
        public bool DecEmp { get; set; }
        public bool DecEmpAnnexe1 { get; set; }
        public bool Cnss { get; set; }
        public bool Vente { get; set; }
        public bool Achat { get; set; }
        public bool Liasse { get; set; }
        public bool Virement { get; set; }
        public override string ToString()
        {
            return $"{this.Login} - {this.Nom} {this.Prenom}";
        }

        public override bool Equals(object obj) { 
        
            if(obj is User user){
                return user.Id == this.Id;
            }
            return false;
        }
    }
}
