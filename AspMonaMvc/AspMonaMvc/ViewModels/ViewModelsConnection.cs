using AspMonaMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspMonaMvc.ViewModels
{
    public class ViewModelsConnection
    {
        public ViewModelsConnection()
        {
            ImageContents = new List<ImageContent>();
        }
        public MonaTeamModel MonaTeamModel { get; set; }
        public ContactUserModel  ContactUserModel { get; set; }
        public CastingModel CastingModel  { get; set; }
        public List<ImageContent> ImageContents { get; set; }

    }
}