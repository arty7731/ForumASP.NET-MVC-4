using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

using ForumMVC4ForGeeksForLess.Models;
using ForumMVC4ForGeeksForLess.Domain.Entities;
using ForumMVC4ForGeeksForLess.Domain.Concreate;
using ForumMVC4ForGeeksForLess.Domain.Abstract;
using ForumMVC4ForGeeksForLess.Infrastructure;

namespace ForumMVC4ForGeeksForLess.Controllers
{
    public class HomeController : Controller
    {
        public int pageSizeTopicList = 5;
        public int pageSizeMessageList = 10;
        

        IForumRepository repository;
        public HomeController(IForumRepository repo)
        {
            repository = repo;
        }

        // GET: /Home/
        //View all topics
        public ActionResult Index(int page = 1)
        {
            TopicListModelView model = new TopicListModelView();
            try
            {
                model.Topics = repository.Topics.Include(t => t.User)
                    .OrderByDescending(t => t.Id)
                    .Skip((page - 1) * pageSizeTopicList)
                    .Take(pageSizeTopicList).ToList();
                
                model.PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSizeTopicList,
                    TotalItems = repository.Topics.Count()
                };               
                return View(model);           
            }
            catch 
            {
                return View();
            }
        }

        //Create new topic
        [HttpGet]
        [Authorize]
        public ActionResult NewTopic()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult NewTopic(CreateTopicModelView topic)
        {
            if(User.Identity.IsAuthenticated)
            {
                var login = User.Identity.Name;
                User user = repository.Users.FirstOrDefault(u => u.Login == login);

                var newTopic = new Topic()
                {
                    UserId = user.Id,
                    Title = topic.Title,
                    Text = topic.Text,
                    Date = DateTime.Now
                };
                if (!(string.IsNullOrEmpty(newTopic.Text) && string.IsNullOrEmpty(newTopic.Title)))
                {
                    repository.CreateTopic(newTopic);
                }
            }
            

            return RedirectToAction("Index");
        }

        //View topic and topic messages
        public ActionResult ViewTopic(int id, int page = 1)
        {
            var model = new TopicModelView();
            repository.Messages.Include(m => m.User);
            model.Topic = repository.Topics.Include(t => t.Messages.Select(m => m.User)).Include(t => t.User).FirstOrDefault(t => t.Id == id);
            model.Topic.CountView++;
            repository.UpdateTopic(model.Topic);
            model.PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSizeMessageList,
                    TotalItems = repository.Messages.Count(m => m.TopicId == model.Topic.Id)
                };
            TempData["TopicId"] = model.Topic.Id;
            return View(model);
        }

        //Create new message
        [HttpGet]
        [ChildActionOnly]
        [Authorize]        
        public ActionResult CreateMessage() 
        {
            return PartialView();
        }
        [HttpPost]
        [Authorize]
        public ActionResult CreateMessage(CreateMessageModelView message)
        {
            var newMessage = new Message();
            newMessage.TextMessage = message.TextMessage;
            newMessage.TopicId = (int)TempData["TopicId"];
            newMessage.UserId = repository.Users.FirstOrDefault(u => u.Login == HttpContext.User.Identity.Name).Id;
            newMessage.Date = DateTime.Now;
            if (!string.IsNullOrEmpty(newMessage.TextMessage))
            {
                repository.CreateMessage(newMessage);
            }
            return RedirectToAction("ViewTopic", new { id = newMessage.TopicId });
        }

        //Edit message
        [HttpGet]
        [Authorize]
        public ActionResult EditMessage(int id)
        {
            Message message = repository.Messages.Include(m => m.User).FirstOrDefault(m => m.Id == id);
            if (message != null && message.User.Login == HttpContext.User.Identity.Name)
            {
                return PartialView(message);
            }
            ViewBag.MessageError = "Message not fount or no access!!!";
            return PartialView();
        }
        [HttpPost]
        [Authorize]
        public ActionResult EditMessage(Message message)
        {
            if (ModelState.IsValid)
            {
               repository.UpdateMessage(message); 
            }
            return RedirectToAction("ViewTopic", new { id = message.TopicId });
        }
    }
}
