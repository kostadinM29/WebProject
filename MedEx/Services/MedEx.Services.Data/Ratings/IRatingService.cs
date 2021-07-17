using System.Threading.Tasks;

namespace MedEx.Services.Data.Ratings
{
    public interface IRatingService
    {
        Task AddAsync(int appointmentId, int doctorId, int patientId, int number, string comment);
    }
}
