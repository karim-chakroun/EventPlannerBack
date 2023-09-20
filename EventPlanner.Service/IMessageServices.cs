using EventPlanner.Domain.Models;
using EventPlanner.Service.DTO;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Service
{
    public interface IMessageServices : IService<Messages>
    {
        public IEnumerable<MessagesDTO> GetUserMessages(string? userId);
        public IEnumerable<MessagesDTO> CheckUserMessages(string? connectedUser, string? recivierId);
    }
}
