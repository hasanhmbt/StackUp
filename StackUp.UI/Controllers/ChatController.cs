using Microsoft.AspNetCore.Mvc;
using StackUp.Application.Services;

namespace StackUp.UI.Controllers
{
    public class ChatController : Controller
    {
        private readonly ChatService _chatService;

        public ChatController(ChatService chatService)
        {
            _chatService = chatService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetResponse([FromForm] string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
            {
                return Json(new { response = "Please enter a valid input." });
            }

            var response = await _chatService.GetResponseAsync(userInput);
            return Json(new { response });
        }
    }
}
