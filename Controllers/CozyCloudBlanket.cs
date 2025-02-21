using Microsoft.AspNetCore.Mvc;

namespace CozyCloudBlanket.Controllers
{
    public class CozyCloudBlanket : Controller
    {
        // 
        // GET: /CozyCloudBlanket/
        public IActionResult Index()
        {
            return View();
        }
        //public string Index()
        //{
        //    return "This is Our Website";
        //}
        // 
        // GET: /CozyCloudBlanket/Welcome/ 
        public string Welcome()
        {
            return "Our Website Welcoming All...";
        }
    }
}
