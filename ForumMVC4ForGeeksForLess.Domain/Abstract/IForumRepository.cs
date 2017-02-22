using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ForumMVC4ForGeeksForLess.Domain.Entities;

namespace ForumMVC4ForGeeksForLess.Domain.Abstract
{
    public interface IForumRepository
    {
        IQueryable<User> Users { get; }
        IQueryable<Topic> Topics { get; }
        IQueryable<Message> Messages { get; }

        void CreateUser(User user);
        void CreateTopic(Topic topic);
        void CreateMessage(Message message);

        void UpdateUser(User user);
        void UpdateTopic(Topic topic);
        void UpdateMessage(Message message);


    }
}
