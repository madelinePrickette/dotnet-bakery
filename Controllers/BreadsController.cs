using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DotnetBakery.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetBakery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BreadsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public BreadsController(ApplicationContext context) {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Bread> GetAll() {

            //include the joined Baker for each bread
            return _context.Breads.Include(Baker => Baker.bakedBy);
        }
    
        [HttpPost]
        public IActionResult Create(Bread bread) {
            _context.Add(bread);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Create), new {id = bread.id}, bread);
        }

        [HttpPut("{id}")] //like req.params
        public IActionResult Put(int id, Bread bread) {
            Console.WriteLine("updating bread");

            if(id != bread.id){
                return BadRequest();
            }

            _context.Update(bread);
            _context.SaveChanges();

            return NoContent(); //204 This is good it means its done.
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            //select the bread from Db
            // SingleOrDefault is like array.filter();
            Bread bread = _context.Breads.SingleOrDefault( b => b.id == id);

            if(bread is null) {
                return NotFound();
            }

            _context.Breads.Remove(bread);
            _context.SaveChanges();

            return NoContent(); //204 which is good.
        }

        //getting one bread back
        //api/breads/4
        [HttpGet("{id}")]
        public ActionResult<Bread> GetById(int id) {
            Bread bread = _context.Breads
                //join part
                .Include(Baker => Baker.bakedBy)
                .SingleOrDefault(bread => bread.id == id);
            

            if(bread is null) {
                // can't find it
                return NotFound(); // status 404
            }

            return bread;
        }


    }
}
