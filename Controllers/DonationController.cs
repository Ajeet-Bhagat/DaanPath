using Microsoft.AspNetCore.Mvc;
using DaanPath.Services.Interfaces;
using DaanPath.Entity;

namespace DaanPath.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonationController : ControllerBase
    {
        private readonly IDonationService _donationService;

        public DonationController(IDonationService donationService)
        {
            _donationService = donationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Donation>>> GetAllDonations()
        {
            var donations = await _donationService.GetAllDonationsAsync();
            return Ok(donations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Donation>> GetDonationById(int id)
        {
            var donation = await _donationService.GetDonationByIdAsync(id);
            if (donation == null)
            {
                return NotFound();
            }
            return Ok(donation);
        }

        [HttpPost]
        public async Task<ActionResult> CreateDonation([FromBody] Donation donation)
        {
            var created = await _donationService.CreateDonationAsync(donation);
            if (!created)
            {
                return BadRequest("Invalid donation data.");
            }
            return CreatedAtAction(nameof(GetDonationById), new { id = donation.DonationID }, donation);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDonation(int id, [FromBody] Donation donation)
        {
            if (id != donation.DonationID)
            {
                return BadRequest("Donation ID mismatch.");
            }

            var updated = await _donationService.UpdateDonationAsync(donation);
            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDonation(int id)
        {
            var removed = await _donationService.DeleteDonationAsync(id);
            if (!removed)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
