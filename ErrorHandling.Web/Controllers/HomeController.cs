using Microsoft.AspNetCore.Mvc;
using ErrorHandling.Web.Services;

namespace ErrorHandling.Web.Controllers;

public class HomeController(SlowService service) : Controller
{
   
    [HttpGet("")]
    public async Task <IActionResult> Index()
    {
        await service.DoSlowWork();
        return View();
    }

    [HttpGet("/throw")]
    public IActionResult Throw()
    {
        throw new Exception("This is a test-error!");
    }



}
