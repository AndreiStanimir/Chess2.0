using Chess20.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Chess20
{
    public class ChessDbContext : DbContext
    {
        public ChessDbContext() : base("ChessDBConnectionString")
        {
            //Database.SetInitializer(new ChessDBInitializer());
        }

        public System.Data.Entity.DbSet<Chess20.Models.Game> Games { get; set; }
    }
}