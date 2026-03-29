using Microsoft.AspNetCore.Identity;
using VirtualSalesWareHouse.Data.Entities;
using VirtualSalesWareHouse.Models;

namespace VirtualSalesWareHouse.Helpers;

public interface IUserHelper
{
    Task<User> GetUserAsync(string email);
    Task<IdentityResult> AddUserAsync(User user, string password);
    Task CheckRoleAsync(string roleName);
    Task AddUserToRoleAsync(User user, string roleName);
    Task<bool> IsUserInRoleAsync(User user, string roleName);
    Task<SignInResult> LoginAsync(LoginViewModel model);
    Task LogoutAsync();
}
