using Git.Data.Models;
using Git.Services;
using Git.ViewModels;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Git.Controllers
{
    public class UsersController : Controller
    {
        ICollection<string> errors = new List<string>();

        private readonly IUsersService userService;

        public UsersController(IUsersService userService)
        {
            this.userService = userService;
        }
        public HttpResponse Register()
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterViewModel model)
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/");
            }

            if (string.IsNullOrEmpty(model.Username) || model.Username.Length < 5 || model.Username.Length > 20)
            {
                errors.Add("Username should be between 5 and 20 character long.");
                return Error(errors);
            }

            if (string.IsNullOrEmpty(model.Password) || model.Password.Length < 6 || model.Password.Length > 20)
            {
                errors.Add("Password should be between 6 and 20 characters long!");
                return Error(errors);
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add("Passwords don't match!");
                return Error(errors);
            }

            if (!this.userService.IsEmailAvailable(model.Email))
            {
                errors.Add("Email already taken.");
                return Error(errors);
            }

            if (!this.userService.IsUsernameAvailable(model.Username))
            {
                errors.Add("Username already taken.");
                return Error(errors);
            }

            this.userService.CreateUser(model.Username, model.Email, model.Password);
            return Redirect("/Users/Login");
        }

        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginViewModel loginInput)
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/");
            }

            var userId = this.userService.GetUserId(loginInput.Username, loginInput.Password);
            if (userId == null)
            {
                errors.Add("Invalid username or password!");
                return this.Error(errors);
            }

            this.SignIn(userId);
            return this.Redirect("/Repositories/All");
        }

        public HttpResponse Logout()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/Users/Login");
            }

            this.SignOut();
            return this.Redirect("/");
        }
    }

}
