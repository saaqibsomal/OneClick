using OneClick.Infrastructure.Db;
using OneClick.Infrastructure.Interface;
using OneClick.Infrastructure.Model;

namespace OneClick.Infrastructure.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private OneClickContext _context;
        public UsersRepository(OneClickContext context)
        {
            _context = context;
        }

        public void AddUser(Users users)
        {
            _context.Users.Add(users);
            _context.SaveChanges();
        }

        public void UpdateUser(Users users)
        {
            _context.Users.Update(users);
            _context.SaveChanges();
        }

        public Users Login(string Email, string Password)
        {
            return _context.Users.Where(x => x.Email == Email && x.Password == Password).FirstOrDefault();
        }


        public Users GetUserByUsername(string UserName)
        {
            return _context.Users.Where(x => x.UserName == UserName).FirstOrDefault();
        }
        public Users GetUserByEmail(string UserName)
        {
            return _context.Users.Where(x => x.UserName == UserName).FirstOrDefault();
        }
    }
}
