using System.Collections.Generic;
using _07.MilitaryElite.Classes;
namespace _07.MilitaryElite
{
    public interface IEngineer
    {
        ICollection<Repair> Repairs { get; }
    }
}