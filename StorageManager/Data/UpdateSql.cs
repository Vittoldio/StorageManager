﻿using Microsoft.SqlServer.Server;
using StorageManager.Enumirations;
using StorageManager.TaskManager;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageManager.Data
{
    class UpdateSql
    {
        const string connectionString = @"Data Source=HOME-PC;Initial Catalog=Storage;Integrated Security=True";
        public void Add_login_password(string login, string password)
        {
            //List<string> result = new List<string>();
            Encryption encrypt = new Encryption();
            string expressionString =
                //String.Format($"INSERT INTO Users (Login, Password) VALUES('{login}','{encrypt.EncryptText(password)}')");
                String.Format($"INSERT INTO Users (Login, Password) VALUES('{login}','{password}')");
            // Создание подключения
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                // Открываем подключение
                connection.Open();
                SqlCommand command = new SqlCommand(expressionString, connection);
                int number = command.ExecuteNonQuery();  
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // закрываем подключение
                connection.Close();
            }
        }

        public void Remove_login_password(string login)
        {
            //List<string> result = new List<string>();
            Encryption encrypt = new Encryption();
            string expressionString =
                //String.Format($"INSERT INTO Users (Login, Password) VALUES('{login}','{encrypt.EncryptText(password)}')");
                String.Format($"DELETE FROM Users WHERE login = {login}");
            // Создание подключения
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                // Открываем подключение
                connection.Open();
                SqlCommand command = new SqlCommand(expressionString, connection);
                int number = command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // закрываем подключение
                connection.Close();
            }
        }

        public void AddTask(Task_ inputData)
        {
            //List<string> result = new List<string>();
            Encryption encrypt = new Encryption();
            string expressionString =
                String.
                Format($"INSERT INTO Tasks (TaskOwner, TaskPerformer, TaskType) VALUES('{inputData.TaskOwner}','{inputData.TaskPerfomer}','{(int)inputData.TaskType}')");
            // Создание подключения
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                // Открываем подключение
                connection.Open();
                SqlCommand command = new SqlCommand(expressionString, connection);
                int number = command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // закрываем подключение
                connection.Close();
            }
        }

        public void RemoveTask(Task_ inputData)
        {

        }
        public void RemoveTask_ByPerformer(string taskPerformer)
        {

        }
        public void RemoveTask_ByPerformer(Task_ taskPerformer)
        {

        }

        public void RemoveTask_ByTaskType(TaskType taskType)
        {

        }
        public void RemoveTask_ByOwner(string taskOwner)
        {

        }
        public void RemoveTask_ByOwner(Task_ taskOwner)
        {

        }
    }
}