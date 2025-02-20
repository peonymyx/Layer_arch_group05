using Backend.CoreLayer.Entities;
using Backend.DataAccessLayer;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace Backend.BussinessLayer
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Lấy danh sách tất cả User
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        // Lấy thông tin một User theo Id
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        // Thêm User mới, có kiểm tra trùng email
        public async Task AddUserAsync(User user)
        {
            var existingUsers = await _userRepository.GetAllUsersAsync();
            if (existingUsers != null && existingUsers.Any(u => u.email == user.email))
            {
                throw new ArgumentException("A user with the same email already exists.");
            }
            await _userRepository.AddUserAsync(user);
        }

        // Cập nhật thông tin User
        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateUserAsync(user);
        }

        // Xóa User theo Id
        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }
    }
}
