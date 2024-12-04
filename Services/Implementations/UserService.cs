using DaanPath.Entity;
using DaanPath.Repositories.Interfaces;
using DaanPath.Services.Interfaces;

namespace DaanPath.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<User> GetUserDetailsAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            if (user == null)
            {
                return false;
            }

            await _userRepository.AddUserAsync(user);
            return true;
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            var existingUser = await _userRepository.GetUserByIdAsync(user.UserID);
            if (existingUser == null)
            {
                return false;
            }

            await _userRepository.UpdateUserAsync(user);
            return true;
        }

        public async Task<bool> RemoveUserAsync(int id)
        {
            var existingUser = await _userRepository.GetUserByIdAsync(id);
            if (existingUser == null)
            {
                return false;
            }

            await _userRepository.DeleteUserAsync(id);
            return true;
        }
    }
}
