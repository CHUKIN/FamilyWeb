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
    public class AddController : Controller
    {
        FamilyContext db;
        public AddController(FamilyContext context)
        {
            db = context;
        }
        public ContentResult Group(Group group)
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
        public ContentResult User(string groupname,User user)
        {
           if (db.Groups.Where(i => i.Name== groupname).FirstOrDefault() == null)
            {
                return Content("Данной группы не существует");
            }
            else
            {
                if (db.Users.Where(i => i.Login==user.Login).FirstOrDefault() == null)
                {
                    user.Group = db.Groups.Where(i => i.Name == groupname).First();
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
        public ContentResult Category(string groupname, Category category)
        {
            if (db.Groups.Where(i => i.Name == groupname).FirstOrDefault() == null)
            {
                return Content("Данной группы не существует");
            }
            else
            {
                if (db.Categorys.Where(i => i.Name == category.Name).FirstOrDefault() == null)
                {
                    category.Group = db.Groups.Where(i => i.Name == groupname).First();
                    db.Categorys.Add(category);
                    db.SaveChanges();
                    return Content("Категория Id=" + category.Id.ToString() + " Имя=" + category.Name.ToString() + " Успешно добавлена");
                }
                else
                {
                    return Content("Такой пользователь уже существует");
                }
            }
        }
        public ContentResult Cash(string groupname, Cash cash)
        {
            if (db.Groups.Where(i => i.Name == groupname).FirstOrDefault() == null)
            {
                return Content("Данной группы не существует");
            }
            else
            {
                if (db.Cashs.Where(i => i.Name == cash.Name).FirstOrDefault() == null)
                {
                    cash.Group = db.Groups.Where(i => i.Name == groupname).First();
                    db.Cashs.Add(cash);
                    db.SaveChanges();
                    return Content("Кошелёк Id="+cash.Id.ToString()+" Name="+cash.Name.ToString()+" Баланс="+cash.Money.ToString()+" Успешно создан");
                }
                else
                {
                    return Content("Такой кошелёк уже существует");
                }
            }
        }
        public ContentResult Saving(string groupname, Saving saving, string date)
        {
            if (db.Groups.Where(i => i.Name == groupname).FirstOrDefault() == null)
            {
                return Content("Данной группы не существует");
            }
            else
            {
                if (db.Savings.Where(i => i.Name == saving.Name).FirstOrDefault() == null)
                {
                    saving.Group = db.Groups.Where(i => i.Name == groupname).First();
                    string[] tmpstr = (date.Split('.'));
                    int[] tmp= new int[6];
                    for (int i=0;i<6;i++)
                    {
                        tmp[i] = Convert.ToInt32(tmpstr[i]);
                    }
                    saving.Date = new DateTime(tmp[2], tmp[1], tmp[0], tmp[3], tmp[4], tmp[5]);
                    db.Savings.Add(saving);
                    db.SaveChanges();
                    return Content("Накопление Id=" + saving.Id.ToString() + " Name=" + saving.Name.ToString() + " Сумма=" + saving.Money.ToString() + " Дата="+saving.Date.ToString()+" Успешно создано");
                }
                else
                {
                    return Content("Такое накопление уже существует");
                }
            }
        }
        public ContentResult Cost(string cashname, string username,string categoryname, Cost cost)
        {
            Cash cash = db.Cashs.Where(i => i.Name == cashname).FirstOrDefault();
            if (cash == null)
            {
                return Content("Данного кошелька не существует");
            }
            User user = db.Users.Where(i => i.Login == username).FirstOrDefault();
            if (user == null)
            {
                return Content("Данного пользователя не существует");
            }
            Category category = db.Categorys.Where(i => i.Name == categoryname).FirstOrDefault();
            if (category == null)
            {
                return Content("Данной категории не существует");
            }
            if (cost.Money>cash.Money)
            {
                return Content("У данного кошелька не хватает средств");
            }
            cash.Money -= cost.Money;

            cost.Category = category;
            db.Costs.Add(cost);
            db.SaveChanges();
            return Content("Трата Id="+cost.Id.ToString()+" Описание="+cost.Name.ToString()+" Потрачено="+cost.Money.ToString()+" Катеория="+cost.Category.ToString()+" Успешно создана");
        }
    }
}
