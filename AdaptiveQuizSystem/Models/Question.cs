using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdaptiveQuizSystem.Models
{
    public partial class Question
    {
        public int QuestionId { get; set; }

        [Required(ErrorMessage = "Nội dung câu hỏi là bắt buộc")]
        [Display(Name = "Nội dung câu hỏi")]
        public string Content { get; set; } = string.Empty;

        [Required(ErrorMessage = "Lựa chọn A là bắt buộc")]
        [Display(Name = "Lựa chọn A")]
        public string OptionA { get; set; } = string.Empty;

        [Required(ErrorMessage = "Lựa chọn B là bắt buộc")]
        [Display(Name = "Lựa chọn B")]
        public string OptionB { get; set; } = string.Empty;

        [Required(ErrorMessage = "Lựa chọn C là bắt buộc")]
        [Display(Name = "Lựa chọn C")]
        public string OptionC { get; set; } = string.Empty;

        [Required(ErrorMessage = "Lựa chọn D là bắt buộc")]
        [Display(Name = "Lựa chọn D")]
        public string OptionD { get; set; } = string.Empty;

        [Required(ErrorMessage = "Đáp án đúng là bắt buộc")]
        [Display(Name = "Đáp án đúng")]
        public string CorrectAnswer { get; set; } = string.Empty;

        [Required(ErrorMessage = "Môn học là bắt buộc")]
        public int SubjectId { get; set; }

        [Required(ErrorMessage = "Cấp độ lớp là bắt buộc")]
        [Range(1, 12, ErrorMessage = "Cấp độ lớp phải từ 1 đến 12")]
        public int GradeLevel { get; set; }

        [Required(ErrorMessage = "Mức độ khó là bắt buộc")]
        public string DifficultyLevel { get; set; } = string.Empty;

        public int TotalAttempts { get; set; } = 0;
        public int CorrectAttempts { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation property - THIS WAS MISSING
        public virtual Subject Subject { get; set; } = null!;

        public virtual ICollection<QuizQuestion> QuizQuestions { get; set; } = new List<QuizQuestion>();
        public virtual ICollection<QuizResultDetail> QuizResultDetails { get; set; } = new List<QuizResultDetail>();
    }
}
