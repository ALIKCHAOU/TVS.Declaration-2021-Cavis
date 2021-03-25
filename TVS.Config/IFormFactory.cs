using System.Windows.Forms;

namespace TVS.Config
{
    public interface IFormFactory
    {
        T Create<T>() where T : Form;
    }
}