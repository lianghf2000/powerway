using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
///RequiredValidata 的摘要说明
/// </summary>
public class Validatas
{
    public static RequiredFieldValidator GetRequired(Column c)
    {
        RequiredFieldValidator required = new RequiredFieldValidator();
        required.ID = c.ColumnName + "_required";
        required.ControlToValidate = c.ColumnName + "_value";
        required.ErrorMessage = "*";
        required.SetFocusOnError = true;
        required.Display = ValidatorDisplay.Dynamic;
        required.ValidationGroup = "modify";

        return required;
    }

    public static RangeValidator GetRange(Column c)
    {
        RangeValidator v = new RangeValidator();
        v.ID = c.ColumnName + "_range";
        v.ControlToValidate = c.ColumnName + "_value";
        v.SetFocusOnError = true;
        v.MaximumValue = c.RangeMax;
        v.MinimumValue = c.RangeMin;
        v.ErrorMessage = c.RangeMin + "-" + c.RangeMax;
        v.ValidationGroup = "modify";
        v.Display = ValidatorDisplay.Dynamic;
        v.Type = c.RangeType;

        return v;
    }
}
