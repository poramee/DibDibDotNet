using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DibDibDotNet.Models;

namespace DibDibDotNet.Controllers
{
    public class HomeUserController : Controller
    {
        private readonly ILogger<HomeUserController> _logger;

        public HomeUserController(ILogger<HomeUserController> logger)
        {
            _logger = logger;
        }

        public IActionResult HomeUser()
        {
            return View();
        }
    }
}