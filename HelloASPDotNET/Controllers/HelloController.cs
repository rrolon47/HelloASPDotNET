using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelloASPDotNET.Controllers
{
    public class HelloController : Controller
    {
        public static string CreateMessage(string name, string language)
        {
            string msg = "";

            if (String.IsNullOrEmpty(language) && String.IsNullOrEmpty(name))
            {
                msg = $"Welcome to my app, World!";
            }
            else if (language.Equals("en"))
            {
                msg = $"Welcome to my app, {name}!";
            }
            else if (language.Equals("fr"))
            {
               msg = $"Bonjour, {name}!";
            }
            else if (language.Equals("sp"))
            {
                msg = $"¡Buenvinidos a mi app, {name}!";

            }
            return msg;
        }
        
       //GET: /<hello>/
       [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
        //POST: hello
        [HttpPost]
        [Route("/hello")]
         public IActionResult Welcome(string name = "World" , string language = "en")
         {
            ViewBag.message = CreateMessage(name, language);
            return View();
        }


    }

    

}
