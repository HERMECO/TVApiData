using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hermeco.TV.Data.Models
{
    public class Usuario
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Mail { get; set; }
        public virtual string State { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Time { get; set; }
    }
}