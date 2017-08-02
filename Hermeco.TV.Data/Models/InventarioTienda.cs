using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Hermeco.TV.Data.Models
{
    public class InventarioTienda : HMService
    {
        public string PLU { get; set; }
        public string Material { get; set; }
        public string ValorMat { get; set; }
        public string Inventario { get; set; }
        public string Centro { get; set; }
        public string NombreTienda { get; set; }
        public string Direccion { get; set; }
        public string Poblacion { get; set; }

        public List<InventarioTienda> ObtenerInventarioTienda(string plu)
        {
            this.queryParameters.Clear();
            this.objectName = "ObtenerInventarioTienda";

            List<InventarioTienda> listInventario = new List<InventarioTienda>();
            this.queryParameters.Add("@plu", plu);
            DataSet ds = this.RequestResult();
            

            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    InventarioTienda inventario = new InventarioTienda();
                    inventario.PLU = dr["PLU"].ToString();
                    inventario.Material = dr["Material"].ToString();
                    inventario.ValorMat = dr["Valor Matriz"].ToString();
                    inventario.Inventario = dr["Libre Utilizacion"].ToString();
                    inventario.Centro = dr["Centro"].ToString();
                    inventario.NombreTienda = dr["Nombre tienda"].ToString();
                    inventario.Poblacion = dr["Poblacion"].ToString();

                    listInventario.Add(inventario);
                }
            }


            
            //this.queryParameters.Add("@fecha1", "20160621");
            //this.queryParameters.Add("@fecha2", "20160628");

            return listInventario;
        }
    }
}