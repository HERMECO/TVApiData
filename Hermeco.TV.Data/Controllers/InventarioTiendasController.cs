using Hermeco.TV.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hermeco.TV.Data.Controllers
{
    public class InventarioTiendasController : ApiController
    {
        // GET api/values
        public List<InventarioTienda> Get()
        {
            InventarioTienda inventario = new InventarioTienda();
            List<InventarioTienda> listInventario = inventario.ObtenerInventarioTienda("895758");
            return listInventario;
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public List<InventarioTienda> Get(string id)
        {
            InventarioTienda inventario = new InventarioTienda();
            List<InventarioTienda> listInventario = inventario.ObtenerInventarioTienda(id);
            return listInventario;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}