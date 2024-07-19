using Microsoft.AspNetCore.Mvc;
using Spinutech.Exercise.Lib;
using Spinutech.Exercise.Web.Models;

namespace Spinutech.Exercise.Web.Controllers
{
    public class ExerciseController : Controller
    {

        private readonly ILogger<ExerciseController> _logger;
        private readonly IPalindromeService _pallindromeService;

        public ExerciseController(ILogger<ExerciseController> logger, IPalindromeService pallindromeService)
        {
            _logger = logger;
            _pallindromeService = pallindromeService;
        }


        [HttpPost]
        public async Task<IActionResult> ValidateInput([FromBody] ExerciseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                               .Select(e => e.ErrorMessage)
                               .ToList();

                return BadRequest(new { errorMessages = errors });
            }

            if(model.Palindrome == null)
            {
                return BadRequest(new { errorMessages = new List<string> { "Palindrome is required" } });
            }

            if(model.Palindrome < 0)
            {
                return BadRequest(new { errorMessages = new List<string> { "Palindrome must be greater than 0" } });
            }

            bool isPalindrome = _pallindromeService.IsPalindrome(model.Palindrome.Value);
            return Ok(new { isPalindrome });
        }

    }
}
