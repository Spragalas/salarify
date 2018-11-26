using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Salarify.DataLayer.ExModels;
using Salarify.DataLayer.Models;

namespace Salarify.BusinessLogic
    {
    public static class SalaryCalculator
        {
        public static EmployeeWithSalary Calculate (Employee employee, BaseSalary baseSalary)
            {
            if ( baseSalary == null )
                throw new ArgumentNullException();
            if ( employee == null )
                throw new ArgumentNullException();
            if ( baseSalary.Position != employee.Position )
                throw new ArgumentException();
            if ( baseSalary.ExperienceFrom > employee.ExperienceYears && baseSalary.ExperienceTo < employee.ExperienceYears )
                throw new ArgumentException();

            int minWage = 800;

            int salary = minWage + baseSalary.Salary
                + (int) Math.Round((double) baseSalary.Salary / 100 * (double) SatisfactionBonus.GetBonusPercentage(employee.SatisfactionScore));

            return new EmployeeWithSalary(employee) { Salary = salary };
            }
        }
    }
