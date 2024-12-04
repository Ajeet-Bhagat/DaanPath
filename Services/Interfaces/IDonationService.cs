using DaanPath.Entity;

namespace DaanPath.Services.Interfaces
{
    public interface IDonationService
    {
        Task<IEnumerable<Donation>> GetAllDonationsAsync();
        Task<Donation> GetDonationByIdAsync(int id);
        Task<bool> CreateDonationAsync(Donation donation);
        Task<bool> UpdateDonationAsync(Donation donation);
        Task<bool> DeleteDonationAsync(int id);
    }
}
