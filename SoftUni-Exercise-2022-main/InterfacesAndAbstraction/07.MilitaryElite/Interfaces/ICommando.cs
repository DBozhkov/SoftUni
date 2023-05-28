using _07.MilitaryElite.Classes;
using System.Collections.Generic;
namespace _07.MilitaryElite
{
    public interface ICommando
    {
        ICollection<Mission> Missions { get; }
    }
}
