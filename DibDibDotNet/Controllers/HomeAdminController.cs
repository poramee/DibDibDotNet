using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DibDibDotNet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DibDibDotNet.Models;
using Microsoft.EntityFrameworkCore;

namespace DibDibDotNet.Controllers
{
    public class HomeAdminController : Controller
    {
        private readonly ILogger<HomeAdminController> _logger;
        private readonly DibDibDotNetContext _context;
        public HomeAdminController(ILogger<HomeAdminController> logger, DibDibDotNetContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> HomeAdmin()
        {
            return View(await _context.Equipment.ToListAsync());
        }
    }
}