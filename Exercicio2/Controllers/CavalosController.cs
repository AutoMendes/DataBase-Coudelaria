using Exercicio2.Models;
using Exercicio2.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exercicio2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CavalosController : ControllerBase
    {

        // GET api/<CavalosController>/5
        [HttpGet("{id}")]
        public Cavalos Get(int id)
        {
            using (var db = new DbHelper())
            {
                return db.Cavalos.Find(id);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public Cavalos[] Search([FromBody] String searchParam)
        {
            using (var db = new DbHelper())
            {
                return db.Cavalos.Where(cav =>
                cav.Nome_Cavalo.Contains(searchParam)).ToArray();
            }
        }

        [HttpGet]
        [Route("[action]/{genero}")]
        public Cavalos[] genero(String genero)
        {
            using (var db = new DbHelper())
            {
                return db.Cavalos.Where(cav =>
                cav.Genero.Equals(genero.ToUpper())).ToArray();
            }
        }

        // GET: api/<CavalosController>
        [HttpGet]
        public Cavalos[] Get()
        {
            using (var db = new DbHelper())
            {
                return db.Cavalos.ToArray();
            }
        }

        // POST api/<CavalosController>
        [HttpPost]
        public void Post([FromBody] Cavalos cavalo)
        {
            using (var db = new DbHelper())
            {
                cavalo.Cod_Cavalo = new Random().Next();
                db.Cavalos.Add(cavalo);
                db.SaveChanges();
            }
        }

        // PUT api/<CavalosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Cavalos cavalo)
        {
            using (var db = new DbHelper())
            {
                Cavalos cavaloOnDb = db.Cavalos.Find(id);
                if (cavaloOnDb != null)
                {
                    cavaloOnDb.Nome_Cavalo = cavalo.Nome_Cavalo != null ? cavalo.Nome_Cavalo : cavaloOnDb.Nome_Cavalo;


                    db.Cavalos.Update(cavaloOnDb);
                }
                else
                {
                    cavalo.Cod_Cavalo = id;
                    db.Cavalos.Add(cavalo);
                }
                db.SaveChanges();
            }
        }

        // DELETE api/<CavalosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var db = new DbHelper())
            {
                Cavalos cavaloOnDb = db.Cavalos.Find(id);

                if (cavaloOnDb != null)
                {
                    db.Cavalos.Remove(cavaloOnDb);
                    db.SaveChanges();
                }
                else
                {
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                }

            }
        }
    }
}
