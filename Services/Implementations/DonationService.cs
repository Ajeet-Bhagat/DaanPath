using DaanPath.Entity;
using DaanPath.Repositories.Interfaces;
using DaanPath.Services.Interfaces;

namespace DaanPath.Services.Implementations
{
    public class DonationService : IDonationService
    {
        private readonly IDonationRepository _donationRepository;
        public DonationService(IDonationRepository donationRepository) { 
            _donationRepository = donationRepository;
        }

        public async Task<IEnumerable<Donation>> GetAllDonationsAsync()
        {
            return await _donationRepository.GetAllDonationAsync();
        }

        public async Task<Donation> GetDonationByIdAsync(int id)
        {
            return await _donationRepository.GetDonationByIdAsync(id);
        }

        public async Task<bool> CreateDonationAsync(Donation donation)
        {
            if (donation == null) {
                return false;
            }
            await _donationRepository.AddDonationAsync(donation);
            return true;
        }

        public async Task<bool> UpdateDonationAsync(Donation donation)
        {
            var existingDonation = await _donationRepository.GetDonationByIdAsync(donation.DonationID);
            if (existingDonation == null) { 
                return true;
            }
            await _donationRepository.UpdateDonationAsync(donation);
            return true;
        }

        public async Task<bool> DeleteDonationAsync(int id)
        {
            var existingDonation = await _donationRepository.GetDonationByIdAsync(id);
            if (existingDonation == null)
            {
                return false;
            }
            await _donationRepository.DeleteDonationAsync(id);
            return true;
        }
    }
}
