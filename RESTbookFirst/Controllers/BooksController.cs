using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RESTbookFirst.Managers;
using RESTbookFirst.Models;

namespace RESTbookFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private BooksManager manager = new BooksManager();
        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return manager.GetAll();
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return manager.GetById(id);
        }

        // POST api/<BooksController>
        [HttpPost]
        public Book Post([FromBody] Book value)
        {
            return manager.Add(value);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public Book Put(int id, [FromBody] Book value)
        {
            return manager.Update(id, value);
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public Book Delete(int id)
        {
            return manager.Delete(id);
        }
    }
}
