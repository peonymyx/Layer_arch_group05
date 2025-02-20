using Backend.CoreLayer.Entities;
using Backend.DataAccessLayer;

namespace Backend.BussinessLayer
{
    public class UserBusiness
    {
        private readonly UserRepository _userRepository;

        public UserBusiness(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task AddUserAsync(User user)
        {
            await _userRepository.AddUserAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }

        public async Task<IEnumerable<User>> GetTopActiveUsersAsync(int topCount)
        {
            return await _userRepository.GetTopActiveUsersWithSpAsync(topCount);
        }
    }
}
