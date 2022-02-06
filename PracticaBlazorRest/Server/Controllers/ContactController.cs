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
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly ILogger<ContactController> _logger;

        private readonly ApplicationDbContext _dbContext;

        public ContactController(ILogger<ContactController> logger, ApplicationDbContext dbContext)
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
            var contact = await _dbContext.Contacts.FirstOrDefaultAsync(a => a.IdContact == id);
            return Ok(contact);
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
