using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TelegramBot_CORE_.Models;
using Telegram.Bot;

namespace TelegramBot_CORE_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private TelegramBotClient _teleBot;

        public HomeController(ILogger<HomeController> logger,TelegramBotClient telegram)
        {
            _logger = logger;
            _teleBot = telegram;
        }

        public IActionResult Index()
        {
            _teleBot = new TelegramBotClient("1255618515:AAEclZ8vcKhGW45T2MOwjnYF-3NmN6LSqAg");

            ViewData["NameOfBot"] = _teleBot.GetMeAsync().Result; // ПОЛУЧАЕМ ИМЯ БОТА

            return View();
        }


    }
}
