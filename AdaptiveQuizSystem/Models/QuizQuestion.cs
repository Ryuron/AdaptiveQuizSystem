using System;
using System.Collections.Generic;

namespace AdaptiveQuizSystem.Models;

public partial class QuizQuestion
{
    public int QuizQuestionId { get; set; }

    public int QuizId { get; set; }

    public int QuestionId { get; set; }

    public virtual Question Question { get; set; } = null!;

    public virtual Quiz Quiz { get; set; } = null!;
}
