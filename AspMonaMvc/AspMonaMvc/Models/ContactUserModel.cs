using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspMonaMvc.Models
{
    public class ContactUserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [MaxLength(15)]
        [Required]
        public string UserName { get; set; }

        [MaxLength(30)]
        [Required]
        public string UserEmail { get; set; }

        [Required]
        [MinLength(40)]
        public string UserResume { get; set; }
    }
}