using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseExample.Models
{
    public class Enrollment : ObservableObject
    {
        [Key]
        public int EnrollmentId { get; set; }


        [Required]
        public Course Course { get; set; }

        [Required]
        public Student Student { get; set; }   

        [Required]
        public DateTime EnrolledAt { get; set; }

    }
}
