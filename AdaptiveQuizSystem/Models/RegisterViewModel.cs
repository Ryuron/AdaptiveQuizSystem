namespace AdaptiveQuizSystem.Models
{
    public class RegisterViewModel
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int GradeLevel { get; set; }
        public string CurrentLevel { get; set; } = string.Empty;
    }
}
