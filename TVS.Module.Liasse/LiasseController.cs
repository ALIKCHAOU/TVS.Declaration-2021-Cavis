using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Core;
using TVS.Core.Models.Liass;

namespace TVS.Module.Liasse
{
    public class LiasseController
    {
        private DeclarationService _service;
        public LiasseController(DeclarationService service)
        {
            _service = service;
        }


        public Core.Models.Liass.F6001 CurrentF6001()
        {
            var r = _service.LiassService.F6001Get(_service.Societe.Id, _service.Exercice.Id);
            if (r == null)
                return new Core.Models.Liass.F6001() { SocieteNo = _service.Societe.Id, ExerciceId = _service.Exercice.Id } ;
            return r;
        }


        public void Save(Core.Models.Liass.F6001 f6001)
        {
            if (f6001.Id < 1) { _service.LiassService.F6001Create(f6001); }
            else { _service.LiassService.F6001Update(f6001); }
        }

        public void Export(F6001 f6001, string fileName)
        {
            if (f6001==null) throw new NullReferenceException();
            string xml=f6001.ToXML(_service.Societe, _service.Exercice);
            System.IO.File.WriteAllText(fileName, xml, Encoding.UTF8);
        }




        public F6002 CurrentF6002()
        {
            var r = _service.LiassService.F6002Get(_service.Societe.Id, _service.Exercice.Id);
            if (r == null)
                return new F6002() { SocieteNo = _service.Societe.Id, ExerciceId = _service.Exercice.Id };
            return r;
        }


        public void Save(F6002 f6002)
        {
            if (f6002.Id < 1) { _service.LiassService.F6002Create(f6002); }
            else { _service.LiassService.F6002Update(f6002); }
        }

        public void Export(F6002 f6002, string fileName)
        {
            if (f6002 == null) throw new NullReferenceException();
            string xml = f6002.ToXML(_service.Societe, _service.Exercice);
            System.IO.File.WriteAllText(fileName, xml, Encoding.UTF8);
        }

        public F6003 CurrentF6003()
        {
            var r = _service.LiassService.F6003Get(_service.Societe.Id, _service.Exercice.Id);
            if (r == null)
                return new F6003() { SocieteNo = _service.Societe.Id, ExerciceId = _service.Exercice.Id };
            return r;
        }


        public void Save(F6003 F6003)
        {
            if (F6003.Id < 1) { _service.LiassService.F6003Create(F6003); }
            else { _service.LiassService.F6003Update(F6003); }
        }

        public void Export(F6003 F6003, string fileName)
        {
            if (F6003 == null) throw new NullReferenceException();
            string xml = F6003.ToXML(_service.Societe, _service.Exercice);
            System.IO.File.WriteAllText(fileName, xml, Encoding.UTF8);
        }
        public F6004 CurrentF6004()
        {
            var r = _service.LiassService.F6004Get(_service.Societe.Id, _service.Exercice.Id);
            if (r == null)
                return new F6004() { SocieteNo = _service.Societe.Id, ExerciceId = _service.Exercice.Id };
            return r;
        }
        public void Save(F6004 F6004)
        {
            if (F6004.Id < 1) { _service.LiassService.F6004Create(F6004); }
            else { _service.LiassService.F6004Update(F6004); }
        }

        public void Export(F6004 F6004, string fileName)
        {
            if (F6004 == null) throw new NullReferenceException();
            string xml = F6004.ToXML(_service.Societe, _service.Exercice);
            System.IO.File.WriteAllText(fileName, xml, Encoding.UTF8);
        }

        public F6004ModeleAutorsie CurrentF6004ModeleAutorsie()
        {
            var r = _service.LiassService.F6004ModeleAutorsieGet(_service.Societe.Id, _service.Exercice.Id);
            if (r == null)
                return new F6004ModeleAutorsie() { SocieteNo = _service.Societe.Id, ExerciceId = _service.Exercice.Id };
            return r;
        }
        public void Save(F6004ModeleAutorsie F6004)
        {
            if (F6004.Id < 1) { _service.LiassService.F6004ModeleAutorsieCreate(F6004); }
            else { _service.LiassService.F6004ModeleAutorsieUpdate(F6004); }
        }

