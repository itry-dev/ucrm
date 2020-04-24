using System;
using CrmApiLogic.Interfaces;
using CrmApiLogic.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrmApi.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly IRepositoryWrapper RepoWrapper;

        public BaseController(IRepositoryWrapper repoWrapper)
        {
            RepoWrapper = repoWrapper;
        }
    }

    public class UserModel
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Token { get; set; }
    }

    public class AuthenticateModel
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }

    public class RegisterModel
    {

    }

    public class UpdateModel
    {

    }
}
