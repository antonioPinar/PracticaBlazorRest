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

namespace PracticaBlazorRest.Server.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
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
    }
}
