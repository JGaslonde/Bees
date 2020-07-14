using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bees.WebMVC.Models;
using Bees.Entities;

namespace Bees.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static BeeListModel BeeList;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            BeeList = new BeeListModel();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    BeeList.BeeList.Add(new Bee((BeeEnum)i));
                }
            }

            return View(BeeList);
        }

        [HttpPost]
        public IActionResult Index(BeeListModel model)
        {
            if (model.Damage >= 0 && model.Damage <= 100)
            {
                BeeList.BeeList[model.Id].Damage(model.Damage);
            }
            else
            {
                _logger.LogWarning("Damage value needs to be between 0 and 100");
                ViewBag.Message = "Damage value needs to be between 0 and 100";
            }

            BeeList.Damage = 0;
            BeeList.Id = 0;
            return View(BeeList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}