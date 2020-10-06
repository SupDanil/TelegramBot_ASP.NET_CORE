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
        private string MassegeBot;
        private string UserName;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;  
        }

        public IActionResult Index()
        {
            _teleBot = new TelegramBotClient("1255618515:AAEclZ8vcKhGW45T2MOwjnYF-3NmN6LSqAg");

            ViewData["NameOfBot"] = _teleBot.GetMeAsync().Result; // ПОЛУЧАЕМ ИМЯ БОТА

            _teleBot.StartReceiving(); /*СЛУШАЕМ СООБЩЕНИЯ ОТ СЕРВЕРА ТЕЛЕГРАМА ЕСЛИ ОНИ ПОСТУПЯТ*/

            _teleBot.OnMessage += TeleBotReceived; // СОЗДАЕМ СОБЫТИЕ ПРИ ПОЛУЧЕНИИ СООБЩЕНИЯ 

            ViewData["BotMassage"] = MassegeBot;


            return View();
        }

        private void TeleBotReceived(object sender, Telegram.Bot.Args.MessageEventArgs e) // САМО СОБЫТИЕ ПРИ ПОЛУЧЕНИИ СООБЩЕНИЯ 
        {
           var BotContext =  e.Message; // СОЗДАЕМ КОНТЕКТ ДЛЯ РАБОТЫ С ВХОДЯЩИМИ СООБЩЕНИЯМИ  e.Message

            string User = $"{BotContext.From.FirstName} {BotContext.From.LastName}"; // ПОЛУЧАЕМ ИМЯ И ФАМИЛИЮ ПОЛЬЗОВАТЕЛЯ BotContext.From.FirstName

            MassegeBot = BotContext.Text;  // ПОЛУЧАЕМ СООБЩЕНИЯ ПОЛЬЗОВАТЕЛЯ BotContext.Text
        }
    }
}
