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

        // Check whether the user with the id is existing 
        private (bool isExist, UserEntity user) IsUserExist(String UserId)
        {
            var queryResult = DbContext.UserEntityMapping.Where(item => item.id == UserId);
            if (queryResult.Count() > 0)
            {
                return (true, queryResult.First());
            }
            return (false, new UserEntity());
        }

        // Get User by id
        [HttpGet("{UserId}")]
        public IActionResult GetUserByUserId(String UserId)
        {
            var isUserExist = IsUserExist(UserId);
            if (isUserExist.isExist)
            {
                return Ok(new List<UserEntity>() { isUserExist.user });
            }
            return BadRequest("No user with this id!");
        }

        // Add New User
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

        // Update existing user by id
        [HttpPut]
        public IActionResult UpdateUserByUserId(UserEntity userEntity)
        {
            var isUserExist = IsUserExist(userEntity.id);
            if (isUserExist.isExist)
            {
                isUserExist.user.name = userEntity.name;
                isUserExist.user.email = userEntity.email;
                isUserExist.user.status = userEntity.status;
                DbContext.SaveChanges();
                return Ok(userEntity);
            }
            return BadRequest("The update user's id is invalid!");
        }
    }
}