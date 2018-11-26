using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Salarify.DataLayer.Models;

namespace Salarify.DataLayer
    {
    public class SalarifyDbInitializer
        {
        public static void Initialize (SalarifyContext context)
            {
            context.Database.EnsureCreated();
            if ( context.Employees.Any() )
                {
                return; //DB has been seeded
                }

            context.BaseSalaries.Add(new BaseSalary() { ExperienceFrom = 0, ExperienceTo = 2, Position = "Technician", Salary = 1000 });
            context.BaseSalaries.Add(new BaseSalary() { ExperienceFrom = 3, ExperienceTo = 5, Position = "Technician", Salary = 1200 });
            context.BaseSalaries.Add(new BaseSalary() { ExperienceFrom = 6, ExperienceTo = 8, Position = "Technician", Salary = 1520 });
            context.BaseSalaries.Add(new BaseSalary() { ExperienceFrom = 0, ExperienceTo = 2, Position = "Sales", Salary = 1100 });
            context.BaseSalaries.Add(new BaseSalary() { ExperienceFrom = 3, ExperienceTo = 6, Position = "Sales", Salary = 1400 });
            context.BaseSalaries.Add(new BaseSalary() { ExperienceFrom = 7, ExperienceTo = 9, Position = "Sales", Salary = 1650 });
            context.SaveChanges();

            context.Managers.Add(new Manager() { Name = "Bishop Andrew" });
            context.Managers.Add(new Manager() { Name = "Tom NotTheCat" });
            context.SaveChanges();

            context.Employees.Add(new Employee() { ExperienceYears = 0, ManagerID = 1, Position = "Technician", Name = "Tim", SatisfactionScore = SatisfactionScore.VerySatisfied });
            context.Employees.Add(new Employee() { ExperienceYears = 1, ManagerID = 1, Position = "Technician", Name = "Tom", SatisfactionScore = SatisfactionScore.VeryUnsatisfied });
            context.Employees.Add(new Employee() { ExperienceYears = 4, ManagerID = 1, Position = "Technician", Name = "Raymond", SatisfactionScore = SatisfactionScore.Unsatisfied });
            context.Employees.Add(new Employee() { ExperienceYears = 3, ManagerID = 1, Position = "Technician", Name = "Justin", SatisfactionScore = SatisfactionScore.Satisfied });
            context.Employees.Add(new Employee() { ExperienceYears = 1, ManagerID = 1, Position = "Technician", Name = "Dave", SatisfactionScore = SatisfactionScore.BelowAverage });
            context.Employees.Add(new Employee() { ExperienceYears = 7, ManagerID = 1, Position = "Technician", Name = "Rick", SatisfactionScore = SatisfactionScore.AboveAverage });
            context.Employees.Add(new Employee() { ExperienceYears = 7, ManagerID = 1, Position = "Technician", Name = "Morty", SatisfactionScore = SatisfactionScore.VerySatisfied });
            context.Employees.Add(new Employee() { ExperienceYears = 5, ManagerID = 1, Position = "Technician", Name = "Bart", SatisfactionScore = SatisfactionScore.VeryUnsatisfied });
            context.Employees.Add(new Employee() { ExperienceYears = 1, ManagerID = 2, Position = "Sales", Name = "Alice", SatisfactionScore = SatisfactionScore.Unsatisfied });
            context.Employees.Add(new Employee() { ExperienceYears = 1, ManagerID = 2, Position = "Sales", Name = "Timber", SatisfactionScore = SatisfactionScore.Satisfied });
            context.Employees.Add(new Employee() { ExperienceYears = 5, ManagerID = 2, Position = "Sales", Name = "Jake", SatisfactionScore = SatisfactionScore.BelowAverage });
            context.Employees.Add(new Employee() { ExperienceYears = 5, ManagerID = 2, Position = "Sales", Name = "Jim", SatisfactionScore = SatisfactionScore.AboveAverage });
            context.Employees.Add(new Employee() { ExperienceYears = 4, ManagerID = 2, Position = "Sales", Name = "Mary", SatisfactionScore = SatisfactionScore.VerySatisfied });
            context.Employees.Add(new Employee() { ExperienceYears = 2, ManagerID = 2, Position = "Sales", Name = "Mark", SatisfactionScore = SatisfactionScore.VeryUnsatisfied });
            context.Employees.Add(new Employee() { ExperienceYears = 6, ManagerID = 2, Position = "Sales", Name = "Ieva", SatisfactionScore = SatisfactionScore.Unsatisfied });
            context.Employees.Add(new Employee() { ExperienceYears = 1, ManagerID = 2, Position = "Sales", Name = "Alison", SatisfactionScore = SatisfactionScore.VerySatisfied });
            context.SaveChanges();
            }
        }
    }
