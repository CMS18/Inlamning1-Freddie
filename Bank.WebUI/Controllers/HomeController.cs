﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bank.WebUI.Models;
using Bank.WebUI.Models.ViewModels;

namespace Bank.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly BankRepository _repo;

        public HomeController(BankRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var vm = new CustomerAccountViewModel
            {
                Accounts = _repo.Accounts,
                Customers = _repo.Customers
            };

            return View(vm);
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
    }
}