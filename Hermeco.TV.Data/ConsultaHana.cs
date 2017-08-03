using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Hermeco.TV.Data
{
    public class ConsultaHana : HMService
    {
        public DataSet ObtenerInfo()
        {
            DataSet ds = this.RequestResult();            
            return ds;           
        }
    }
    
}