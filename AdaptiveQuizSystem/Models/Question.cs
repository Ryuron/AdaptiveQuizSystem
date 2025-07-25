using System;
using System.Collections.Generic;

namespace AdaptiveQuizSystem.Models;

public partial class Question
{
    public int QuestionId { get; set; }

    public string Content { get; set; } = string.Empty;

    public string OptionA { get; set; } = string.Empty;

    public string OptionB { get; set; } = string.Empty;

    public string OptionC { get; set; } = string.Empty;

    public string OptionD { get; set; } = string.Empty;

    public string CorrectAnswer { get; set; } = string.Empty;

    public int SubjectId { get; set; }

    public int GradeLevel { get; set; }

    public string DifficultyLevel { get; set; } = string.Empty;

    public int TotalAttempts { get; set; } = 0;

    public int CorrectAttempts { get; set; } = 0;

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public virtual ICollection<QuizQuestion> QuizQuestions { get; set; } = new List<QuizQuestion>();

    public virtual ICollection<QuizResultDetail> QuizResultDetails { get; set; } = new List<QuizResultDetail>();
}
