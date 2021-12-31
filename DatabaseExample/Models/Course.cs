using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseExample.Models
{
    public class Course : ObservableObject
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        public string CourseName { get; set; }




    }
}
