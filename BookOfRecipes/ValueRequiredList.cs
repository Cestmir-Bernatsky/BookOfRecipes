using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

public class ValueRequiredList : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        var list = value as List<int>;
        return list != null && list.All(item => item != 0 || item.ToString() == "Jednotka");
    }
}