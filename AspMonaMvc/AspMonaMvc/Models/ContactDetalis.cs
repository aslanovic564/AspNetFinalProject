using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspMonaMvc.Models
{
    public class ContactDetalis
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(200)]
        [Required]
        public string ContactDetaliss { get; set; }

        public string Reception { get; set; }

        public string Booking { get; set; }

        public string President { get; set; }

    }
}