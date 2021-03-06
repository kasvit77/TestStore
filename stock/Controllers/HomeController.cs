﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using stock.Models;
using Microsoft.EntityFrameworkCore;

namespace stock.Controllers
{
    public class HomeController : Controller
    {
       
     
        public IActionResult About()
        {
            ViewData["Message"] = "Задание";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Контакты";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

       
        public IActionResult Index()
        {
            ViewData["Message"] = "Главная страница";
            return View();
        }
       
    
       


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
