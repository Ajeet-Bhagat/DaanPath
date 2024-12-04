using DaanPath.Entity;

namespace DaanPath.Repositories.Interfaces
{
    public interface IDonationRepository
    {
        Task<IEnumerable<Donation>> GetAllDonationAsync();
        Task<Donation> GetDonationByIdAsync(int id);
        Task AddDonationAsync(Donation donation);
        Task UpdateDonationAsync(Donation donation);
        Task DeleteDonationAsync(int id);
    }
}
