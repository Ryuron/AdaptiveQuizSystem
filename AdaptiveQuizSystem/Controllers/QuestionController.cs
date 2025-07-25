using AdaptiveQuizSystem.Data;
using AdaptiveQuizSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdaptiveQuizSystem.Controllers
{
    public class QuestionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Question/QuestionDetail
        public IActionResult QuestionDetail()
        {
            return View(); // Mặc định tìm View: Views/Question/QuestionDetail.cshtml
        }
        public IActionResult Create()
        {
            ViewBag.Subjects = _context.Subjects.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Question model)
        {
            if (ModelState.IsValid)
            {
                var question = new Question
                {
                    Content = model.Content,
                    OptionA = model.OptionA,
                    OptionB = model.OptionB,
                    OptionC = model.OptionC,
                    OptionD = model.OptionD,
                    CorrectAnswer = model.CorrectAnswer,
                    SubjectId = model.SubjectId,
                    GradeLevel = model.GradeLevel,
                    DifficultyLevel = model.DifficultyLevel,
                    CreatedAt = DateTime.Now
                };

                _context.Questions.Add(question);
                await _context.SaveChangesAsync();

                return RedirectToAction("QuestionDetail");
            }

            // Nếu lỗi, nạp lại danh sách Subject (Lưu ý KHÔNG dùng SelectList ở đây)
            ViewBag.Subjects = _context.Subjects.ToList();

            return View(model);
        }

    }
}
