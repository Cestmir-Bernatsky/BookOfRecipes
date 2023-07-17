using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

public class ValueRequiredListAttribute : ValidationAttribute
{
    //public override bool IsValid(object value)
    //{
    //    var list = value as List<int>;
    //    return list != null && list.All(item => item != 0);

    //}

    private readonly string _defaultValue;

    public ValueRequiredListAttribute(string defaultValue)
    {
        _defaultValue = defaultValue;
    }

    public override bool IsValid(object value)
    {
        var list = value as List<int>;
        return list != null && list.All(item => item != 0);
    }
}
