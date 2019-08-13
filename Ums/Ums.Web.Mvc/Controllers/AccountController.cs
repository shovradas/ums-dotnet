using AutoMapper;
using System;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Ums.Entities;
using Ums.Framework;
using Ums.Infrastructure;
using Ums.Service.Interfaces;
using Ums.Web.Mvc.Filters;
using Ums.Web.Mvc.Helpers;
using Ums.Web.Mvc.Models;

namespace Ums.Web.Mvc.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly CryptoHelper _cryptoHelper;
        private readonly EmailService _emailService;        

        public AccountController(IAuthService authService, IUserService userService, IStudentService studentService, CryptoHelper cryptoHelper, IMapper mapper, EmailService emailService)
        {
            _authService = authService;
            _userService = userService;
            _studentService = studentService;
            _mapper = mapper;
            _cryptoHelper = cryptoHelper;
            _emailService = emailService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Dashboard");
        }

        [HttpGet]
        public ActionResult Login()
        {
            if (Request.Cookies["ums-session-id"] != null)
            {
                String userName = _cryptoHelper.Base64Decode(Request.Cookies["ums-session-id"].Value);
                User user = _userService.GetByUserName(userName);
                user.Password = "*****";

                Session["User"] = user;

                return RedirectToAction("Index", "Dashboard");
            }

            return View();
        }

        [HttpPost]
         public ActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                model.UserName = model.UserName.Trim();
                model.Password = model.Password.Trim();

                User user = _mapper.Map<LoginVM, User>(model);

                if (_authService.ValidateUser(user))
                {
                    if (user.Type == UserType.Student)
                    {
                        Student student = _studentService.GetById(user.Id);
                        student.Password = "*****";
                        Session["User"] = student;                        
                    }                  
                        
                    else
                        Session["User"] = user;

                    if (model.Remember=="on")
                        Response.SetCookie(new HttpCookie("ums-session-id", _cryptoHelper.Base64Encode(model.UserName)));

                    return RedirectToAction("Index", "Dashboard");
                }                
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Abandon();
            Response.Cookies["ums-session-id"].Expires = DateTime.Now.AddDays(-1);
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResetPassword(String email)
        {
            if (String.IsNullOrEmpty(email))
            {
                ViewBag.AlertMessage = AlertHelper.DangerAlert("Missing", "Please enter your email");
            }
            else if (_userService.GetByEmail(email) == null)
            {
                ViewBag.AlertMessage = AlertHelper.DangerAlert("Invalid Email", "Account does not exist");
            }
            else
            {
                MailMessage mail = new MailMessage();
                //TODO: create mail with password reset link
                if (_emailService.SendEmail(mail))
                {
                    ViewBag.AlertMessage = AlertHelper.SuccessAlert("Success!", "Password reset link has been sent to your email");
                }
            }
            
            return View(model: email);
        }

        [HttpGet]
        [BasicAuthentication]
        public new ActionResult Profile()
        {
            return View(Session["User"]);
        }

        [HttpGet]
        [BasicAuthentication]
        public ActionResult ChangePassword()
        {
            User user = Session["User"] as User;
            ChangePasswordVM model = _mapper.Map<User, ChangePasswordVM>(user);

            return View(model);
        }

        [HttpPost]
        [BasicAuthentication]
        public ActionResult ChangePassword(ChangePasswordVM model)
        {
            User user = _mapper.Map<ChangePasswordVM, User>(model);

            if (ModelState.IsValid && _authService.ValidateUser(user) )
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    user.Password = _cryptoHelper.GetMd5Hash(md5Hash, model.NewPassword);

                    if (_userService.UpdatePassword(user))
                    {
                        TempData["AlertMessage"] = AlertHelper.SuccessAlert("Success", "Your last action was successful.");
                        return RedirectToAction("Logout");
                    }                        
                }
            }

            TempData["AlertMessage"] = AlertHelper.DangerAlert("Unsuccessful", "You might have provided wrong data.");

            return View(model);
        }

        [HttpGet]
        [BasicAuthentication]
        public ActionResult Edit()
        {
            UserVM model = _mapper.Map<User, UserVM>(Session["User"] as User);
            return View(model);
        }

        [HttpPost]
        [BasicAuthentication]
        public ActionResult Edit(UserVM model)
        {

            if (ModelState.IsValid)
            {
                User user = Session["User"] as User;
                user.Name = model.Name.Trim();
                user.Email = model.Email.Trim();

                if (_userService.UpdateProfile(user))
                {
                    return RedirectToAction("Profile");
                }
            }
            
            return View(model);
        }
    }
}