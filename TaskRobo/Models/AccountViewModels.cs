using System.ComponentModel.DataAnnotations;

namespace TaskRobo.Models
{
    // Create LoginViewModel and add required properties with appropriate validations

    // Email - string (required), validate email address pattern
    // Password - string (required), should display password characters instead of normal text in the field
    // RememberMe - bool, should be displayed as "Remember Me?" on the view
    public class LoginViewModel
    {
        
    }

    // Create RegisterViewModel and add required properties with appropriate validations

    // Email - string (required), validate email address pattern
    // Password - string (required), should display password characters instead of normal text in the field. Minimum length of the password should be 6 and maximum 100
    // ConfirmPassword - string (required), should display password characters instead of normal text in the field. Minimum length of the password should be 6 and maximum 100. Should match with password field
    public class RegisterViewModel
    {
        
    }
}
