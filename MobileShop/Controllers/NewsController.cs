namespace MobileShop.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("https://www.gsmarena.com/news.php3");
        }
    }
}
