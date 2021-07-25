using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MedEx.Common.Attributes
{
    public class ValidateTimeStringAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            var timeString = value as string;

            if (string.IsNullOrEmpty(timeString))
            {
                return false;
            }

            var parsed = DateTime.TryParseExact(
                timeString,
                GlobalConstants.DateTimeFormats.TimeFormat,
                CultureInfo.InvariantCulture,
                style: DateTimeStyles.AssumeUniversal,
                result: out _);
            return parsed;
        }
    }
}
