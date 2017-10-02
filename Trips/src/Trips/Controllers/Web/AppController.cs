using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trips.ViewModels;
using Trips.Services;
using Microsoft.Extensions.Configuration;
using Trips.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Trips.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService mailService;
        private IConfigurationRoot config;
        private TripsContext context;
        public AppController(IMailService mailService, IConfigurationRoot config, TripsContext context)
        {
            this.mailService = mailService;
            this.config = config;
            this.context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var data = this.context.Trips.ToList();
            return View(data);
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact (ContactViewModel model)
        {
            if (model.Email.Contains("asd.com"))
            {
                ModelState.AddModelError("", "We don't support ASD addresses");
            }
            if (ModelState.IsValid)
            {
                this.mailService.SendMail(this.config["MailSettings:ToAddress"], model.Email, "From Trips", model.Message);
                ModelState.Clear();
                ViewBag.UserMessage = "Message Sent";
            }
            
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
