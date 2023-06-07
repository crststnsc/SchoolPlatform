using SchoolPlatform.Models.DataAccessLayer;
using SchoolPlatform.Models.EntityLayer;
using SchoolPlatform.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace SchoolPlatform.Models.BussinesLayer
{
    public class UserBLL
    {
        public UserDAL UserDAL { get; set; }
        public UserBLL() {
            UserDAL = App.UserDAL;
        }

        public void AddUser(User user)
        {
            if(string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password)) {
                throw new LoginException("Username and password required");
            }
            UserDAL.Add(user);
        }

        public ObservableCollection<User> GetAll()
        {
            ObservableCollection<User> values = new(UserDAL.GetAll());
            return values;
        }

        public void UpdateUser(User user)
        {
            if(user == null)
            {
                //throw exception

            }
            UserDAL.Update(user);
        }

        public void DeleteUser(User user)
        {
            if(user == null)
            {
                //throw exception
            }
            UserDAL.Delete(user);
        }
    }
}
