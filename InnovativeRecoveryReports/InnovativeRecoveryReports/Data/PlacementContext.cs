using InnovativeRecoveryReports.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace InnovativeRecoveryReports.Data
{
    public class PlacementContext : DbContext
    {
        public PlacementContext() : base("PlacementContext")
        {
            //this.Database.Connection.ConnectionString = "Server=localhost\\SQLEXPRESS;Database=master;User Id=saa;Password=Asdfasdf1!;Integrated Security=False;";
            this.Database.Connection.ConnectionString = "Server=IR-SQL-DEV1;Database=AGENCY;Database=agency;Trusted_Connection=True;";

        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    Database.SetInitializer<MyContext>(null);
        //    base.OnModelCreating(modelBuilder);
        //}

        public virtual DbSet<Placement> Placements { get; set; }
 
    }
}
