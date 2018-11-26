using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Salarify.DataLayer.Models
    {
    public class Employee : BaseModel
        {
        public string Name
            {
            get; set;
            }
        public string Position
            {
            get; set;
            }
        public int ExperienceYears
            {
            get; set;
            }
        public SatisfactionScore SatisfactionScore
            {
            get; set;
            }
        public int ManagerID
            {
            get; set;
            }
        public Manager Manager
            {
            get; set;
            }
        }
    }
