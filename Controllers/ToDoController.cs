using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using ToDoAPI.DB;
using ToDoAPI.Models;


namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        [HttpGet("{id}")]//https://localhost:44351/api/ToDo/id
        public ActionResult GetTodos(int id)
        {
            SQLite sqlite = new SQLite();
            SQLiteConnection conn = sqlite.CreateConnection();
            List<ToDos> todos = new List<ToDos>();
            todos = sqlite.ReadToDosData(conn, id);
            sqlite.CloseConnect(conn);
            return Ok(todos);
        }

        [HttpPost] //https://localhost:44351/api/ToDo
        public void AddToDo([FromBody] ToDos todo)
        {
            SQLite sqlite = new SQLite();
            SQLiteConnection conn = sqlite.CreateConnection();
            sqlite.ExecCommand(conn, "INSERT INTO ToDos(ToDoText,ToDoCompleted,UserID) VALUES('" + todo.ToDoText + "',0," + todo.UserID + ");");
            sqlite.CloseConnect(conn);
        }

        [HttpPut]//https://localhost:44351/api/ToDo
        public void UpdateCompleted([FromBody] ToDos todo)
        {
            SQLite sqlite = new SQLite();
            SQLiteConnection conn = sqlite.CreateConnection();
            int a = todo.ToDoCompleted == 0 ? 1 : 0;
            sqlite.ExecCommand(conn, "UPDATE ToDos SET ToDoCompleted=" + a + " WHERE ToDoID=" + todo.ToDoID + ";");
            sqlite.CloseConnect(conn);
        }

        [HttpPut("{update}")]//https://localhost:44351/api/ToDo/update
        public void UpdateToDo([FromBody] ToDos todo)
        {
            SQLite sqlite = new SQLite();
            SQLiteConnection conn = sqlite.CreateConnection();
            sqlite.ExecCommand(conn, "UPDATE ToDos SET ToDoText=" + todo.ToDoText + ",UserID=" + todo.UserID + " WHERE ToDoID=" + todo.ToDoID + ";");
            sqlite.CloseConnect(conn);
        }

        [HttpDelete("{id}")]//https://localhost:44351/api/ToDo/id
        public void DeleteToDo(int id)
        {
            SQLite sqlite = new SQLite();
            SQLiteConnection conn = sqlite.CreateConnection();
            sqlite.ExecCommand(conn, "DELETE FROM ToDos WHERE ToDoID=" + id + ";");
            sqlite.CloseConnect(conn);
        }
    }
}
