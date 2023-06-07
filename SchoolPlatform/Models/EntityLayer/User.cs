using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models.EntityLayer
{
    public enum UserRole {
        Admin,
        Teacher,
        ClassMaster,
        Student
    }

    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole UserRole { get; set; }
        public int UserId { get; set; }
    }
}
