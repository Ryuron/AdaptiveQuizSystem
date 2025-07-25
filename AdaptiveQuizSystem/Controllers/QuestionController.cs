using AdaptiveQuizSystem.Data;
using Microsoft.AspNetCore.Mvc;

namespace AdaptiveQuizSystem.Controllers
{
    public class QuestionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Đây là action cho đường dẫn: /Question/QuestionDetail
        public IActionResult QuestionDetail()
        {
            return View(); // Mặc định sẽ tìm view ở: Views/Question/QuestionDetail.cshtml
        }
    }

}
