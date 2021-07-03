using MedEx.Web.ViewModels.Index;

namespace MedEx.Services.Data.Home
{
    public interface IHomeService
    {
        IndexViewModel GetAllCounts();
    }
}
