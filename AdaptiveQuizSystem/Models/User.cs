﻿using System;
using System.Collections.Generic;

namespace AdaptiveQuizSystem.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Role { get; set; } = null!;

    public int GradeLevel { get; set; }

    public string CurrentLevel { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<QuizResult> QuizResults { get; set; } = new List<QuizResult>();

    public virtual ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
}
