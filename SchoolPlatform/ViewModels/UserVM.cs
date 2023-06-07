using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SchoolPlatform.Models.BussinesLayer;
using SchoolPlatform.Models.EntityLayer;
using SchoolPlatform.ViewModels.Commands;

namespace SchoolPlatform.ViewModels
{
    public class UserVM
    {
        UserBLL UserBLL { get; set; }
        public ObservableCollection<User> Users { get; set; }

        public UserVM()
        {
            UserBLL = new();
            Users = UserBLL.GetAll();
        }
        
        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if(addCommand == null)
                {
                    addCommand = new GenericRelayCommand<User>(user =>
                    {
                        UserBLL.AddUser(user);
                        Users.Add(user);
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
                if(updateCommand == null)
                {
                    updateCommand = new GenericRelayCommand<User>(user => 
                    { 
                        UserBLL.UpdateUser(user);
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
                if(deleteCommand == null)
                {
                    deleteCommand = new GenericRelayCommand<User>(user =>
                    {
                        UserBLL.DeleteUser(user);
                        Users.Remove(user);
                    });
                }
                return deleteCommand;
            }
        }
    }
}
