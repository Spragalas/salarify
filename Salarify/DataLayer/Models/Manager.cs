using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salarify.DataLayer.Models
    {
    public class Manager: BaseModel
        {
        public string Name
            {
            get; set;
            }
        public ICollection<Employee> Employees
            {
            get; set;
            }
        }
    }
