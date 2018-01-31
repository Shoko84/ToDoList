using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todolist
{
    public class AccessDBManager
    {
        static public List<TaskInfo> FindTasksFromDB()
        {
            List<TaskInfo> taskInfos = new List<TaskInfo>();

            var connection = @"Provider =Microsoft.Jet.OLEDB.4.0;Data Source=" + Directory.GetCurrentDirectory().Replace('/', '\\') + "..\\..\\..\\todolist.mdb";
            OleDbConnection con = new OleDbConnection(connection);
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM todolist", con);

            con.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                taskInfos.Add(new TaskInfo(Convert.ToUInt32(reader["id"]), Convert.ToString(reader["Title"]),
                                           Convert.ToString(reader["Content"]), Convert.ToDateTime(reader["Due"]), Convert.ToBoolean(reader["Completed"])));
            }
            reader.Close();
            con.Close();

            return (taskInfos);
        }

        static public void InsertTaskInDB(TaskInfo taskInfo)
        {
            var connection = @"Provider =Microsoft.Jet.OLEDB.4.0;Data Source=" + Directory.GetCurrentDirectory().Replace('/', '\\') + "..\\..\\..\\todolist.mdb";
            OleDbConnection con = new OleDbConnection(connection);
            OleDbCommand cmd = new OleDbCommand("INSERT INTO todolist(Title, Content, Due, Completed) values ('" +
                                                taskInfo.Title + "','" + taskInfo.Content + "','" +
                                                taskInfo.Due.ToString() + "'," + taskInfo.Completed.ToString() + ")", con);
            con.Open();
            cmd.ExecuteReader();
            con.Close();
        }

        static public void UpdateTaskInDB(TaskInfo taskInfo)
        {
            var connection = @"Provider =Microsoft.Jet.OLEDB.4.0;Data Source=" + Directory.GetCurrentDirectory().Replace('/', '\\') + "..\\..\\..\\todolist.mdb";
            OleDbConnection con = new OleDbConnection(connection);
            OleDbCommand cmd = new OleDbCommand("UPDATE todolist SET [Title]='" + taskInfo.Title + "', [Content]='" + taskInfo.Content +
                                                "', [Due]='" + taskInfo.Due.ToString() + "', [Completed]=" + taskInfo.Completed.ToString() +
                                                " WHERE [id]=" + taskInfo.Id.ToString() + ";", con);
            con.Open();
            cmd.ExecuteReader();
            con.Close();
        }

        static public void DeleteTaskInDB(TaskInfo taskInfo)
        {
            var connection = @"Provider =Microsoft.Jet.OLEDB.4.0;Data Source=" + Directory.GetCurrentDirectory().Replace('/', '\\') + "..\\..\\..\\todolist.mdb";
            OleDbConnection con = new OleDbConnection(connection);
            OleDbCommand cmd = new OleDbCommand("DELETE FROM todolist WHERE [id]=" + taskInfo.Id.ToString() + ";", con);
            con.Open();
            cmd.ExecuteReader();
            con.Close();
        }
    }
}
