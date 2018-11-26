using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salarify.DataLayer.Models
    {
    public class BaseSalary: BaseModel
        {       
        public string Position
            {
            get; set;
            }
        public int ExperienceFrom
            {
            get; set;
            }
        public int ExperienceTo
            {
            get; set;
            }
        public int Salary
            {
            get;set;
            }
        }
    }
