using Microsoft.AspNetCore.Mvc;
using Exercicio2.Models;
using Exercicio2.Utils;
using System.Net;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exercicio2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        // POST api/<AutenticacaoController>
        [HttpPost]
        public void Register([FromBody] Utilizadores utilizador)
        {
            using (var db = new DbHelper())
            {
                Utilizadores utilizadorOnDb = db.Utilizadores.Where(uti => 
                uti.Email.Equals(utilizador.Email)).First();

                if (utilizadorOnDb == null)
                {
                    utilizador.Password = CryptoUtils.Sha256(utilizador.Password);
                    db.Utilizadores.Add(utilizador);
                    db.SaveChanges();
                }
                else
                {
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.Conflict;
                }
            }
        }

        public void Login([FromBody] Utilizadores utilizador)
        {
            using (var db = new DbHelper())
            {
                Utilizadores utilizadorOnDb = db.Utilizadores.Where(uti =>
                    uti.Email.Equals(utilizador.Email)).First();

                utilizadorOnDb.Password = CryptoUtils.Sha256(utilizadorOnDb.Password);
                utilizador.Password = CryptoUtils.Sha256(utilizador.Password);

                if (utilizadorOnDb != null)
                {
                    if (utilizadorOnDb.Password == utilizador.Password) {
                        HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                    }
                    else
                    {
                        HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    }
                }
                else
                {
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                }

            }
        }

    }
}
