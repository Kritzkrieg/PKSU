using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ELearning.Models;

namespace ELearning.Controllers
{
    public class StudentStatsController : Controller
    {
        private StudentStatsConnection db = new StudentStatsConnection();


        public ViewResult Index()
        {
            return View();
        }

       
    }
}
