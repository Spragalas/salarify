using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Salarify.DataLayer.Models;

namespace Salarify.DataLayer.ExModels
    {
    public class EmployeeWithSalary: Employee
        {
        public EmployeeWithSalary (Employee employee)
            {
            this.ExperienceYears = employee.ExperienceYears;
            this.ID = employee.ID;
            this.ManagerID = employee.ManagerID;
            this.Name = employee.Name;
            this.Position = employee.Position;
            this.SatisfactionScore = employee.SatisfactionScore;
            }

        public int Salary
            {
            get; set;
            }
        }
    }
