using System;
using System.Collections.Generic;

namespace AdaptiveQuizSystem.Models;

public partial class Question
{
    public int QuestionId { get; set; }

    public string Content { get; set; } = null!;

    public string OptionA { get; set; } = null!;

    public string OptionB { get; set; } = null!;

    public string OptionC { get; set; } = null!;

    public string OptionD { get; set; } = null!;

    public string CorrectAnswer { get; set; } = null!;

    public int SubjectId { get; set; }

    public int GradeLevel { get; set; }

    public string DifficultyLevel { get; set; } = null!;

    public int? TotalAttempts { get; set; }

    public int? CorrectAttempts { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<QuizQuestion> QuizQuestions { get; set; } = new List<QuizQuestion>();

    public virtual ICollection<QuizResultDetail> QuizResultDetails { get; set; } = new List<QuizResultDetail>();

    public virtual Subject Subject { get; set; } = null!;

}
