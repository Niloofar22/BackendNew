using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TestApii.Database;
using TestApii.Modells;

namespace TestApii.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApDbContext _context;

        public MoviesController(ApDbContext context)
        {
            _context = context;
        }


        // GET: api/Movies
        [HttpGet]
        async Task<ActionResult<IEnumerable<TmdbMovies>>> GetAllMovies()// för att använda return
        {
            return await _context.TmdbMovies.ToListAsync();
        }



        // GET: api/Movies/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<TmdbMovies> Get(int id)
        {
            HttpClient client = new();
        string uri = $"https://api.themoviedb.org/3/movie/{id}?api_key=fd3dab6ed93874dbed5b14d04a672be2";




            var response = await client.GetAsync(uri);
            //Console.WriteLine(response);
            response.EnsureSuccessStatusCode();

            string responsecontent = await response.Content.ReadAsStringAsync();

            TmdbMovies test = JsonConvert.DeserializeObject<TmdbMovies>(responsecontent);

            return test;


        }

        // POST: api/Movies
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
        

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class Movies
    {
    }
}
