using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Git.Data;
using Git.Data.Models;
using Git.InputModels;
using Git.ViewModels;
using Git.ViewModels.Commits;

namespace Git.Services
{
    public class CommitService : ICommitService
    {
        private readonly ApplicationDbContext db;

        public CommitService(ApplicationDbContext db)
        {
            this.db = db;
        }


        public bool CommitFromUserExists(string commitId, string userId)
        {
            return this.db.Commits.Any(x => x.Id == commitId && x.CreatorId == userId);
        }

        public void CreateCommit(CreateCommitInputModel inputModel)
        {
            var newCommit = new Commit
            {
                CreatedOn = DateTime.Now,
                CreatorId = inputModel.CreatorId,
                Description = inputModel.Description,
                Id = Guid.NewGuid().ToString(),
                RepositoryId = inputModel.RepositoryId,
            };
            this.db.Commits.Add(newCommit);
            this.db.SaveChanges();
        }

        public void DeleteCommit(string commitId)
        {
            var deletedCommit = this.db.Commits.FirstOrDefault(x => x.Id == commitId);
            this.db.Commits.Remove(deletedCommit);
            this.db.SaveChanges();
        }

        public List<GetAllCommitsViewModel> GetAllCommitsForUser(string userId)
        {
            var allCommits = this.db.Commits
                .Where(x => x.CreatorId == userId)
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => new GetAllCommitsViewModel
                {
                    Id = x.Id,
                    CreatedOn = x.CreatedOn,
                    Description = x.Description,
                    Repository = x.Repository.Name
                }).ToList();
            return allCommits;
        }
    }
}
