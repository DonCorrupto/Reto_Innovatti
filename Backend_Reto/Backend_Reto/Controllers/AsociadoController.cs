using Backend_Reto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend_Reto.Controllers
{
    public class AsociadoController : ApiController
    {
        // GET: api/Asociado
        public IEnumerable<Asociado> Get()
        {
            GestorAsociado gAsociado = new GestorAsociado();
            return gAsociado.getAsociados();
        }

        // GET: api/Asociado/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Asociado
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Asociado/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Asociado/5
        public void Delete(int id)
        {
        }
    }
}
