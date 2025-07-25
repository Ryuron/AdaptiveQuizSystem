using AdaptiveQuizSystem.Data;
using AdaptiveQuizSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdaptiveQuizSystem.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 📋 Danh sách môn học
        public IActionResult SubjectList()
        {
            var subjects = _context.Subjects.ToList();
            return View(subjects); // Views/Subject/SubjectList.cshtml
        }

        // ➕ Hiển thị form tạo mới
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tạo mới
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Subject subject)
        {
            if (ModelState.IsValid)
            {
                _context.Subjects.Add(subject);
                _context.SaveChanges();
                return RedirectToAction("SubjectList");
            }
            return View(subject);
        }

        // ✏️ Hiển thị form sửa
        public IActionResult Edit(int id)
        {
            var subject = _context.Subjects.Find(id);
            if (subject == null) return NotFound();
            return View(subject);
        }

        // POST: Cập nhật
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Subject subject)
        {
            if (ModelState.IsValid)
            {
                _context.Subjects.Update(subject);
                _context.SaveChanges();
                return RedirectToAction("SubjectList");
            }
            return View(subject);
        }

        // ❌ Hiển thị form xác nhận xóa
        public IActionResult Delete(int id)
        {
            var subject = _context.Subjects.Find(id);
            if (subject == null) return NotFound();
            return View(subject);
        }

        // POST: Xoá
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var subject = _context.Subjects.Find(id);
            if (subject != null)
            {
                _context.Subjects.Remove(subject);
                _context.SaveChanges();
            }
            return RedirectToAction("SubjectList");
        }
    }
}
