using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactAngularPracticeApi.Data.Entities;
using ReactAngularPracticeApi.Service.AuthenticationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactAngularPracticeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _service;

        public AuthenticationController(IAuthenticationService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetUserList")]
        public async Task<IActionResult> GetAllUserInfo()
        {
            try
            {
                var res = await _service.GetUserList();
                if (res != null)
                {
                    return Ok(res);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        [Route("GetUserById/{userId}")]
        public async Task<IActionResult> RetrieveUserInfo(int userId)
        {
            try
            {
                var res = await _service.RetrieveUserInfo(userId);
                if (res != null)
                {
                    return Ok(res);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region Login and Registration End Point
        [HttpPost]
        [Route("PostUserLoginCredential")]
        public async Task<IActionResult> PostLoginInfo(User users)
        {
            try
            {
                var res = await _service.PostLoginInfo(users);
                if (res != null)
                {
                    return Ok(res);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("RegisterNewUser")]
        public async Task<IActionResult> MakeRegistration(User user)
        {
            try
            {
                var res = await _service.RegiserNewUser(user);
                if (res != null)
                {
                    return Ok(res);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }

}
