using Git.InputModels;
using Git.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services
{
    public interface ICommitService
    {
        List<GetAllCommitsViewModel> GetAllCommitsForUser(string userId);
        void CreateCommit(CreateCommitInputModel commitModel);
        void DeleteCommit(string commitId);
        bool CommitFromUserExists(string commitId, string userId);
    }
}
