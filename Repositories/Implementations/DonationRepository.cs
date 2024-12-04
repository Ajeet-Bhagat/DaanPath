using DaanPath.Data;
using DaanPath.Entity;
using DaanPath.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DaanPath.Repositories.Implementations
{
    public class DonationRepository: IDonationRepository
    {
        private readonly DonationAppContext _context;

        public DonationRepository(DonationAppContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Donation>> GetAllDonationAsync()
        {
            return await _context.Donations.ToListAsync();
        }
        public async Task<Donation> GetDonationByIdAsync(int id)
        {
            return await _context.Donations.FirstOrDefaultAsync(d => d.DonationID == id);
        }
        public async Task AddDonationAsync(Donation donation)
        {
            await _context.Donations.AddAsync(donation);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateDonationAsync(Donation donation)
        {
            _context.Donations.Add(donation);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteDonationAsync(int id) {
            var donation = await _context.Donations.FindAsync(id);
            if (donation != null) { 
                _context.Donations.Remove(donation);
                await _context.SaveChangesAsync();
            }
        }
    }
}
