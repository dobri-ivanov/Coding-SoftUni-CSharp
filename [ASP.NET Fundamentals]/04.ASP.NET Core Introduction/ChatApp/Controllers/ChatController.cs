using ChatApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    public class ChatController : Controller
    {
        public static ChatViewModel Chat = new ChatViewModel();


        [HttpGet]
        public IActionResult Show()
        {
            if (!Chat.Messages.Any())
            {
                return View(new ChatViewModel());
            }
            return View(Chat);
        }
        [HttpPost]
        public IActionResult Send(ChatViewModel chat)
        {
            MessageViewModel currentMessage = chat.CurrentMessage;
            Chat.Messages.Add(currentMessage);

            return RedirectToAction("Show");
        }
    }
}
