﻿using SchoolPlatform.Models.EntityLayer;
using SchoolPlatform.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SchoolPlatform.Views
{
    /// <summary>
    /// Interaction logic for GradeView.xaml
    /// </summary>
    public partial class GradeView : Window
    {
        public GradeView()
        {
            InitializeComponent();
            if(TeacherMenuVM.Teacher != null)
            {
                delete_button.Visibility = Visibility.Collapsed;
            }
        }

        
    }
}