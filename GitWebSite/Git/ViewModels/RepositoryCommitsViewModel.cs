namespace Git.ViewModels.Commits
{
    using System;

    public class RepositoryCommitsViewModel
    {
        public string Id { get; set; }

        public string RepName { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
