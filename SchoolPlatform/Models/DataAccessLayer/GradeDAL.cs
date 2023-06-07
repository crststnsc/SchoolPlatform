using Microsoft.Data.SqlClient;
using SchoolPlatform.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models.DataAccessLayer
{
    public class GradeDAL : BaseDAL<Grade>
    { 
        public GradeDAL(SchoolDataContext context) : base(context)
        {
        }

        public decimal CalculateGradeAverage(int studentId)
        {
            using SqlConnection connection = DALHelper.Connection;
            using SqlCommand command = new("CalculateGradeAverage", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StudentId", SqlDbType.Int).Value = studentId;
            command.Parameters.Add("@Average", SqlDbType.Decimal).Direction = ParameterDirection.Output;

            connection.Open();
            command.ExecuteNonQuery();


            decimal average = 0;
            if (command.Parameters["@Average"].Value != DBNull.Value)
            {
                average = (decimal)command.Parameters["@Average"].Value;
                // Do something with the calculated average
            }
            return average;
        }
    }
}
