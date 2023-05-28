using System;

namespace _05.BirthdayCelebrations
{
    public interface INameable
    {
        string Name { get; }
        DateTime Birthdate { get; }
    }
}
