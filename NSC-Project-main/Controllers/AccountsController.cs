
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NSC_project.Models;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Session;
using NSC_project.Extentions;
using NSC_project.Data;

namespace NSC_project.Controllers
{
    public class AccountsController : Controller
    {
        private readonly NSC_projectContext _context;
  /*      private string enteredpassword;
        private string storedPassword;*/

        public string Password { get; private set; }

        public AccountsController(NSC_projectContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Id,Username,Password,Name,Email,PhoneNumber")] User user)
        {
            if (ModelState.IsValid)
            {
               /* if (checkUsername(user.Username) > 0)
                {
                    ModelState.AddModelError("", "Login name is already exist!");
                }*/
                if(checkEmail(user.Email) > 0)
                {
                    ModelState.AddModelError("", "Email is already exist!");
                }
                else
                {
                    var u = new User();
                    u.Username = user.Username;
                    u.Password = BCrypt.Net.BCrypt.HashPassword(user.Password); ;
                    u.Name = user.Name;
                    u.Email = user.Email;
                    u.PhoneNumber = user.PhoneNumber;

                    _context.Add(u);
                    await _context.SaveChangesAsync();
                    if (_context.User.FirstOrDefault(i => i.Email == u.Email) != null)
                    {
                        ViewBag.Success = "Signup successfully!";
                        user = new User();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Signup Failed!");
                    }
                }
            }
            return View(user);
        }

    /*    private int checkUsername(string username)
        {
            var query = from u in _context.User where u.Username == username select u;

            return query.Count();
        }*/

        private int checkEmail(string email)
        {
            var query = from u in _context.User where u.Email == email select u;

            return query.Count();
        }

        /*public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }*/


        // Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var data = _context.User.Where(s => s.Email.Equals(email)).ToList();
               
                bool checkPass = BCrypt.Net.BCrypt.Verify(password, data.FirstOrDefault().Password);

                if (checkPass == true)
                {
                    //add session
                    var User = new UserSession();
                    User.UserName = data.FirstOrDefault().Name.ToString();
                    User.UserId = data.FirstOrDefault().Id;

                    HttpContext.Session.SetObjectAsJson("UserDetails", User);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Register", "Accounts");
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}
