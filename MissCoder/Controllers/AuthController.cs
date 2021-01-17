using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MissCoder.Models;

namespace MissCoder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        [HttpPost]
        public IActionResult IsAuthendicated(AdminUser adminUser)
        {//kullanıcı kayıtlımı değil mi bakıcaz.

            bool status = false;
            if (adminUser.Email == "softengmrv68@gmail.com" && adminUser.Password == "1234")
            {
                status = true;
            }

            var result = new
            {

                status = status

            };

            return Ok(result);

        }
    }
}
