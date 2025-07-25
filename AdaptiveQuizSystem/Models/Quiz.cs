using System;
using System.Collections.Generic;

namespace AdaptiveQuizSystem.Models;

public partial class Quiz
{
    public int QuizId { get; set; }

    public string Title { get; set; } = null!;

    public int SubjectId { get; set; }

    public int GradeLevel { get; set; }

    public int EasyPercent { get; set; }

    public int MediumPercent { get; set; }

    public int HardPercent { get; set; }

    public int TotalQuestions { get; set; }

    public int? TimeLimitMinutes { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<QuizQuestion> QuizQuestions { get; set; } = new List<QuizQuestion>();

    public virtual ICollection<QuizResult> QuizResults { get; set; } = new List<QuizResult>();

    public virtual Subject Subject { get; set; } = null!;
}
