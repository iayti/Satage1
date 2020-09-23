﻿namespace WebApi.Controllers
{
    using System.Threading.Tasks;
    using Application.ApplicationUser.Queries.GetToken;
    using Microsoft.AspNetCore.Mvc;

    using Application.Common.Models;
    using Application.Dto;

    public class LoginController :BaseApiController
    {
        [HttpPost]
        public async Task<ActionResult<ServiceResult<LoginResponse>>> Create(GetTokenQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
