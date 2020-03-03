using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using todonote.Models;


namespace todonote.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private NoteListManager noteListManager;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            noteListManager = new NoteListManager();
        }

        public IActionResult Index()
        {
            IEnumerable<Note> noteList = noteListManager.GetAllNote();
            return View(noteList);
        }

        [HttpPost]
        public IActionResult Index(Note note){
            return View(note);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AddNote(){
            return View();
        }

        public IActionResult UpdateNote(int Id){
            Note model = noteListManager.GetNote(Id);
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateNote(Note note){
            if(ModelState.IsValid){
                noteListManager.UpdateNote(note);
                RedirectToAction("/Index");
            }
            return View();
        }
    }
}
