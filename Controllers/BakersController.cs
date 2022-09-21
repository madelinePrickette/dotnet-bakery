using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DotnetBakery.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetBakery.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //api/bakers  bakers comes from BakersController

    // This means BakersController can now do everything a 
    //ControllerBase can do, plus the stuff we write below.
    public class BakersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public BakersController(ApplicationContext context) {
            _context = context;
            //access to pool and database object
        }

        //REST API methods
        [HttpGet]
        // router.get
        // access, return-type, name(parameters)
        public IEnumerable<Baker> GetAll() {
            Console.WriteLine("get all bakers");

            // we promised to return an IEnumerable<Baker> so we must have a return!
            return _context.Bakers; //underscore for naming pivate conventions
        }

        [HttpPost]
        public IActionResult Post(Baker baker) {
            Console.WriteLine("in post baker");

            //SQL Transactions
            _context.Add(baker);
            _context.SaveChanges();

            // 201 Created and it shows the new object
            // making the id the baker.id and giving it to baker
            return CreatedAtAction(nameof(Post), new {id = baker.id}, baker);
        }

        
    }
}
