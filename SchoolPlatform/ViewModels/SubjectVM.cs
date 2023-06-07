using SchoolPlatform.Models.BussinesLayer;
using SchoolPlatform.Models.EntityLayer;
using SchoolPlatform.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolPlatform.ViewModels
{
    public class SubjectVM
    {
        SubjectBLL SubjectBLL { get; set; }
        public ObservableCollection<Subject> Subjects { get; set; }

        public SubjectVM()
        {
            SubjectBLL = new();
            Subjects = SubjectBLL.GetAll();
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new GenericRelayCommand<string>(name =>
                    {
                        Subject subject = new()
                        {
                            Name = name
                        };
                        SubjectBLL.AddSubject(subject);
                        Subjects.Add(subject);
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
                    updateCommand = new GenericRelayCommand<Subject>(subject =>
                    {
                        SubjectBLL.UpdateSubject(subject);
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
                    deleteCommand = new GenericRelayCommand<Subject>(subject =>
                    {
                        SubjectBLL.DeleteSubject(subject);
                        Subjects.Remove(subject);
                    });
                }
                return deleteCommand;
            }
        }
    }
}
