using System.ComponentModel.DataAnnotations;

namespace CoreApp.Models
{
    public class Assignment
    {
        // EF will instruct the database to automatically generate this value
        public int AssignmentId { get; set; }

        [Required(ErrorMessage = "Please enter assignment name.")]
        public string AssignmentName { get; set; }

        [Required(ErrorMessage = "Please enter github url.")]
        public string GitHubUrl { get; set; }
    }
}