        public void Export(F6004ModeleAutorsie F6004, string fileName)
        {
            if (F6004 == null) throw new NullReferenceException();
            string xml = F6004.ToXML(_service.Societe, _service.Exercice);
            System.IO.File.WriteAllText(fileName, xml, Encoding.UTF8);
        }

        public F6005 CurrentF6005()
        {
            var r = _service.LiassService.F6005Get(_service.Societe.Id, _service.Exercice.Id);
            if (r == null)
                return new F6005() { SocieteNo = _service.Societe.Id, ExerciceId = _service.Exercice.Id };
            return r;
        }
        public void Save(F6005 F6005)
        {
            if (F6005.Id < 1) { _service.LiassService.F6005Create(F6005); }
            else { _service.LiassService.F6005Update(F6005); }
        }

        public void Export(F6005 F6005, string fileName)
        {
            if (F6005 == null) throw new NullReferenceException();
            string xml = F6005.ToXML(_service.Societe, _service.Exercice);
            System.IO.File.WriteAllText(fileName, xml, Encoding.UTF8);
        }

        public F6301 CurrentF6301()
        {
            var r = _service.LiassService.F6301Get(_service.Societe.Id, _service.Exercice.Id);
            if (r == null)
                return new F6301() { SocieteNo = _service.Societe.Id, ExerciceId = _service.Exercice.Id };
            return r;
        }
        public void Save(F6301 F6301)
        {
            if (F6301.Id < 1) { _service.LiassService.F6301Create(F6301); }
            else { _service.LiassService.F6301Update(F6301); }
        }

        public void Export(F6301 F6301, string fileName)
        {
            if (F6301 == null) throw new NullReferenceException();
            string xml = F6301.ToXML(_service.Societe, _service.Exercice);
            System.IO.File.WriteAllText(fileName, xml, Encoding.UTF8);
        }


        public F6303 CurrentF6303()
        {
            var r = _service.LiassService.F6303Get(_service.Societe.Id, _service.Exercice.Id);
            if (r == null)
                return new F6303() { SocieteNo = _service.Societe.Id, ExerciceId = _service.Exercice.Id };
            return r;
        }
        public void Save(F6303 F6303)
        {
            if (F6303.Id < 1) { _service.LiassService.F6303Create(F6303); }
            else { _service.LiassService.F6303Update(F6303); }
        }

        public void Export(F6303 F6303, string fileName)
        {
            if (F6303 == null) throw new NullReferenceException();
            string xml = F6303.ToXML(_service.Societe, _service.Exercice);
            System.IO.File.WriteAllText(fileName, xml, Encoding.UTF8);
        }


        public F6304 CurrentF6304()
        {
            var r = _service.LiassService.F6304Get(_service.Societe.Id, _service.Exercice.Id);
            if (r == null)
                return new F6304() { SocieteNo = _service.Societe.Id, ExerciceId = _service.Exercice.Id };
            return r;
        }
        public void Save(F6304 F6304)
        {
            if (F6304.Id < 1) { _service.LiassService.F6304Create(F6304); }
            else { _service.LiassService.F6304Update(F6304); }
        }

        public void Export(F6304 F6304, string fileName)
        {
            if (F6304 == null) throw new NullReferenceException();
            string xml = F6304.ToXML(_service.Societe, _service.Exercice);
            System.IO.File.WriteAllText(fileName, xml, Encoding.UTF8);
        }

        public string GetXmlFileName(object o)
        {
            string name = o.GetType().Name+ "-"+ _service.Societe.MatriculFiscal.Replace(" ",String.Empty).Trim()+ _service.Societe.MatriculCle.Replace(" ", String.Empty).Trim() + "-"+_service.Exercice.Annee.Trim()+".xml";
            return name;
        }
    }
}
