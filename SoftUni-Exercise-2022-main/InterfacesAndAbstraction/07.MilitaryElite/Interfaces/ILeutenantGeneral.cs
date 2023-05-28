using System.Collections.Generic;
using _07.MilitaryElite.Classes;
namespace _07.MilitaryElite
{
    public interface ILeutenantGeneral
    {
        ICollection<Private> Privates { get; }
    }
}