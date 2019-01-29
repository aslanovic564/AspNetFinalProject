using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspMonaMvc.Models
{
    public class HomePageChange
    {

        public HomePageChange()
        {
            this.ImageContents = new HashSet<ImageContent>();
            this.latestNewsContents = new HashSet<LatestNewsContent>();
        }
        [Key]
        public int Id { get; set; }

        
        [MinLength(10)]
        public string Facebook { get; set; }

        [MinLength(10)]
        public string Tviter { get; set; }

        [MinLength(10)]
        public string Pinterest { get; set; }

        [MinLength(10)]
        public string Instagram { get; set; }

        [MinLength(10)]
        public string Youtube { get; set; }


        public ICollection<LatestNewsContent>  latestNewsContents { get; set; }

        public virtual ICollection<ImageContent> ImageContents { get; set; }

    }
}