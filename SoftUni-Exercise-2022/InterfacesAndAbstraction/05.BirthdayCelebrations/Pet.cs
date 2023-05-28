using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace _05.BirthdayCelebrations
{
    class Pet : INameable
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = DateTime.ParseExact(birthdate, "dd/mm/yyyy", null);
        }
        public string Name { get; private set; }

        public DateTime Birthdate { get; private set; }
    }
}
