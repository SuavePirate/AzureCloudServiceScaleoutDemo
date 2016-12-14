using OnionTemplate.Application.Interfaces.Services;
using OnionTemplate.Application.Models.Input;
using OnionTemplate.Application.Models.Output;
using OnionTemplate.Application.Models.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace OnionTemplate.Controllers.Api
{
    public class UserController : ApiController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IHttpActionResult> CreateUser(NewUser model)
        {
            var result = await _userService.CreateUserAsync(model);
            return Json(result);
        }

        [HttpPut]
        [Route("updateImage")]
        public async Task<IHttpActionResult> UpdateImage(HttpPostedFileBase imageFile)
        {
            var result = await _userService.UpdateImageUrl(imageFile);
            return Ok();
        }
    }
}
