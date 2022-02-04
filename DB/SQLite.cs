using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using ToDoAPI.Models;

namespace ToDoAPI.DB
{
    public class SQLite
    {
        public SQLiteConnection CreateConnection()
        {
            // Create a new database connection:
            string connstr = @"URI=file:C:\Users\erhan\source\repos\ToDoAPI\DB\ToDoDb.db;Version=3";//dizin belirtlmeli
            SQLiteConnection sqlite_conn = new SQLiteConnection(connstr);
            // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return sqlite_conn;
        }
        public List<Users> ReadUsersData(SQLiteConnection conn)
        {
            SQLiteDataReader datareader;
            SQLiteCommand cmd;
            List<Users> GetUserList = new List<Users>();
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Users";
            datareader = cmd.ExecuteReader();
            while (datareader.Read())
            {
                Users user = new Users();
                user.UserID = datareader.GetInt32(0);
                user.Name = datareader.GetString(1);
                user.Status = datareader.GetInt32(2);
                user.Password = datareader.GetString(3);
                GetUserList.Add(user);
            }
            return GetUserList;
        }
        public List<ToDos> ReadToDosData(SQLiteConnection conn, int id)
        {
            SQLiteDataReader datareader;
            SQLiteCommand cmd;
            List<ToDos> GetToDoList = new List<ToDos>();
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT *FROM ToDos WHERE UserID=" + id + ";";
            datareader = cmd.ExecuteReader();
            while (datareader.Read())
            {
                ToDos todo = new ToDos();
                todo.ToDoID = datareader.GetInt32(0);
                todo.ToDoText = datareader.GetString(1);
                todo.ToDoCompleted = datareader.GetInt32(2);
                todo.UserID = datareader.GetInt32(3);
                GetToDoList.Add(todo);
            }
            return GetToDoList;
        }
        //Insert
        public void ExecCommand(SQLiteConnection conn, string command)
        {
            SQLiteCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = command;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Insert Exeption");
                Console.WriteLine(ex.Message);
            }
        }
        public void CloseConnect(SQLiteConnection conn)
        {
            conn.Close();
        }
    }
}
