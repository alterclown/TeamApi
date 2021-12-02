using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ReactAngularPracticeApi.Data.Context;
using ReactAngularPracticeApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ReactAngularPracticeApi.Repository.AuthenticationRepository
{
    public interface IAuthenticationRepository
    {
        Task<List<User>> GetUserList();
        Task<User> RetrieveUserInfo(int userId);
        Task<User> PostLoginInfo(User users);
        Task<User> RegiserNewUser(User user);
    }

    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly AppSettings _appSettings;
        private readonly PracticeContext _context;
        public AuthenticationRepository(IOptions<AppSettings> appSettings, PracticeContext context)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }
        public async Task<List<User>> GetUserList()
        {
            try
            {
                var res = await _context.Users.ToListAsync();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<User> PostLoginInfo(User users)
        {
            try
            {
                var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == users.Email && x.Password == users.Password);

                if (user == null)
                    return null;

                var tokenHandler = new JwtSecurityTokenHandler();

                var key = Encoding.ASCII.GetBytes(_appSettings.Key);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {

                    new Claim(ClaimTypes.Name , user.UserId.ToString()),
                    new Claim(ClaimTypes.Role , user.IsAdmin.ToString())

                }),
                    Expires = DateTime.UtcNow.AddDays(2),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);

                user.Password = null;
                return user;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<User> RegiserNewUser(User user)
        {
            try
            {
                user.TimeIn = DateTime.Now;
                user.TimeOut = DateTime.Now;
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<User> RetrieveUserInfo(int userId)
        {
            try
            {
                var _query = _context.Users.Where(s => s.UserId == userId).FirstOrDefaultAsync();
                return await _query;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
