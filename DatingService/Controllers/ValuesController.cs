using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingService.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ValuesController : ControllerBase
    {
        public DataContext _dataContext { get; }

        public ValuesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // GET: api/Values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _dataContext.Values.ToListAsync();

            return Ok(values);
        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            var value = await _dataContext.Values.FirstOrDefaultAsync(x => x.ID == id);
            return Ok(value);
        }

        // POST: api/Values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
