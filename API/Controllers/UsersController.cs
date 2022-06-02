using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private DataContext context;
        public UsersController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<AppUser>> Get(int Id)
        {
            return await context.Users!.FindAsync(Id);
        }

        [HttpGet]
        public async Task<ActionResult<List<AppUser>>> GetAll()
        {
            return await context.Users!.ToListAsync();
        }
    }
}