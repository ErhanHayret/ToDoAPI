using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoAPI.DB;
using ToDoAPI.Models;
using System.Data.SQLite;

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]//https://localhost:44351/api/User
        public ActionResult GetUsers()
        {
            SQLite SQLite = new SQLite();
            SQLiteConnection conn = SQLite.CreateConnection();
            List<Users> users = new List<Users>();
            users = SQLite.ReadUsersData(conn);
            SQLite.CloseConnect(conn);
            return Ok(users);
        }

        [HttpPost("{addusr}")]//https://localhost:44351/api/User/addusr
        public void NewUser(Users addusr)
        {
            SQLite SQLite = new SQLite();
            SQLiteConnection conn = SQLite.CreateConnection();
            List<Users> users = new List<Users>();
            users = SQLite.ReadUsersData(conn);
            int cnt = users.Count + 1;
            SQLite.ExecCommand(conn, "INSERT INTO Users VALUES(" + cnt + ",'" + addusr.Name + "'," + addusr.Status + ",'" + addusr.Password + "');");
            SQLite.CloseConnect(conn);
        }
    }
}
