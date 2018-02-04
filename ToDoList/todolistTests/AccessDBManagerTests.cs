using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;

namespace todolist.Tests
{
    [TestClass()]
    public class AccessDBManagerTests
    {
        private void InsertTaskDBTest(TaskInfo taskInfo)
        {
            var connection = @"Provider =Microsoft.Jet.OLEDB.4.0;Data Source=" + Directory.GetCurrentDirectory().Replace('/', '\\') + "..\\..\\..\\..\\todolist\\todolist.mdb";
            OleDbConnection con = new OleDbConnection(connection);
            Assert.IsNotNull(con);
            OleDbCommand cmd = new OleDbCommand("INSERT INTO tests(Title, Content, Due, Completed) values ('" +
                                                taskInfo.Title + "','" + taskInfo.Content + "','" +
                                                taskInfo.Due.ToString() + "'," + taskInfo.Completed.ToString() + ")", con);
            con.Open();
            cmd.ExecuteReader();
            con.Close();
        }
        
        private void EraseTaskDBTest(TaskInfo taskInfo)
        {
            var connection = @"Provider =Microsoft.Jet.OLEDB.4.0;Data Source=" + Directory.GetCurrentDirectory().Replace('/', '\\') + "..\\..\\..\\..\\todolist\\todolist.mdb";
            OleDbConnection con = new OleDbConnection(connection);
            OleDbCommand cmd = new OleDbCommand("DELETE FROM tests WHERE [id]=" + taskInfo.Id.ToString() + ";", con);
            con.Open();
            cmd.ExecuteReader();
            con.Close();
        }

        private void EraseTasksDBTest()
        {
            var connection = @"Provider =Microsoft.Jet.OLEDB.4.0;Data Source=" + Directory.GetCurrentDirectory().Replace('/', '\\') + "..\\..\\..\\..\\todolist\\todolist.mdb";
            OleDbConnection con = new OleDbConnection(connection);
            OleDbCommand cmd = new OleDbCommand("DELETE FROM tests WHERE [id]>=0;", con);
            con.Open();
            cmd.ExecuteReader();
            con.Close();
        }

        private void UpdateTaskDBTest(TaskInfo taskInfo)
        {
            var connection = @"Provider =Microsoft.Jet.OLEDB.4.0;Data Source=" + Directory.GetCurrentDirectory().Replace('/', '\\') + "..\\..\\..\\..\\todolist\\todolist.mdb";
            OleDbConnection con = new OleDbConnection(connection);
            OleDbCommand cmd = new OleDbCommand("UPDATE tests SET [Title]='" + taskInfo.Title + "', [Content]='" + taskInfo.Content +
                                                "', [Due]='" + taskInfo.Due.ToString() + "', [Completed]=" + taskInfo.Completed.ToString() +
                                                " WHERE [id]=" + taskInfo.Id.ToString() + ";", con);
            con.Open();
            cmd.ExecuteReader();
            con.Close();
        }

