using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseExample.Models
{
    public class Student : ObservableObject
    {
        [Key]
        public int StudentNumber { get; set; }

        [Required]
        public string FirstName { get; set; } 

        [Required]
        public string LastName { get; set; }

        public string FullName { get { return String.Format($"{FirstName} {LastName}");  } }
        
        [Required]
        public DateTime Birthday { get; set; }

        public int Age => (int)((DateTime.Now - Birthday).Days / 365.25);

        public string? Address { get; set; }

        public int? HouseNr { get; set; }

        public string? City { get; set; }

        public string? ZipCode { get; set; } 




    }
}
