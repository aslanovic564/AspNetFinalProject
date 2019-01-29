using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspMonaMvc.Models
{
    public class ClientsFedbackModel
    {
        public ClientsFedbackModel()
        {
            ImageContents = new List<ImageContent>();
        }
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        public string ClientName { get; set; }



        public string ClientStatus { get; set; }

        [MaxLength(500),MinLength(100)]
        public string  Descriptions { get; set; }


        public  List<ImageContent>   ImageContents { get; set; }

       
    }
}