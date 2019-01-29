using AspMonaMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspMonaMvc.ViewModels
{
    public class HomePageViewModel
    {
        public HomePageViewModel()
        {
            ModellsChangesAll = new HashSet<ModellsChange>();
            ModellsChanges = new HashSet<ModellsChange>();
            ModellsChangesModel = new HashSet<ModellsChange>();
            ModellsChangesActor  = new HashSet<ModellsChange>();
            ModellsChangesSinger = new HashSet<ModellsChange>();
            ClientsFedbackModels = new HashSet<ClientsFedbackModel>();
            ModellsChangesCasting = new HashSet<ModellsChange>();
            ModelCategories = new HashSet<ModelCategory>();
            Images = new List<ImageContent>();
            Socials = new List<Social>();
        }

        public ICollection<ModellsChange> ModellsChanges { get; set; }
        public ICollection<ModellsChange> ModellsChangesAll { get; set; }
        public ICollection<ModellsChange> ModellsChangesModel { get; set; }
        public ICollection<ModellsChange> ModellsChangesActor { get; set; }
        public ICollection<ModellsChange> ModellsChangesSinger { get; set; }
        public ICollection<ClientsFedbackModel> ClientsFedbackModels { get; set; }
        public ICollection<ModellsChange> ModellsChangesCasting { get; set; }
        public ICollection<ModelCategory> ModelCategories { get; set; }
     
        public List<ImageContent> Images { get; set; }
        public List<HomePageChange> HomePageChanges { get; set; }
        public List<Social>  Socials { get; set; }

    }
}