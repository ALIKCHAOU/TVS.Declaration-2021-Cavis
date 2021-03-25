using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TVS.Module.Liasse.Annotations;

namespace TVS.Module.Liasse.Model
{
    public class LigneLiasse : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private  object GetPropValue(object src, string propName)
        {   if(string.IsNullOrWhiteSpace(propName))
                return null;
            var propertyInfo = src.GetType().GetProperty(propName);
            if (propertyInfo != null)
                return propertyInfo.GetValue(src, null);
            return null;
        }

        private  void SetPropValue(object src, string propName,object value)
        {
            if (string.IsNullOrWhiteSpace(propName))
                return;
                var propertyInfo = src.GetType().GetProperty(propName);
            if (propertyInfo != null)
                propertyInfo.SetValue(src, value);
            OnPropertyChanged("propName");


        }

        public  bool CantSetPropValue(object src, string propName)
        {
            var propertyInfo = src.GetType().GetProperty(propName);
            return propertyInfo == null || propertyInfo.SetMethod == null || (!propertyInfo.SetMethod.IsPublic);
        }
        public object ObjectLiasse { get; set; }
        public int Ordre { get; set; }
        public string Libelle { get; set; }
        public string CodeB { get; set; }
        public string CodeN { get; set; }
        public string CodeN1 { get; set; }
        public string CodeAmortissement { get; set; }

        public object ValeurB
        {
            get { return GetPropValue(ObjectLiasse, CodeB); }
            set { SetPropValue(ObjectLiasse, CodeB, value); }
        }

        public object ValeurN
        {
            get { return GetPropValue(ObjectLiasse, CodeN); }
            set { SetPropValue(ObjectLiasse, CodeN, value); }
        }
        public object ValeurN1
        {
            get { return GetPropValue(ObjectLiasse,CodeN1); }
            set { SetPropValue(ObjectLiasse, CodeN1, value); }
        }
        public object ValeurAmortissement
        {
            get { return GetPropValue(ObjectLiasse, CodeAmortissement); }
            set { SetPropValue(ObjectLiasse, CodeAmortissement, value); }
        }
        public Type TypeValeurs { get; set; }
        public object[] Options { get; set; } 
        public bool Calculable { get { return CantSetPropValue(ObjectLiasse, CodeN1); } }
       
    }
}
