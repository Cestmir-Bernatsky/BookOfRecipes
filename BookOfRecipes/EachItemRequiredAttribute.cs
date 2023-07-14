using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

public class EachValueRequiredAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        var dictionary = value as Dictionary<int, int>;
        return dictionary != null && dictionary.All(pair => pair.Value != 0);
    }
}
