using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CoreApp.Models;

namespace CoreApp.Models
{
    public class Student
    {
        // EF will instruct the database to automatically generate this value
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Please enter first name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter grade.")]
        public int Grade { get; set; }
    }
}