using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DatabaseExample.Database;
using DatabaseExample.Models;
using DatabaseExample.Utils;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DatabaseExample.ViewModels
{
    public class StudentViewModel : ObservableObject
    {

        private readonly ILogger<StudentViewModel> _logger;
        private readonly StudentContext _studentContext;
        public ObservableCollection<Student> Students { get; set; }
        public Student? SelectedStudent { get; set; } = null;


        public StudentViewModel(ILogger<StudentViewModel> logger, StudentContext studentContext)
        {
            _logger = logger;
            _studentContext = studentContext;
            refresh();
        }


        /// <summary>
        /// Clears all the students from the list and reloads them from the database
        /// </summary>
        private void refresh()
        {
            // Clear selection and get students from DbSet
            //this._studentContext.
            this.Students = new ObservableCollection<Student>(_studentContext.Students);
            this.SelectedStudent = null;

            _logger.LogInformation("Reload students");
        }


        /// <summary>
        /// Saves all the students changes to the database  
        /// </summary>
        /// <param name="fileName">Full file path</param>
        private void saveData()
        {
            this._studentContext.SaveChanges();
        }


        /// <summary>
        /// Add a new student to the database
        /// </summary>
        private void addStudent()
        {
            // __TODO__ [PSMG] Fix better binding in DbSet
            this.SelectedStudent = new Student();
            this._studentContext.Students.Add(SelectedStudent);
            this.Students.Add(this.SelectedStudent);
        }

        /// <summary>
        /// Remove the selected student from the database
        /// </summary>
        private void removeStudent()
        {
            if (SelectedStudent == null)
                return;

            // __TODO__ find a better way to remove
            this._studentContext.Students.Remove(SelectedStudent);
            this.Students.Remove(SelectedStudent);
            SelectedStudent = null;
        }


        #region Commands binding

        private ICommand mSaveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (mSaveCommand == null)
                {
                    mSaveCommand = new RelayCommand(saveData);
                }
                return mSaveCommand;

            }
        }

        public ICommand mLoadCommand;
        public ICommand LoadCommand
        {
            get
            {
                if (mLoadCommand == null)
                {
                    mLoadCommand = new RelayCommand(refresh);
                }
                return mLoadCommand;
            }
        }


        public ICommand mAddCommand;
        public ICommand AddCommand
        {
            get
            {
                if (mAddCommand == null)
                {
                    mAddCommand = new RelayCommand(addStudent);
                }
                return mAddCommand;
            }
        }

        public ICommand mDeleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (mDeleteCommand == null)
                {
                    // __TODO__ [PSMG] Add Action to avoid removal of non selection
                    mDeleteCommand = new RelayCommand(removeStudent);
                }
                return mDeleteCommand;
            }
        }

        #endregion 


    }
}
