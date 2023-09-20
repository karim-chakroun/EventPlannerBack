using EventPlanner.Data.Infrastructures;
using EventPlanner.Data.Migrations;
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
    public class MessageServices : Service<Messages>, IMessageServices
    {
        public MessageServices(IUnitOfWork utk) : base(utk)
        {
        }

        public IEnumerable<MessagesDTO> GetUserMessages(string? userId)
        {
            IDatabaseFactory factory = new DataBaseFactory();
            IUnitOfWork utwk = new UnitOfWork(factory);

            var messages = utwk.getRepository<Messages>().GetMany().Where(m => m.ReceiverId == userId || m.SenderId == userId)
                .Select(e => new MessagesDTO
                {
                    ReceiverId= e.ReceiverId,
                    ReceiverName= e.ReceiverName,
                    SenderName= e.SenderName,
                    SenderId= e.SenderId,
                    MessageId= e.MessageId,
                    Message= e.Message.Select(n => new MessageDTO
                    {
                        Contenu= n.Contenu,
                        IdMessage= n.IdMessage,
                        SenderId= n.SenderId,


                    }).ToList()


                    
                })
        .ToList();

            return messages;
        }

        public IEnumerable<MessagesDTO> CheckUserMessages(string? connectedUser,string? recivierId)
        {
            IDatabaseFactory factory = new DataBaseFactory();
            IUnitOfWork utwk = new UnitOfWork(factory);

            var messages = utwk.getRepository<Messages>().GetMany().Where(m => (m.ReceiverId == connectedUser && m.SenderId == recivierId) || (m.ReceiverId == recivierId && m.SenderId == connectedUser))
                .Select(e => new MessagesDTO
                {
                    ReceiverId = e.ReceiverId,
                    ReceiverName = e.ReceiverName,
                    SenderName = e.SenderName,
                    SenderId = e.SenderId,
                    MessageId = e.MessageId,
                    Message = e.Message.Select(n => new MessageDTO
                    {
                        Contenu = n.Contenu,
                        IdMessage = n.IdMessage,
                        SenderId = n.SenderId,


                    }).ToList()



                })
        .ToList();

            return messages;
        }
    }
}
