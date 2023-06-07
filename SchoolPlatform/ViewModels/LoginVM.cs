using SchoolPlatform.Models.BussinesLayer;
using SchoolPlatform.Models.EntityLayer;
using SchoolPlatform.Views;
using SchoolPlatform.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SchoolPlatform.ViewModels
{
    public class LoginVM
    {
        private UserBLL UserBLL { get; set; }
        public ObservableCollection<User> Users { get; set; }
        public event Action RequestClose;

        public LoginVM()
        {
            UserBLL = new UserBLL();
            Users = (UserBLL.GetAll());
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public void Login()
        {
             foreach(User user in Users)
             {
                if (user.Username == Username && user.Password == Password)
                {
                    switch (user.UserRole)
                    {
                        
                        case UserRole.Admin:
                            AdminView adminView = new();
                            adminView.Show();
                            break;
                        case UserRole.Student:
                            var student = App.StudentDAL.Get(user.UserId);
                            StudentMenuVM.Student = student;
                            StudentMenuView studentMenuView = new();
                            studentMenuView.Show();
                            break;
                        case UserRole.Teacher:
                            TeacherMenuVM.Teacher = App.TeacherDAL.Get(user.UserId);
                            TeacherMenu teacherMenu = new();
                            teacherMenu.Show();
                            break;
                        case UserRole.ClassMaster:
                            ClassMasterVM.Teacher = App.TeacherDAL.Get(user.UserId);
                            TeacherMenu _ = new();
                            _.Show();
                            break;
                    }
                    RequestClose?.Invoke();
                    return;
                }
             }
            MessageBox.Show("Incorrect name or password");
        }

        private ICommand loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                if(loginCommand== null)
                {
                    loginCommand = new RelayCommand(Login);
                }
                return loginCommand;
            }
        }
    }
}
