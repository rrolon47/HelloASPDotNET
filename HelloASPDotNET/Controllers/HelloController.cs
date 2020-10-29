using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelloASPDotNET.Controllers
{
    [Route("/helloworld/")]
    public class HelloController : Controller
    {
        //GET: /<controllers>/
       [HttpGet]
       
        public IActionResult Index()
        {
            string html = "<form method='post' action='/helloworld/welcome'>" +
                "<input type = 'text' name = 'name' />" +
                "<input type = 'submit' value = 'Greet me!' />" +
                "</form>";
            return Content(html, "text/html");
        }
        
        //GET: helloworld/welcome/name/
        //POST: hlloworld/welcome/
        [HttpGet("welcome/{name?}")]
        [HttpPost("welcome")]
         public IActionResult Welcome(string name = "World")
         {
             string html = $"<h1>Welcome to my app, {name}!</h1>";
             return Content(html, "text/html");

         }

    //Exercise
        //Get: /helloworld/language
        [HttpGet("language")]
        public IActionResult NameAndLanguage()
        {
            string html = "<form method='post' action='/helloworld/language_greeting'>" +
                "<input type = 'text' name = 'name' />" +
                "<select name = 'language'>" +
                "   <option>English</option>" +
                "   <option>Spanish</option>" +
                "</select>" +
                "<input type = 'submit' value = 'Greet me!' />" +
                "</form>";
            return Content(html, "text/html");
        }

        //POST: /helloworld/language_greeting/
       [HttpPost("language_greeting")]
        public IActionResult WelcomeInLanguage(string name, string language)
        {
            
            if (language == "English")
            {
                return Content($"<h1>Welcome to my app, {name}!</h1>", "text/html");
            }
            if (language == "Spanish")
            {
                return Content($"<h1>&#161Buenvinidos a mi App, {name}!</h1>", "text/html");
 
            }
            else
            {
                return Content($"<h1>Welcome to my app, World!</h1>", "text/html");
            }
            

        }

    }

    

}
