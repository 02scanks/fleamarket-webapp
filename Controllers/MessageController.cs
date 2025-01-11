using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class MessageController : Controller
{
    
    [Route("messages")]
    [Authorize]
    public IActionResult GlobalChat()
    {
        return View();
    }

    [Route("messages/{sellerId}")]
    [Authorize]
    public IActionResult PrivateChat(string sellerId)
    {
        ViewBag.SellerId = sellerId;
        return View();
    }
}