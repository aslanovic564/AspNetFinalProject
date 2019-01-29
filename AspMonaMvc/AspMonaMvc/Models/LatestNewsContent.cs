using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspMonaMvc.Models
{
    public class LatestNewsContent
    {
        public LatestNewsContent()
        {
            this.ImageContents = new HashSet<ImageContent>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        public string NewsImageUrl { get; set; }

        [Required]
        public string ImageDescription { get; set; }


        public DateTime Date { get; set; }

        public virtual ICollection<ImageContent> ImageContents { get; set; }
    }
}