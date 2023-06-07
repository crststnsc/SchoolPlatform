using SchoolPlatform.Models.BussinesLayer;
using SchoolPlatform.Models.DataAccessLayer;
using SchoolPlatform.Models.EntityLayer;
using SchoolPlatform.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolPlatform.ViewModels
{
    public class ClassVM
    {
        ClassBLL ClassBLL { get; set; }
        public ObservableCollection<Class> Classes { get; set; }
        public List<Specialization> Specializations { get; set; }
        public List<Teacher> Teachers { get; set; }

        public ClassVM()
        {
            ClassBLL = new();           
            Classes = ClassBLL.GetAll();
            Specializations = new(App.SpecializationDAL.GetAll());

            List<User> Users = new(App.UserDAL.GetAll());
            List<User> classMasterUsers = Users.Where(user => user.UserRole == UserRole.ClassMaster).ToList();
            Teachers = App.TeacherDAL.GetAll().Where(teacher => classMasterUsers.Any(user => user.UserId == teacher.Id)).ToList();
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new GenericRelayCommand<Class>(@class =>
                    {
                        ClassBLL.AddClass(@class);
                        Classes.Add(@class);
                    });
                }
                return addCommand;
            }
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new GenericRelayCommand<Class>(@class =>
                    {
                        ClassBLL.UpdateClass(@class);
                    });
                }
                return updateCommand;
            }
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new GenericRelayCommand<Class>(@class =>
                    {
                        ClassBLL.DeleteClass(@class);
                        Classes.Remove(@class);
                    });
                }
                return deleteCommand;
            }
        }
    }
}

