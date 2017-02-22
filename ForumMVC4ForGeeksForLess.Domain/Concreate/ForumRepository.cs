using System;
using System.Collections.Generic;

using ForumMVC4ForGeeksForLess.Domain.Entities;
using ForumMVC4ForGeeksForLess.Domain.Abstract;
using System.Linq;
using System.Data;

namespace ForumMVC4ForGeeksForLess.Domain.Concreate
{
    public class ForumRepository : IForumRepository
    {
        DatabaseContext context = new DatabaseContext();

        public IQueryable<User> Users
        {
            get { return context.User; }
        }
        public IQueryable<Topic> Topics
        {
            get { return context.Topic; }
        }
        public IQueryable<Message> Messages
        {
            get { return context.Message; }
        }

        public void CreateUser(User user)
        {
            context.User.Add(user);
            context.SaveChanges();
        }
        public void CreateTopic(Topic topic)
        {
            context.Topic.Add(topic);
            context.SaveChanges();
        }
        public void CreateMessage(Message message)
        {
            context.Message.Add(message);
            context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            var original = context.User.Find(user.Id);

            if (original != null)
            {
                context.Entry(original).CurrentValues.SetValues(user);
                context.SaveChanges();
            }
        }
        public void UpdateTopic(Topic topic)
        {
            var original = context.Topic.Find(topic.Id);

            if (original != null)
            {
                context.Entry(original).CurrentValues.SetValues(topic);
                context.SaveChanges();
            }
        }
        public void UpdateMessage(Message message)
        {
            var original = context.Message.Find(message.Id);

            if (original != null)
            {
                context.Entry(original).CurrentValues.SetValues(message);
                context.SaveChanges();
            }
        }
    }
}