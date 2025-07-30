using System;
using System.Collections.Generic;

namespace AdaptiveQuizSystem.Models
{
    public partial class QuizResult
    {
        public int QuizResultId { get; set; }
        public int QuizId { get; set; }
        public int UserId { get; set; }
        public double Score { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Quiz Quiz { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<QuizResultDetail> QuizResultDetails { get; set; } = new List<QuizResultDetail>();
    }
}
