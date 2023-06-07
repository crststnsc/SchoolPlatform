using SchoolPlatform.Models;
using SchoolPlatform.Models.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolPlatform
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static AttendanceDAL AttendanceDAL { get; private set; }
        public static UserDAL UserDAL { get; private set; }
        public static ClassDAL ClassDAL { get; private set; }
        public static GradeDAL GradeDAL { get; private set; }
        public static SpecializationDAL SpecializationDAL { get; private set; }
        public static SubjectDAL SubjectDAL { get; private set; }
        public static SubjectClassDAL SubjectClassDAL { get; private set; }
        public static StudentDAL StudentDAL { get; private set; }
        public static TeacherDAL TeacherDAL { get; private set; }

        public static SchoolDataContext schoolDataContext { get; private set; }

        public App()
        {
            schoolDataContext = new SchoolDataContext();

            AttendanceDAL = new(schoolDataContext);
            UserDAL = new(schoolDataContext);
            ClassDAL= new(schoolDataContext);
            GradeDAL = new(schoolDataContext);
            SpecializationDAL = new(schoolDataContext);
            SubjectDAL = new(schoolDataContext);
            SubjectClassDAL = new(schoolDataContext);
            StudentDAL = new(schoolDataContext);
            TeacherDAL = new(schoolDataContext);

            AttendanceDAL.GetAll();
            UserDAL.GetAll();
            ClassDAL.GetAll();
            GradeDAL.GetAll();
            SpecializationDAL.GetAll();
            SubjectDAL.GetAll();
            SubjectClassDAL.GetAll();
            StudentDAL.GetAll();
            TeacherDAL.GetAll();

            Debug.WriteLine(GradeDAL.CalculateGradeAverage(9));
        }

    }
}
