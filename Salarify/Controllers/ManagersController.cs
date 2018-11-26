using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Salarify.DataLayer;
using Salarify.DataLayer.Models;

namespace Salarify.Controllers
    {
    public class ManagersController : BaseConttroller<Manager>
        {
        public ManagersController (SalarifyContext context) : base(context)
            {

            }
        }
    }