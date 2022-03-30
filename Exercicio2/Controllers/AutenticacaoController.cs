using Microsoft.AspNetCore.Mvc;
using Exercicio2.Models;
using Exercicio2.Utils;
using System.Net;


namespace Exercicio2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        // POST api/register>
        [HttpPost]
        public void Register([FromBody] Utilizadores utilizador)
        {
            using (var db = new DbHelper())
            {
                Utilizadores utilizadorOnDb = db.Utilizadores.Where(uti => 
                uti.Email.Equals(utilizador.Email)).First();

                if (utilizadorOnDb == null)
                {
                    utilizador.Cod_Utilizador = new Random().Next();
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

        // POST api/login
        public void Login([FromBody] Utilizadores utilizador)
        {
            using (var db = new DbHelper())
            {
                Utilizadores utilizadorOnDb = db.Utilizadores.Where(uti =>
                    uti.Email.Equals(utilizador.Email)).First();

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
