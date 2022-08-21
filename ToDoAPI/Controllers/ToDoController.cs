using AutoMapper;
using Data.Context;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        #region Members
        private readonly IMapper mapper;
        #endregion

        #region Constructor
        public ToDoController(IMapper mapper)
        {
            this.mapper = mapper;
        }
        #endregion

        #region Methods
        [HttpGet("test")]
        public IActionResult Index()
        {
            ToDoModel a;
            using (var ctx = new ToDoContext())
            {
                var us = new UserModel() { Id = Guid.NewGuid(), UserName = "asd", CreationTime = DateTime.Now, Name = "aa", Email = "aa", Password = "asd" };
                ctx.Users.Add(us);
                ctx.SaveChanges();
                var td = new ToDoModel() { Id = Guid.NewGuid(), Text = "deneme", UserId = us.Id, CreatorId = us.Id, CreationTime = DateTime.Now };
                ctx.ToDos.Add(td);
                ctx.SaveChanges();
                a = ctx.ToDos.FirstOrDefault(x => x.Text == "deneme");
            }
            return Ok(a);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("myTodos/{userId}")]
        public IActionResult GetUserTodos(string userId)
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult AddToDo(ToDoModel todo)
        {
            todo.Id = Guid.NewGuid();
            return Ok(todo);
        }
        #endregion
    }
}
