using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspMonaMvc.Models
{
    public class ImageContent
    {
    

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string  ImageUrlName { get; set; }
        
        public virtual MonaTeamModel   MonaTeamModel { get; set; }

        [Required]
        public int MonaTeamModelId { get; set; }

        public virtual LatestNewsContent   LatestNewsContent  { get; set; }

        [Required]
        public int LatestNewsContentId { get; set; }

       
        public virtual ClientsFedbackModel ClientsFedbackModels { get; set; }

        [Required]
        public int ClientsFedbackModelsId { get; set; }

        public virtual ModellsChange   ModellsChange { get; set; }

        [Required]
        public int ModellsChangeId { get; set; }


        public virtual HomePageChange HomePageChange { get; set; }

        [Required]
        public int HomePageChangeId { get; set; }
       

      

    }
}