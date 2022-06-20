using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        // [HttpGet("{Id}")]
        // public async Task<ActionResult<MemberDto>> GetById(int Id)
        // {
        //     var user = await userRepository.GetUserByIdAsync(Id); 
        //     return Ok(mapper.Map<MemberDto>(user));
        // }

        [HttpGet("{username}")]
        public async Task<ActionResult<AppUser>> GetByUsername(string username)
        {
            var user = await userRepository.GetUserByUsernameAsync(username);
            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<List<MemberDto>>> GetAll()
        {
            var users = await userRepository.GetUsersAsync();
            return Ok(mapper.Map<List<MemberDto>>(users));
        }
    }
}