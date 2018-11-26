using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Salarify.DataLayer;
using Salarify.DataLayer.Models;

namespace Salarify.Controllers
    {
    public class BaseSalariesController : BaseConttroller<BaseSalary>
        {
        public BaseSalariesController (SalarifyContext context) : base(context)
            {
            }
        }
    }