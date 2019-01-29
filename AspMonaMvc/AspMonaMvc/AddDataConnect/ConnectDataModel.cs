using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AspMonaMvc.Models;

namespace AspMonaMvc.AddDataConnect
{
    public class ConnectDataModel : DbContext
    {
        public ConnectDataModel() : base("MonaDBConnection")
        {
        }

        public DbSet<ContactUserModel> ContactUserModels { get; set; }
        public DbSet<HomePageChange> HomePageChanges { get; set; }
        public DbSet<ModellsChange> ModellsChanges { get; set; }
        public DbSet<ModelCategory>  ModelCategories { get; set; }
        public DbSet<MonaTeamModel>  MonaTeamModels { get; set; }
        public DbSet<CastingModel>  CastingModels { get; set; }
        public DbSet<LatestNewsContent>  LatestNewsContents { get; set; }

        public DbSet<ImageContent> ImageContents { get; set; }

        public DbSet<ClientsFedbackModel> ClientsFedbackModels { get; set; }

        public DbSet<ContactDetalis> ContactDetalis { get; set; }

        public DbSet<Social> Socials { get; set; }
    }
}