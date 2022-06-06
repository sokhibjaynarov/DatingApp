using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class UsersController : BaseApiController
    {
        private DataContext context;
        public UsersController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet("{Id}")]
        [Authorize]
        public async Task<ActionResult<AppUser>> Get(int Id)
        {
            return await context.Users!.FindAsync(Id);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<AppUser>>> GetAll()
        {
            return await context.Users!.ToListAsync();
        }
    }
}