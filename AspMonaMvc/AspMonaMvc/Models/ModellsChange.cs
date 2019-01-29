using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AspMonaMvc.Models
{
    public class ModellsChange
    {
        public ModellsChange()
        {
            ImageContents = new List<ImageContent>();
            Socials = new List<Social>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      
        public int Id { get; set; }

        public string ModelFullName { get; set; }

        public string FigurStatus { get; set; }


        public ModelCategory ModelCategory { get; set; }

        [Required]
        public int ModelCategoryId { get; set; }

        public List<ImageContent> ImageContents { get; set; }

        public List<Social> Socials { get; set; }

    }
}