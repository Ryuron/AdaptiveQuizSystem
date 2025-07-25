using System;
using System.Collections.Generic;

namespace AdaptiveQuizSystem.Models;

public partial class QuizResultDetail
{
    public int QuizResultDetailId { get; set; }

    public int QuizResultId { get; set; }

    public int QuestionId { get; set; }

    public string UserAnswer { get; set; } = null!;

    public bool IsCorrect { get; set; }

    public virtual Question Question { get; set; } = null!;

    public virtual QuizResult QuizResult { get; set; } = null!;
}
