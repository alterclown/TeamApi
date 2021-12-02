using ReactAngularPracticeApi.Data.Entities;
using ReactAngularPracticeApi.Repository.AuthenticationRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactAngularPracticeApi.Service.AuthenticationService
{
    public interface IAuthenticationService
    {
        Task<List<User>> GetUserList();
        Task<User> RetrieveUserInfo(int userId);
        Task<User> PostLoginInfo(User users);
        Task<User> RegiserNewUser(User user);
    }

    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _repository;
        public AuthenticationService(IAuthenticationRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<User>> GetUserList()
        {
            try
            {
                var res = await _repository.GetUserList();
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
                var res = await _repository.PostLoginInfo(users);
                return res;

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
                var res = await _repository.RegiserNewUser(user);
                return res;

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
                var res = await _repository.RetrieveUserInfo(userId);
                return res;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
