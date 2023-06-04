using Git.Services;
using Git.ViewModels;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoriesService repositoriesService;
        ICollection<string> errors = new List<string>();

        public RepositoriesController(IRepositoriesService repositoriesService)
        {
            this.repositoriesService = repositoriesService;
        }

        public HttpResponse All()
        {
            var repo = this.repositoriesService.GetAll();
            return this.View(repo);
        }

        [Authorize]
        public HttpResponse Create()
            => this.View();

        [Authorize]
        [HttpPost]
        public HttpResponse Create(CreateRepositoryViewModel model)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(model.Name) || model.Name.Length < 3 || model.Name.Length > 10)
            {
                errors.Add("Name should be between 3 and 10 characters long.");
                return Error(errors);
            }

            this.repositoriesService.Create(model);
            return Redirect("/Repositories/All");
        }
    }
}
