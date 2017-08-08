using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hermeco.TV.Data.Models.Mappings
{
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Table("users");
            Id(d => d.Id);
            Map(d => d.Name).Column("name");
            Map(d => d.LastName).Column("last_name");
            Map(d => d.Mail).Column("mail");
            Map(d => d.State).Column("state");
            Map(d => d.Phone).Column("phone");
            Map(d => d.Time).Column("time");            
        }
    }
}