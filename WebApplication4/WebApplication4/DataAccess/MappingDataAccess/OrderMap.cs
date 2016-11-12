using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebApplication4.Models;
namespace WebApplication4.DataAccess.MappingDataAsses
{
    public class OrderMap : EntityTypeConfiguration<Orders>
    {
        public OrderMap()
        {
            ToTable("Orders");
            HasKey(x => x.Id);
            HasMany(x => x.OrderPositions);
            HasRequired(x => x.Customer);
            
   
        }
    }
}