using MedEx.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MedEx.Web.ViewModels.Common
{
    public class ValidateDateStringAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            var dateString = value as string;

            if (string.IsNullOrEmpty(dateString))
            {
                return false;
            }

            var parsed = DateTime.TryParseExact(
                dateString,
                GlobalConstants.DateTimeFormats.DateFormat,
                CultureInfo.InvariantCulture,
                style: DateTimeStyles.AssumeUniversal,
                result: out var dt);
            if (!parsed)
            {
                return false;
            }

            return dt >= DateTime.UtcNow.Date;
        }
    }
}
