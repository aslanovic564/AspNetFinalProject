using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace AspMonaMvc.Models
{
    public class ModelCategory
    {
        public ModelCategory()
        {
            ModellsChanges = new List<ModellsChange>();

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

 
        [MaxLength(50)]
        public string CategoryName { get; set; }

        public List<ModellsChange> ModellsChanges { get; set; }

      

    }
}