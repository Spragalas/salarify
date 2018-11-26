using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Salarify.BusinessLogic;
using Salarify.DataLayer;
using Salarify.DataLayer.Models;

namespace Salarify.Controllers
    {
    public class EmployeesController : BaseConttroller<Employee>
        {
        public EmployeesController (SalarifyContext context) : base(context)
            {
            }

        [EnableQuery]
        [ODataRoute("EmployeesWithSalary")]
        public IActionResult GetWithSalary ()
            {
            return Ok(m_context.Employees.Select(
                x => SalaryCalculator.Calculate(x, 
                    m_context.BaseSalaries.FirstOrDefault(y => 
                        y.Position == x.Position && y.ExperienceFrom <= x.ExperienceYears && y.ExperienceTo >= x.ExperienceYears)))
                );
            }
        }
    }