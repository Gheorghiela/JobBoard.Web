using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using JobBoard.BusinessLogic.DBModel;
using JobBoard.Domain.Entities.User;
using JobBoard.Helpers;
using System.Web;
using JobBoard.Domain.Entities.Topics;
using System.Collections.Generic;
using eUseControl.Helpers;
using JobBoard.Domain.Entites.Topics;
using eUseControl.Domain.Entites.Topics;

namespace eUseControl.BusinessLogic.Core
{
    public class UserApi
    {
        internal URegisterResp UserRegisterAction(URegisterData data)
        {
            UDbTable new_user = new UDbTable();

            using (var todo = new UserContext())
            {
                new_user.Username = data.Username;
                new_user.Password = LoginHelper.HashGen(data.Password);
                new_user.Email = data.Email;

                todo.Users.Add(new_user);
                todo.SaveChanges();
            }
            return new URegisterResp();
        }

        internal ULoginResp UserLoginAction(ULoginData data)
        {
            UDbTable result;
            var validate = new EmailAddressAttribute();
            if (validate.IsValid(data.Credential))
            {
                var pass = LoginHelper.HashGen(data.Password);
                using (var db = new UserContext())
                {
                    result = db.Users.FirstOrDefault(u => u.Email == data.Credential && u.Password == pass);
                }

                if (result == null)
                {
                    return new ULoginResp { Status = false, StatusMsg = "The Username or Password is Incorrect" };
                }

                /*using (var todo = new UserContext())
                {
                    result.LasIp = data.LoginIp;
                    result.LastLogin = data.LoginDateTime;
                    todo.Entry(result).State = EntityState.Modified;
                    todo.SaveChanges();
                }*/

                return new ULoginResp { Status = true };
            }
            else
            {
                var pass = LoginHelper.HashGen(data.Password);
                using (var db = new UserContext())
                {
                    result = db.Users.FirstOrDefault(u => u.Username == data.Credential && u.Password == pass);
                }

                if (result == null)
                {
                    return new ULoginResp { Status = false, StatusMsg = "The Username or Password is Incorrect" };
                }

                return new ULoginResp { Status = true };
            }
        }

        internal HttpCookie Cookie(string loginCredential)
        {
            var apiCookie = new HttpCookie("X-KEY")
            {
                Value = CookieGenerator.Create(loginCredential)
            };

            using (var db = new SessionContext())
            {
                Session curent;
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(loginCredential))
                {
                    curent = (from e in db.Sessions where e.Username == loginCredential select e).FirstOrDefault();
                }
                else
                {
                    curent = (from e in db.Sessions where e.Username == loginCredential select e).FirstOrDefault();
                }

                if (curent != null)
                {
                    curent.CookieString = apiCookie.Value;
                    curent.ExpireTime = DateTime.Now.AddMinutes(60);
                    using (var todo = new SessionContext())
                    {
                        todo.Entry(curent).State = EntityState.Modified;
                        todo.SaveChanges();
                    }
                }
                else
                {
                    db.Sessions.Add(new Session
                    {
                        Username = loginCredential,
                        CookieString = apiCookie.Value,
                        ExpireTime = DateTime.Now.AddMinutes(60)
                    });
                    db.SaveChanges();
                }
            }

            return apiCookie;
        }

        internal UserMinimal UserCookie(string cookie)
        {
            Session session;
            UDbTable curentUser;

            using (var db = new SessionContext())
            {
                session = db.Sessions.FirstOrDefault(s => s.CookieString == cookie && s.ExpireTime > DateTime.Now);
            }

            if (session == null) return null;
            using (var db = new UserContext())
            {
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(session.Username))
                {
                    curentUser = db.Users.FirstOrDefault(u => u.Email == session.Username);
                }
                else
                {
                    curentUser = db.Users.FirstOrDefault(u => u.Username == session.Username);
                }
            }

            if (curentUser == null) return null;
            Mapper.Initialize(cfg => cfg.CreateMap<UDbTable, UserMinimal>());
            var userminimal = Mapper.Map<UserMinimal>(curentUser);

            return userminimal;
        }

        internal ULogoutResp UserLogoutAction(string user)
        {
            using (var db = new SessionContext())
            {
                Session curent;
                curent = (from e in db.Sessions where e.Username == user select e).FirstOrDefault();
                curent.ExpireTime = DateTime.Now.AddMinutes(-1);
                using (var todo = new SessionContext())
                {
                    todo.Entry(curent).State = EntityState.Modified;
                    todo.SaveChanges();
                }
            }
            return new ULogoutResp();
        }

        internal CategoryResp AddCategoryAction(CategoryData category)
        {
            Forum new_category = new Forum();
            using (var todo = new ForumContext())
            {
                new_category.Category = category.Title;
                todo.Forum.Add(new_category);
                todo.SaveChanges();
            }

            return new CategoryResp();
        }

        internal TopicResp AddTopicAction(TopicData topic, int id)
        {
            using (var db = new ForumContext())
            {
                Forum category;
                category = (from e in db.Forum where e.CategoryID == id select e).FirstOrDefault();
                if (category.Topics == null)
                    category.Topics = new List<TopicData>();
                category.Topics.Add(topic);
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();

            }

            return new TopicResp();
        }

        internal SubjectResp AddSubjectAction(SubjectData category)
        {
            return new SubjectResp();
        }
    }
}