using AdaptiveQuizSystem.Data;
using AdaptiveQuizSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AdaptiveQuizSystem.Controllers
{
    public class QuestionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestionController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult QuestionDetail()
        {
            return View();
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

                TempData["SuccessMessage"] = "Câu hỏi đã được tạo thành công!";
                return RedirectToAction("QuestionDetail");
            }

            ViewBag.Subjects = _context.Subjects.ToList();
            return View(model);
        }
    }
}
