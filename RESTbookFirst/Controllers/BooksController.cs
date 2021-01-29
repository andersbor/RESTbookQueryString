using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RESTbookFirst.Managers;
using RESTbookFirst.Models;

namespace RESTbookFirst.Controllers
{
    [Route("api/[controller]")]
    // the controller is available on ..../api/books
    // [controller] means the name of the controller minus "Controller"
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksManager _manager = new BooksManager();

        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<Book> Get([FromQuery] string title)
        {
            return _manager.GetAll(title);

        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return _manager.GetById(id);
        }

        // POST api/<BooksController>
        [HttpPost]
        public Book Post([FromBody] Book value)
        { 
            return _manager.Add(value);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public Book Put(int id, [FromBody] Book value)
        {
            return _manager.Update(id, value);
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public Book Delete(int id)
        {
            return _manager.Delete(id);
        }
    }
}
