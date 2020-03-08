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
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login(){
            return View();
        }
    }
}