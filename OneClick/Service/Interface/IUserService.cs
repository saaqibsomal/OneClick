using OneClick.Infrastructure.Model;
using OneClick.Model;
using OneClick.Models;

namespace OneClick.Service.Interface
{
    public interface IUserService
    {
        ResponseMessage AddUser(UserRequest users);
        UserResponse Login(LoginRequest users);
    }
}
