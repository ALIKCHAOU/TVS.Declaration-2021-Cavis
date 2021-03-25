using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace TVS.Core.Enums
{
    public class EnumHelper<T>
        where T : struct, IConvertible
    {
        public static IEnumerable<EnumEx<T>> GetEnumExCollection()
        {
            if (!typeof(T).IsEnum) throw new InvalidOperationException("Type invalide");

            return System.Enum.GetValues(typeof(T))
                .Cast<T>()
                .Select(x =>
                {
                    var description = string.Empty;
                    var memberInfo = typeof(T).GetMember(x.ToString()).FirstOrDefault();
                    if (memberInfo != null)
                    {
                        var attribute = memberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false)
                            .FirstOrDefault() as DescriptionAttribute;

                        if (attribute != null)
                        {
                            description = attribute.Description;
                        }
                    }

                    return new EnumEx<T> {Value = x, Description = description};
                });
        }
    }

    public class EnumEx<T> where T : struct, IConvertible
    {
        public T Value { get; set; }

        public string Description { get; set; }
    }
}