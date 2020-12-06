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
        
       //GET: /<helloworld>/
       [HttpGet]
        public IActionResult Index()
        {
            string html = "<form method='post' action='/helloworld/welcome'>" +
                "<input type = 'text' name = 'name' />" +
                "<select name = 'language'>"+
                    "<option value = ''> --Select a Language-- </option>" +
                    "<option value = 'en'> English </option>" +
                    "<option value = 'fr'> French </option>" +
                    "<option value ='sp'> Spanish </option>" +
                "</select>" +
                "<input type = 'submit' value = 'Greet me!' />" +
                "</form>";
            return Content(html, "text/html");
        }
        
        //GET: helloworld/welcome/name/
        //POST: helloworld/welcome/
        [HttpGet("welcome/{name?}")]
        [HttpPost("welcome")]
         public IActionResult Welcome(string name = "World" , string language = "en")
         {
            string html = CreateMessage(name, language);
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
                "   <option value = ''> --Select a Language-- </option>" +
                "   <option value ='en'>English</option>" +
                "   <option value ='sp'>Spanish</option>" +
                "   <option value = 'fr'>French</option>" +
                "</select>" +
                "<input type = 'submit' value = 'Greet me!' />" +
                "</form>";
            return Content(html, "text/html");
        }

        //POST: /helloworld/language_greeting/
       [HttpPost("language_greeting")]
        public IActionResult WelcomeInLanguage(string name, string language)
        {
            return Content(CreateMessage(name, language), "text/html");
        }

    }

    

}
