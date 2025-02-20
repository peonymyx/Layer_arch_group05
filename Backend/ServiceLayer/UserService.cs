using Backend.BussinessLayer;
using Backend.CoreLayer.Entities;

namespace Backend.ServiceLayer
{
    public class UserService
    {
        private readonly UserBusiness _userBusiness;

        public UserService(UserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userBusiness.GetAllUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userBusiness.GetUserByIdAsync(id);
        }

        public async Task AddUserAsync(User user)
        {
            await _userBusiness.AddUserAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userBusiness.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userBusiness.DeleteUserAsync(id);
        }

        public async Task<IEnumerable<User>> GetTopActiveUsersAsync(int topCount)
        {
            return await _userBusiness.GetTopActiveUsersAsync(topCount);
        }
    }
}
