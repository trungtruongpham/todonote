using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using todonote.Data;
using todonote.Models;

namespace todonote.Controllers
{
    public class NoteController : Controller
    {
        private readonly NoteContext _context;
        private INoteRepository _noteRepository;
        public NoteController(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public IActionResult Index()
        {
            return View(_noteRepository.GetAllNote());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noteModel = await _context.Notes
                .FirstOrDefaultAsync(m => m.ID == id);

            if (noteModel == null)
            {
                return NotFound();
            }

            return View(noteModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Content,Author")] Note newNote)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _noteRepository.Add(newNote);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(newNote);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noteToUpdate = await _context.Notes.FirstOrDefaultAsync(n => n.ID == id);
            if (await TryUpdateModelAsync<Note>(
                    noteToUpdate,
                    "",
                    n => n.Content, n => n.Author))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(noteToUpdate);
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        public async Task<IActionResult> Delete(int? id, bool? saveChangeError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = await _context.Notes.AsNoTracking().FirstOrDefaultAsync(n => n.ID == id);
            if (note == null)
            {
                return NotFound();
            }

            if (saveChangeError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] = "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(note);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var noteToDelete = await _context.Notes.FirstOrDefaultAsync(n => n.ID == id);
            if (noteToDelete == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.Notes.Remove(noteToDelete);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }

        }
    }
}