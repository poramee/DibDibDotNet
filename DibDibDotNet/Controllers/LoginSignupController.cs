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
    public class LoginSignupController : Controller
    {
        private readonly ILogger<LoginSignupController> _logger;

        public LoginSignupController(ILogger<LoginSignupController> logger)
        {
            _logger = logger;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }
    }
}