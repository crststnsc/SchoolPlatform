using Microsoft.Data.SqlClient;
using SchoolPlatform.Models.DataAccessLayer;
using SchoolPlatform.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models.BussinesLayer
{
    public class StudentBLL
    {
        public StudentDAL StudentDAL { get; set; }

        public StudentBLL()
        {
            StudentDAL = App.StudentDAL;
        }

        public void AddStudent(Student student)
        {
            if (student.FirstName == null || student.LastName == null || student.Class == null)
            {
                throw new Exception("Name, lastname and class required");
            }
            //use sqlconnection and InsertStudent stored procedure


            using (SqlConnection connection = DALHelper.Connection)
            {
                using (SqlCommand command = new SqlCommand("InsertStudent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = student.FirstName;
                    command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = student.LastName;
                    command.Parameters.Add("@ClassId", SqlDbType.Int).Value = student.Class.Id;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Student> GetAll()
        {
            List<Student> values = new(StudentDAL.GetAll());
            return values;
        }

        public void UpdateStudent(Student student)
        {
            if (student == null)
            {
                //throw exception

            }
            StudentDAL.Update(student);
        }

        public void DeleteStudent(Student student)
        {
            if (student == null)
            {
                //throw exception
            }
            StudentDAL.Delete(student);
        }
    }
}
