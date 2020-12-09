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
            string html = "";

            if (String.IsNullOrEmpty(language) && String.IsNullOrEmpty(name))
            {
                html = $"<h1>Welcome to my app, World!</h1>";
            }
            else if (language.Equals("en"))
            {
                html = $"<h1>Welcome to my app, {name}!</h1>";
            }
            else if (language.Equals("fr"))
            {
               html = $"<h1>Bonjour, {name}!</h1>";
            }
            else if (language.Equals("sp"))
            {
                html = $"<h1>&#161Buenvinidos a mi app, {name}!</h1>";

            }
            return html;
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
            ViewBag.person = name;
            //string html = CreateMessage(name, language);
            return View();
        }


    }

    

}
