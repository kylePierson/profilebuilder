﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Data.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace Capstone.Data.DataAccess
{
    public class StudentSqlDAL : IStudentDAL
    {
        private string connectionString;
        //edit query to be long version of input
        private const string SQL_AddStudentUser = "INSERT INTO staff VALUES (@username, @firstname, @lastname, @class);";

        public StudentSqlDAL()
            : this(ConfigurationManager.ConnectionStrings["CapstoneDatabaseConnection"].ConnectionString)
        {
        }

        //Constructor
        public StudentSqlDAL(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }

        public void AddStudentUser(string username, string firstName, string lastName, string cohort)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_AddStudentUser, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@firstname", firstName);
                    cmd.Parameters.AddWithValue("@lastname", lastName);
                    cmd.Parameters.AddWithValue("@class", cohort);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public List<Student> GetAllStudents()
        {
            throw new NotImplementedException();
        }
    }
}
