using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using lab3.Data;
using lab3.Models;

namespace lab3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DatabaseContext DbContext;

        public UserController(DatabaseContext DbContext)
        {
            this.DbContext = DbContext;
        }

        // Get All Users
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(DbContext.UserEntityMapping.ToList());
        }

        // Get User by id
        [HttpGet("{UserId}")]
        public IActionResult GetUserByUserId(String UserId)
        {
            var queryResult = DbContext.UserEntityMapping.Where(item => item.id == UserId);
            if (queryResult.Count() > 0)
            {
                return Ok(queryResult);
            }
            return BadRequest("No user for this id!");
        }

        [HttpPost]
        public IActionResult AddNewUser(UserEntity userEntity)
        {
            var newUser = new UserEntity()
            {
                id = Guid.NewGuid().ToString(),
                name = userEntity.name,
                email = userEntity.email,
                status = userEntity.status
            };
            DbContext.Add(newUser);
            DbContext.SaveChanges();
            return Ok(newUser);
        }
    }
}