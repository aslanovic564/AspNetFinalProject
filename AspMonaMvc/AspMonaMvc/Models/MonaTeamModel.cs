using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspMonaMvc.Models
{
    public class MonaTeamModel
    {

        public MonaTeamModel()
        {
            this.ImageContents = new HashSet<ImageContent>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

       
        [Required]
        [Display(Name = "Sekilin alt yazisi")]
        public string TeamImagesDescription { get; set; }

        [Required]
        [Display(Name = "Ad ve Soyad")]
        public string NameTeam { get; set; }

        [Required]
        [Display(Name = "Komandanin vezifesi")]
        public string  statusTeam { get; set; }

        public virtual ICollection<ImageContent> ImageContents { get; set; }
    }
}