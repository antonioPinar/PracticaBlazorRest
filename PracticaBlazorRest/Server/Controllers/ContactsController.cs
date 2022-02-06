using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PracticaBlazorRest.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticaBlazorRest.Shared.Models;
using PracticaBlazorRest.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace PracticaBlazorRest.Server.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ContactsController> _logger;

        private readonly ApplicationDbContext _dbContext;

        public ContactsController(ILogger<ContactsController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return _dbContext.Contacts.ToList();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var dev = await _dbContext.Contacts.FirstOrDefaultAsync(a => a.IdContact == id);
            return Ok(dev);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Contact contact)
        {
            _dbContext.Add(contact);
            await _dbContext.SaveChangesAsync();
            return Ok(contact.IdContact);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Contact contact)
        {
            _dbContext.Entry(contact).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _dbContext.Contacts.DeleteByKeyAsync(id);
            return NoContent();
        }
    }
}
