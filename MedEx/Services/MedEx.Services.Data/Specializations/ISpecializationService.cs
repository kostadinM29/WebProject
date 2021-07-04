using System.Collections.Generic;

namespace MedEx.Services.Data.Specializations
{
    public interface ISpecializationService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
