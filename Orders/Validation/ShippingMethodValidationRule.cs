
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using Boytrix.Logic.DataTransfer.Model;

namespace Boytrix.UI.WPF.BoytrixModules.Order.Validation
{
    public class ShippingMethodValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (ShippingMethodPattern.ShippingMethodName  == null)
                return ValidationResult.ValidResult;
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                return ValidationResult.ValidResult;
            string[] pieces = value.ToString().Split(',');
            Regex m_RegEx = new Regex(ShippingMethodPattern.ShippingMethodName);
            foreach (string item in pieces)
            {
                Match match = m_RegEx.Match(item);
                if (match == null || match == Match.Empty)
                    return new ValidationResult(false, "Invalid input format");
            }
            return ValidationResult.ValidResult;
        }

        public ShippingMethod ShippingMethodPattern { get; set; }
    }
}
