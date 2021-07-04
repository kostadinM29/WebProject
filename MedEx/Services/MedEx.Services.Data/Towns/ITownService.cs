using System.Collections.Generic;

namespace MedEx.Services.Data.Towns
{
    public interface ITownService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
