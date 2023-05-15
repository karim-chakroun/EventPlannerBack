using EventPlanner.Domain.Models;
using EventPlanner.Service;
using EventPlanner.Service.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace EventPlanner.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHubContext<ChatHub> _hubContext;

        public ChatController(UserManager<ApplicationUser> userManager, IHubContext<ChatHub> hubContext)
        {
            _userManager = userManager;
            _hubContext = hubContext;
        }

        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            var users = _userManager.Users.Select(u => new { u.Id, u.FullName }).ToList();
            return Ok(users);
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] ChatMessageDto messageDto)
        {
            var sender = await _userManager.FindByIdAsync(messageDto.SenderId);
            var receiver = await _userManager.FindByIdAsync(messageDto.ReceiverId);

            if (sender == null || receiver == null)
            {
                return BadRequest("Invalid sender or receiver ID.");
            }

            var chat = new Chat
            {
                SenderId = sender.Id,
                SenderName = sender.FullName,
                ReceiverId = receiver.Id,
                ReceiverName = receiver.FullName,
                Message = messageDto.Message,
                TimeSent = messageDto.TimeSent
            };

            await _hubContext.Clients.User(receiver.Id).SendAsync("ReceiveMessage", chat);

            return Ok();
        }
    }

}
