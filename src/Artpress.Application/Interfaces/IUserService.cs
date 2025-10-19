using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Artpress.Application.DTOs.Users;
using Artpress.Domain.Common;

namespace Artpress.Application.Interfaces
{
    public interface IUserService
    {
        Task<PagedResult<UserResponse>> GetAllUsersAsync(int pageNumber, int pageSize);
        Task<UserResponse> GetUserByIdAsync(Guid id);
        Task<UserResponse> CreateUserAsync(CreateUserRequest userDto);
        Task UpdateUserAsync(Guid id, UpdateUserRequest userDto);
        Task DeleteUserAsync(Guid id);
    }
}
