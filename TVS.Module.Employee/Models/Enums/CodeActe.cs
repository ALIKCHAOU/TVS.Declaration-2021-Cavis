using System.ComponentModel;

namespace TVS.Module.Employee.Models.Enums
{
    public enum CodeActe : int
    {
        [Description("Spontané")] Spontane = 0,

        [Description("Régularisation")] Regularisation = 1,

        [Description("Redressement")] Redressement = 2
    }
}