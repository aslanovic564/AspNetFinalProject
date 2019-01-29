using AspMonaMvc.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspMonaMvc.Models
{
    public class CastingModel
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        public string CastHeader { get; set; }


        [MaxLength(500)]
        public string CastResumeHeader { get; set; }


        public virtual ImageContent ImageContent { get; set; }


        public int ImageContentId { get; set; }


    }
}