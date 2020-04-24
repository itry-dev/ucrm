using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using CrmApiLogic.Interfaces;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using CrmApiLogic.Models;

namespace CrmApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private IConfiguration _config;
        private readonly JwtConfiguration _jwtConf;

        public UserController(
            IRepositoryWrapper repositoryWrapper,
            IConfiguration configuration,
            IOptions<JwtConfiguration> options) : base(repositoryWrapper)
        {
            _config = configuration;
            _jwtConf = options.Value;    
        }


        [AllowAnonymous]
        [HttpPost("token")]
        public async Task<IActionResult> Authenticate(AuthenticateModel model)
        {
            var user = await RepoWrapper.UserRepository.GetAuthToken(model.Username, model.Password, _jwtConf);

            if (user == null)
            {
                return BadRequest(new ClientErrorData{ Title = "Username or password is incorrect" });
            }                

            return Ok(
                new { Token = RepoWrapper.UserRepository.GetAuthToken(model.Username, model.Password, _jwtConf) }
            );
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            // map model to entity
            //var user = _mapper.Map<User>(model);

            //try
            //{
            //    // create user
            //    _userService.Create(user, model.Password);
            //    return Ok();
            //}
            //catch (AppException ex)
            //{
            //    // return error message if there was an exception
            //    return BadRequest(new { message = ex.Message });
            //}

            return BadRequest(new ClientErrorData { Title = "Not implemented yet" });
        }

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var users = _userService.GetAll();
        //    var model = _mapper.Map<IList<UserModel>>(users);
        //    return Ok(model);
        //}

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await RepoWrapper.UserRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(UpdateModel model)
        {
            // map model to entity and set id
            //var user = _mapper.Map<User>(model);
            //user.Id = id;

            //try
            //{
            //    // update user 
            //    _userService.Update(user, model.Password);
            //    return Ok();
            //}
            //catch (AppException ex)
            //{
            //    // return error message if there was an exception
            //    return BadRequest(new { message = ex.Message });
            //}
            return BadRequest(new ClientErrorData { Title = "Not implemented yet" });
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await RepoWrapper.UserRepository.GetById(id);
            //no clue is user does not exists
            if (user != null)
            {
                await RepoWrapper.UserRepository.Delete(user);
            }

            return Ok();
        }
    }
}
