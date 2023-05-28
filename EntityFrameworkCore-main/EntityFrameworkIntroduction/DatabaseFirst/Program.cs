using DatabaseFirst.Models;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Text;
using System.Globalization;

namespace DatabaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new SoftUniContext();

            var result1 = GetEmployeesFullInformation(db);

            var result2 = GetEmployeesWithSalaryOver50000(db);

            var result3 = GetEmployeesFromResearchAndDevelopment(db);

            var result4 = AddNewAddressToEmployee(db);

            var result5 = GetEmployeesInPeriod(db);

            var result6 = GetAddressesByTown(db);

            var result7 = GetEmployee147(db);

            var result8 = GetLatestProjects(db);

            var result9 = IncreaseSalaries(db);

            var result10 = RemoveTown(db);

            Console.WriteLine(result10);

        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context
                .Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                }).ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var chosenEmployees = context
                .Employees
                .Where(e => e.Salary > 50000)
                .Select(x => new
                {
                    x.FirstName,
                    x.Salary
                })
                .OrderBy(e => e.FirstName)
                .ToList();

            foreach (var e in chosenEmployees)
            {
                sb.AppendLine($"{e.FirstName} – {e.Salary:f2}");
            };

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employeesFromRnD = context
                .Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    DepartmentName = x.Department.Name,
                    x.Salary
                })
                .ToList();

            foreach (var e in employeesFromRnD)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.DepartmentName} - ${e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var address = new Addresses()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            var nakov = context
                .Employees
                .Where(e => e.LastName == "Nakov")
                .FirstOrDefault();

            nakov.Address = address;

            context.SaveChanges();

            var employeesNew = context
                .Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(x => new
                {
                    AddressTxt = x.Address.AddressText
                }).ToList();

            foreach (var e in employeesNew)
            {
                sb.AppendLine(e.AddressTxt);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employeesManagers = context
                .Employees
                .Where(e => e.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Projects = e.EmployeesProjects
                    .Select(ep => new
                    {
                        ProjectName = ep.Project.Name,
                        ProjectStartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                        ProjectEndDate = ep.Project.EndDate.HasValue ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                        : "not finished"
                    })
                });

            foreach (var e in employeesManagers)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");

                foreach (var project in e.Projects)
                {
                    sb.AppendLine($"--{project.ProjectName} - {project.ProjectStartDate} - {project.ProjectEndDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var addresses = context
                .Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .Select(x => new
                {
                    x.AddressText,
                    TownName = x.Town.Name,
                    EmplCount = x.Employees.Count
                })
                .ToList();

            foreach (var a in addresses)
            {
                sb.AppendLine($"{a.AddressText}, {a.TownName} - {a.EmplCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employee = context
                .Employees
                .Where(e => e.EmployeeId == 147)
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    Projects = x.EmployeesProjects.Select(ep => new
                    {
                        ProjectName = ep.Project.Name
                    }).OrderBy(pn => pn.ProjectName
).ToList()
                }).SingleOrDefault();

            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            foreach (var pr in employee.Projects)
            {
                sb.AppendLine(pr.ProjectName);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var projects = context
                .Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                    .OrderBy(p => p.Name)
                    .ToList();

            foreach (var p in projects)
            {
                sb.AppendLine($"{p.Name}{Environment.NewLine}{p.Description}{Environment.NewLine}{p.StartDate}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var selectedEmployees = context
                .Employees
                .Where(e => e.Department.Name == "Engineering" || e.Department.Name == "Tool Design" || e.Department.Name == "Marketing" || e.Department.Name == "Information Services").ToList();

            foreach (var e in selectedEmployees)
            {
                e.Salary += e.Salary * 0.12m;
            }

            context.SaveChanges();

            var finalEmployees = selectedEmployees
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.Salary
                }).ToList();

            foreach (var fe in finalEmployees)
            {
                sb.AppendLine($"{fe.FirstName} {fe.LastName} (${fe.Salary:f2})");
            }
                

            return sb.ToString().TrimEnd();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var sb = new StringBuilder();

            string townName = Console.ReadLine();

            context.Employees
                .Where(e => e.Address.Town.Name == townName)
                .ToList()
                .ForEach(e => e.AddressId = null);

            int addressesCount = context.Addresses
                .Where(a => a.Town.Name == townName)
                .Count();

            context.Addresses
                .Where(a => a.Town.Name == townName)
                .ToList()
                .ForEach(a => context.Addresses.Remove(a));

            context.Towns
                .Remove(context.Towns
                    .SingleOrDefault(t => t.Name == townName));

            context.SaveChanges();

            sb.AppendLine($"{addressesCount} {(addressesCount == 1 ? "address" : "addresses")} in {townName} {(addressesCount == 1 ? "was" : "were")} deleted");

            return sb.ToString().TrimEnd();
        }
    }
}
