using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Salarify.DataLayer;
using Salarify.DataLayer.Models;

namespace Salarify.Controllers
    {
    public class BaseConttroller<T> : ODataController where T : BaseModel
        {
        protected readonly SalarifyContext m_context;
        public BaseConttroller (SalarifyContext context)
            {
            m_context = context;
            }

        [EnableQuery]
        public IActionResult Get (int key)
            {
            return Ok(m_context.Set<T>().FirstOrDefault(c => c.ID == key));
            }

        [EnableQuery]
        public IActionResult Get ()
            {
            return Ok(m_context.Set<T>());
            }

        [EnableQuery]
        public IActionResult Post ([FromBody]T baseSalary)
            {
            m_context.Set<T>().Add(baseSalary);
            m_context.SaveChanges();
            return Created(baseSalary);
            }

        public async Task<IActionResult> Patch ([FromODataUri] int key, [FromBody] Delta<T> instance)
            {
            if ( !ModelState.IsValid )
                {
                return BadRequest(ModelState);
                }
            var entity = await m_context.Set<T>().FindAsync(key);
            if ( entity == null )
                {
                return NotFound();
                }
            instance.Patch(entity);
            try
                {
                await m_context.SaveChangesAsync();
                }
            catch ( DbUpdateConcurrencyException )
                {
                if ( !ModelExists(key) )
                    {
                    return NotFound();
                    }
                else
                    {
                    throw;
                    }
                }

            return Updated(entity);
            }
        
        public async Task<IActionResult> Put ([FromODataUri]int key, [FromBody] T update)
            {
            if ( !ModelState.IsValid )
                {
                return BadRequest(ModelState);
                }
            if ( key != update.ID )
                {
                return BadRequest();
                }
            m_context.Entry(update).State = EntityState.Modified;
            try
                {
                await m_context.SaveChangesAsync();
                }
            catch ( DbUpdateConcurrencyException )
                {
                if ( !ModelExists(key) )
                    {
                    return NotFound();
                    }
                else
                    {
                    throw;
                    }
                }
            return Updated(update);
            }

        public async Task<ActionResult> Delete ([FromODataUri] int key)
            {
            var movie = await m_context.Set<T>().FindAsync(key);
            if ( movie == null )
                {
                return NotFound();
                }
            m_context.Set<T>().Remove(movie);
            await m_context.SaveChangesAsync();
            return StatusCode((int) System.Net.HttpStatusCode.NoContent);
            }

        private bool ModelExists (int key)
            {
            return m_context.Set<T>().Any(x => x.ID == key);
            }
        }
    }
