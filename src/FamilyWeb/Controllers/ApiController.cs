using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FamilyWeb.Models;
using System.Collections;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FamilyWeb.Controllers
{
    public class ApiController : Controller
    {
        FamilyContext db;
        public ApiController(FamilyContext context)
        {
            db = context;
        }
        public ContentResult AddGroup(Group group)
        {
            if (db.Groups.Where(i => i.Name == group.Name).FirstOrDefault() == null)
            {
                db.Groups.Add(group);
                db.SaveChanges();
                return Content("Группа Id=" + group.Id.ToString() + " Name=" + group.Name.ToString() + " Успешно добавлена");
            }
            else
            {
                return Content("Группа с таким именем уже существует");
            }
        }
        public ContentResult AddUser(string name,User user)
        {
           if (db.Groups.Where(i => i.Name==name).FirstOrDefault() == null)
            {
                return Content("Данной группы не существует");
            }
            else
            {
                if (db.Users.Where(i => i.Login==user.Login).FirstOrDefault() == null)
                {
                    user.Group = db.Groups.Where(i => i.Name == name).First();
                    db.Users.Add(user);
                    db.SaveChanges();
                    return Content("Пользоваель Id=" + user.Id.ToString() + " Login=" + user.Login.ToString() + " Password=" + user.Password.ToString() + " Успешно добавлен");             
                }
                else
                {
                    return Content("Такой пользователь уже существует");
                }
            }
        }
    }
}
