using Git.Data.Models;
using Git.ViewModels;
using System.Collections.Generic;

namespace Git.Services
{
    public interface IRepositoriesService
    {
        IEnumerable<GetAllRepositoriesViewModel> GetAll();
        void Create(CreateRepositoryViewModel repo);
    }
}
