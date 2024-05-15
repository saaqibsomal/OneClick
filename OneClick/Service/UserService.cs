using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol;
using OneClick.Infrastructure.Interface;
using OneClick.Infrastructure.Model;
using OneClick.Infrastructure.Repository;
using OneClick.Model;
using OneClick.Models;
using OneClick.Service.Interface;
using OneClick.Utility;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
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
               var userResponse = _usersRepository.GetUserByUsername(userRequest.UserName);
                if(userResponse is not null)
                {
                    response.MessageCode = MessageCode.AlreadyRegister;
                    response.MessageDescription = MessageDescription.AlreadyRegister;
                    return response;
                }

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
                Email = req.Email,

            };
        }
       public UserResponse Login(LoginRequest login)
        {
            UserResponse response = new();
            try
            {
                login.Password = Helper.HashPassword(login.Password);
                var userResponse = _usersRepository.Login(login.Email, login.Password);
                if(userResponse != null)
                {
                    response.Token =  GenerateJwtToken("kCompute!@#123321#@!#%#!%&%^&FDR#", userResponse.UserName, login.Email);
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
                _logger.LogError($"CLASSNAME: {CLASSNAME} METHOD: Login Message:{ex.Message} StackTrace:{ex.StackTrace}");
                response.MessageCode = ex.Message;
                response.MessageDescription = ex.StackTrace.ToString();
            }
            return response;
        }

        public string GenerateJwtToken(string secretKey,string username,string Email)
        {

      
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Email, Email),
        };

            var token = new JwtSecurityToken(
                issuer: "https://business.gos.pk",
                audience: "https://business.gos.pk",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(9),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
