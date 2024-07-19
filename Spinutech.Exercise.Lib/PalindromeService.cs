using Spinutech.Exercise.Lib;

public class PalindromeService : IPalindromeService
{
    public bool IsPalindrome(int number)
    {
        if (number < 10)
        {
            return false;
        }

        int reversed = 0;
        int original = number;

        // Reverse the number
        while (number > 0)
        {
            int digit = number % 10;
            reversed = reversed * 10 + digit;
            number /= 10;
        }

        // Check if the original number is equal to the reversed number
        return original == reversed;
    }
}