        private List<TaskInfo> GetTasksDBTest()
        {
            List<TaskInfo> taskInfos = new List<TaskInfo>();

            var connection = @"Provider =Microsoft.Jet.OLEDB.4.0;Data Source=" + Directory.GetCurrentDirectory().Replace('/', '\\') + "..\\..\\..\\..\\todolist\\todolist.mdb";
            OleDbConnection con = new OleDbConnection(connection);
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM tests", con);

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

        [TestMethod()]
        public void FindTasksFromDBTest()
        {
            EraseTasksDBTest();

            DateTime timeNow = DateTime.Now;
            Assert.IsNotNull(timeNow);

            TaskInfo taskInfo1 = new TaskInfo(0, "An awesome task", "Some data", timeNow, false);
            TaskInfo taskInfo2 = new TaskInfo(0, "A big task", "Some other data", timeNow, false);
            TaskInfo taskInfo3 = new TaskInfo(0, "Important task", "Blablabla", timeNow, false);
            Assert.IsNotNull(taskInfo1);
            Assert.IsNotNull(taskInfo2);
            Assert.IsNotNull(taskInfo3);

            List<TaskInfo> taskInfos = new List<TaskInfo>();
            Assert.IsNotNull(taskInfos);
            taskInfos.Add(taskInfo1);
            taskInfos.Add(taskInfo2);
            taskInfos.Add(taskInfo3);
            Assert.AreEqual(taskInfos.Count, 3);

            InsertTaskDBTest(taskInfo1);
            InsertTaskDBTest(taskInfo2);
            InsertTaskDBTest(taskInfo3);

            List<TaskInfo> taskInfosFromDB = GetTasksDBTest();
            Assert.IsNotNull(taskInfosFromDB);
            Assert.AreEqual(taskInfosFromDB.Count, 3);
            for (var i = 0; i < taskInfosFromDB.Count; ++i)
            {
                Assert.AreEqual(taskInfosFromDB[i].Title, taskInfos[i].Title);
                Assert.AreEqual(taskInfosFromDB[i].Content, taskInfos[i].Content);
                Assert.AreEqual(taskInfosFromDB[i].Due.ToString(), taskInfos[i].Due.ToString());
                Assert.AreEqual(taskInfosFromDB[i].Completed, taskInfos[i].Completed);
            }
        }

        [TestMethod()]
        public void InsertTaskInDBTest()
        {
            EraseTasksDBTest();

            DateTime timeNow = DateTime.Now;
            Assert.IsNotNull(timeNow);

            TaskInfo taskInfo = new TaskInfo(0, "A task", "Some data", timeNow, false);
            Assert.IsNotNull(taskInfo);

            InsertTaskDBTest(taskInfo);

            List<TaskInfo> taskInfos = GetTasksDBTest();
            Assert.IsNotNull(taskInfos);
            Assert.AreEqual(taskInfos.Count, 1);
            Assert.AreEqual(taskInfos[0].Title, taskInfo.Title);
            Assert.AreEqual(taskInfos[0].Content, taskInfo.Content);
            Assert.AreEqual(taskInfos[0].Due.ToString(), taskInfo.Due.ToString());
            Assert.AreEqual(taskInfos[0].Completed, taskInfo.Completed);

        }

        [TestMethod()]
        public void UpdateTaskInDBTest()
        {
            EraseTasksDBTest();

            DateTime timeNow = DateTime.Now;
            Assert.IsNotNull(timeNow);

            TaskInfo taskInfo = new TaskInfo(0, "A taks", "Some daat", timeNow, false);
            Assert.IsNotNull(taskInfo);

            InsertTaskDBTest(taskInfo);

            List<TaskInfo> taskInfos = GetTasksDBTest();
            Assert.IsNotNull(taskInfos);
            Assert.AreEqual(taskInfos.Count, 1);

            taskInfo.Id = taskInfos[0].Id;
            taskInfo.Title = "A task";
            taskInfo.Content = "Some data";
            taskInfo.Due = new DateTime(2018, 03, 10);
            taskInfo.Completed = true;

            UpdateTaskDBTest(taskInfo);

            List<TaskInfo> taskInfos2 = GetTasksDBTest();
            Assert.IsNotNull(taskInfos2);
            Assert.AreEqual(taskInfos2.Count, 1);
            Assert.AreEqual(taskInfos2[0].Title, taskInfo.Title);
            Assert.AreEqual(taskInfos2[0].Content, taskInfo.Content);
            Assert.AreEqual(taskInfos2[0].Due.ToString(), taskInfo.Due.ToString());
            Assert.AreEqual(taskInfos2[0].Completed, taskInfo.Completed);
        }

        [TestMethod()]
        public void DeleteTaskInDBTest()
        {
            EraseTasksDBTest();

            DateTime timeNow = DateTime.Now;
            Assert.IsNotNull(timeNow);

            TaskInfo taskInfo = new TaskInfo(0, "A task", "Some data", timeNow, false);
            Assert.IsNotNull(taskInfo);

            InsertTaskDBTest(taskInfo);

            List<TaskInfo> taskInfos = GetTasksDBTest();
            Assert.IsNotNull(taskInfos);
            Assert.AreEqual(taskInfos.Count, 1);
            Assert.AreEqual(taskInfos[0].Title, taskInfo.Title);
            Assert.AreEqual(taskInfos[0].Content, taskInfo.Content);
            Assert.AreEqual(taskInfos[0].Due.ToString(), taskInfo.Due.ToString());
            Assert.AreEqual(taskInfos[0].Completed, taskInfo.Completed);

            taskInfo = taskInfos[0];

            EraseTaskDBTest(taskInfo);

            taskInfos = GetTasksDBTest();
            Assert.IsNotNull(taskInfos);
            Assert.AreEqual(taskInfos.Count, 0);
        }
    }
}