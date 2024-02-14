using NuGet.Protocol;
using OneClick.Infrastructure.Interface;
using OneClick.Infrastructure.Model;
using OneClick.Model;
using OneClick.Models;
using OneClick.Service.Interface;
using OneClick.Utility;
using static OneClick.Models.Constant;

namespace OneClick.Service
{
    public class UserService : IUserService
    {
        private IUsersRepository _usersRepository;
        private ILogger<UserService> _logger;
        public string CLASSNAME = "UserService";
        public UserService(IUsersRepository usersRepository, ILogger<UserService> logger)
        {
            _usersRepository = usersRepository;
            _logger = logger;
        }

        public ResponseMessage AddUser(UserRequest userRequest)
        {
            ResponseMessage response = new ();
            try
            {
                userRequest.Password = Helper.HashPassword(userRequest.Password);
                Users dbRequest = UserMapping(userRequest);
                _usersRepository.AddUser(dbRequest);
                response.MessageCode = MessageCode.Success;
                response.MessageDescription = MessageDescription.Success;
            }
            catch(Exception ex)
            {
                _logger.LogError($"CLASSNAME: {CLASSNAME} METHOD: AddUser Message:{ex.Message} StackTrace:{ex.StackTrace}");
                response.MessageCode = MessageCode.Failure;
                response.MessageDescription = MessageDescription.Failure;
            }
            return response;
        }

        public Users UserMapping(UserRequest req)
        {
            return new Users
            {
                City = req.City,
                Country = req.Country,
                CreatedBy = 0,
                CreatedOn = DateTime.Now,
                Deleted = false,
                FullName = req.FullName,
                IsActive = true,
                MobileNo = req.MobileNo,
                Password = req.Password,
                UserName = req.UserName,

            };
        }
       public  ResponseMessage Login(LoginRequest login)
        {
            ResponseMessage response = new();
            try
            {
                login.Password = Helper.HashPassword(login.Password);
                var userResponse = _usersRepository.Login(login.UserName, login.Password);
                if(userResponse != null)
                {
                    response.MessageCode = MessageCode.Success;
                    response.MessageDescription = MessageDescription.Success;
                }
                else
                {
                    response.MessageCode = MessageCode.WrongUsernameOrPassword;
                    response.MessageDescription = MessageDescription.WrongUsernameOrPassword;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"CLASSNAME: {CLASSNAME} METHOD: AddUser Message:{ex.Message} StackTrace:{ex.StackTrace}");
                response.MessageCode = MessageCode.Failure;
                response.MessageDescription = MessageDescription.Failure;
            }
            return response;
        }
    }
}
