using System;
using System.Data.Entity.Validation;
using System.Text;

namespace TVS.Ef.Migration.Declaration
{
    internal class FormattedDbEntityValidationException : Exception
    {
        public FormattedDbEntityValidationException(DbEntityValidationException innerException) :
            base(null, innerException)
        {
        }

        public override string Message
        {
            get
            {
                var innerException = InnerException as DbEntityValidationException;
                if (innerException != null)
                {
                    var sb = new StringBuilder();

                    sb.AppendLine();
                    sb.AppendLine();
                    foreach (DbEntityValidationResult eve in innerException.EntityValidationErrors)
                    {
                        sb.AppendLine(
                            string.Format(
                                "- Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                eve.Entry.Entity.GetType().FullName, eve.Entry.State));
                        foreach (DbValidationError ve in eve.ValidationErrors)
                        {
                            sb.AppendLine(string.Format("-- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                                ve.PropertyName,
                                eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                                ve.ErrorMessage));
                        }
                    }
                    sb.AppendLine();

                    return sb.ToString();
                }

                return base.Message;
            }
        }
    }
}