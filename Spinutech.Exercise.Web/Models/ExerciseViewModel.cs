using System.ComponentModel.DataAnnotations;

namespace Spinutech.Exercise.Web.Models
{
    public class ExerciseViewModel
    {
        [Required(ErrorMessage = "Palindrome is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Palindrome must be a non-negative number.")]
        public int? Palindrome { get; set; }
    }
}
