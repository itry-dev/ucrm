using System;
using CrmApiLogic.Interfaces;
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
}
