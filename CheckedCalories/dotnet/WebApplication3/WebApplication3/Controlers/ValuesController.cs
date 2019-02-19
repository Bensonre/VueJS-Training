using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication3.Controlers
{
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id:int}")]
        public IActionResult Get(int id, string Q)
        {
            return Ok(new ValueList { Id = id} );
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Value value)
        {
            return CreatedAtAction("Get", new { Name = value.Name, Text= value.Text, Rating= value.Rating }, value);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
    public class ValueList
    {
        public int Id { get; set; }


        public List<Value> Text { get; set; }
    }

    public class Value
    {
        public string Name { get; set; }

        public string Text { get; set; }

        public int Rating { get; set; }
    }
}
