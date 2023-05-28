namespace _07.MilitaryElite
{
        public enum Corps
        {
            Airforces,
            Marines
        }
        public interface ISpecialisedSoldier
        {
            Corps Corps { get; }
        }
    }