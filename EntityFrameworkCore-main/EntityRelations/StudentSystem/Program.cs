using StudentSystem.Data;
using System;

namespace StudentSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new StudentSystemContext();

            db.Database.EnsureCreated();

            db.SaveChanges();
        }
    }
}
