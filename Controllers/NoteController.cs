using System.IO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using todonote.Data;
using todonote.Models;
using todonote.ViewModels;

namespace todonote.Controllers
{
    public class NoteController : Controller
    {
        private readonly NoteContext _context;
        private INoteRepository _noteRepository;
        private readonly IWebHostEnvironment __webHostEnvironment;
        public NoteController(INoteRepository noteRepository, IWebHostEnvironment webHostEnvironment, NoteContext context)
        {
            this._context = context;
            this._noteRepository = noteRepository;
            this.__webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View(_noteRepository.GetAllNote());
        }

        public IActionResult Details(int id)
        {
            var noteModel = _noteRepository.GetNote(id);

            if (noteModel == null)
            {
                return NotFound();
            }

            NoteDetailsViewModel model = new NoteDetailsViewModel()
            {
                Content = noteModel.Content,
                Author = noteModel.Author,
                PhotoPath = noteModel.PhotoPath,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NoteCreateViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string uniqueFileName = null;
                    if (model.Photo != null)
                    {
                        string uploadsFolder = Path.Combine(__webHostEnvironment.WebRootPath, "images");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                    }

                    Note newNote = new Note()
                    {
                        Content = model.Content,
                        Author = model.Author,
                        PhotoPath = uniqueFileName,
                    };

                    _noteRepository.Add(newNote);
                    return RedirectToAction("details", new {id = newNote.ID});
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View();
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