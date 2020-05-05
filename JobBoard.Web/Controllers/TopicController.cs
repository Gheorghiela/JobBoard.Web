using AutoMapper;
using eUseControl.BusinessLogic.Interfaces;
using JobBoard.BusinessLogic.DBModel;
using JobBoard.Domain.Entites.Topics;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace eUseControl.Web.Controllers
{
    public class TopicController : Controller
    {

        private readonly IForum _forum;
        public TopicController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _forum = bl.GetForumBL();
        }

        public ActionResult Index()
        {
            using (ForumContext db = new ForumContext())
            {
                if (db.Forum.OrderByDescending(p => p.CategoryID).FirstOrDefault() != null)
                {
                    Forum last = db.Forum.OrderByDescending(p => p.CategoryID).FirstOrDefault();
                    PostData new_list = new PostData
                    {
                        CList = new List<PCategoryData>()
                    };

                    for (int i = 1; i <= last.CategoryID; i++)
                    {
                        Forum data = (from e in db.Forum where e.CategoryID == i select e).FirstOrDefault();

                        Mapper.Initialize(cfg => cfg.CreateMap<Forum, PCategoryData>());
                        var category = Mapper.Map<PCategoryData>(data);

                        data = (from e in db.Forum where e.CategoryID == i select e).Include(d => d.Topics).FirstOrDefault();

                        if (data.Topics != null)
                            foreach (var top in data.Topics)
                            {
                                Mapper.Initialize(cfg => cfg.CreateMap<TopicData, PTopicData>());
                                var topic = Mapper.Map<PTopicData>(top);
                                category.Topics.Add(topic);
                            }
                        new_list.CList.Add(category);
                    }
                    return View(new_list);
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(PostData category)
        {
            var new_category = new CategoryData()
            {
                Title = category.Title
            };

            _forum.AddCategory(new_category);

            return RedirectToAction("Index", "Topic");
        }

        [HttpPost]
        public ActionResult AddTopic(PostData topic)
        {
            int id = 1;
            var new_topic = new TopicData()
            {
                Title = topic.Title
            };

            _forum.AddTopic(new_topic, id);

            return RedirectToAction("Index", "Topic");
        }

        [HttpPost]
        public ActionResult AddSubject(PSubjectData subject)
        {
            var new_subject = new SubjectData()
            {
                Title = subject.Title
            };

            //_forum.AddSubject(new_subject);

            return RedirectToAction("Index", "Topic");
        }
    }
}