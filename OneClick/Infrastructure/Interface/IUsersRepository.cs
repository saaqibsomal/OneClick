using OneClick.Infrastructure.Model;

namespace OneClick.Infrastructure.Interface
{
    public interface IUsersRepository
    {
        void AddUser(Users users);
        void UpdateUser(Users users);
        Users Login(string UserName, string Password);
        Users GetUserByUsername(string UserName);
        Users GetUserByEmail(string UserName);
    }
}
