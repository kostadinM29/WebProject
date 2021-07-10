using System;

namespace MedEx.Services.DateTimeParser
{
    public interface IDateTimeParserService
    {
        DateTime ConvertStrings(string date, string time);
    }
}
