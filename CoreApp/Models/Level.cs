using System.ComponentModel.DataAnnotations;

namespace CoreApp.Models
{
    public class Level
    {
        public int LevelId { get; set; }

        [Required(ErrorMessage = "Please enter a level name.")]
        public string Name { get; set; }
    }
}
