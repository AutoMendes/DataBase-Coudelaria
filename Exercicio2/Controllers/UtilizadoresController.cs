using Exercicio2.Models;
using Exercicio2.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exercicio2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilizadoresController : ControllerBase
    {
        // GET api/<UtilizadoresController>/5
        [HttpGet("{id}")]
        public Utilizadores Get(int id)
        {
            using (var db = new DbHelper())
            {
                return db.Utilizadores.Find(id);
            }
        }

        // GET: api/<CavalosController>
        [HttpGet]
        public Utilizadores[] Get()
        {
            using (var db = new DbHelper())
            {
                return db.Utilizadores.ToArray();
            }
        }


        // POST api/<UtilizadoresController>
        [HttpPost]
        public void Post([FromBody] Utilizadores utilizador)
        {
            using (var db = new DbHelper())
            {
                utilizador.Cod_Utilizador = new Random().Next();
                db.Utilizadores.Add(utilizador);
                db.SaveChanges();
            }
        }

        // PUT api/<UtilizadoresController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Utilizadores utilizador)
        {
            using (var db = new DbHelper())
            {
                Utilizadores utilizadorOnDb = db.Utilizadores.Find(id);
                if (utilizadorOnDb != null)
                {
                    utilizadorOnDb.Nome = utilizador.Nome != null ? utilizador.Nome : utilizadorOnDb.Nome;


                    db.Utilizadores.Update(utilizadorOnDb);
                }
                else
                {
                    utilizador.Cod_Utilizador = id;
                    db.Utilizadores.Add(utilizador);
                }
                db.SaveChanges();
            }
        }

        // DELETE api/<UtilizadoresController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var db = new DbHelper())
            {
                Utilizadores utilizadorOnDb = db.Utilizadores.Find(id);

                if (utilizadorOnDb != null)
                {
                    db.Utilizadores.Remove(utilizadorOnDb);
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
