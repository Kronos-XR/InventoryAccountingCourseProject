using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryAccountingWebApi1.Models;

namespace InventoryAccountingWebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class authUserController : ControllerBase
    {
        private readonly kronosxr_Context _context;

        public authUserController(kronosxr_Context context)
        {
            _context = context;
        }

        // GET: api/authUser
        [HttpPost, Route("auth")]
        public async Task<ActionResult<Guid>> PostUser(authUser user)
        {
            var authuser = await _context.Users.FirstOrDefaultAsync(p => p.Login == user.Login && p.Password == user.Password);
            if (authuser == null)
                return BadRequest("invalid");
            else
                return Ok(authuser.Id);
        }

    }
}

