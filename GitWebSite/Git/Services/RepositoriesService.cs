using Git.Data;
using Git.Data.Models;
using Git.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Git.Services
{
    public class RepositoriesService : IRepositoriesService
    {
        private readonly ApplicationDbContext db;

        public RepositoriesService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Create(CreateRepositoryViewModel repository)
        {
            var repo = new Repository
            {
                Name = repository.Name,
                IsPublic = repository.RepositoryType == "Public" ? true : false,
            };

            this.db.Repositories.Add(repo);
            db.SaveChanges();
        }


        public IEnumerable<GetAllRepositoriesViewModel> GetAll()
        {
            var repos = this.db.Repositories.Select(x => new GetAllRepositoriesViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Owner = x.Owner.Username,
                CreatedOn = x.CreatedOn,
                Commits = x.Commits.Count(),
            }).ToList();

            return repos;
        }
    }
}
