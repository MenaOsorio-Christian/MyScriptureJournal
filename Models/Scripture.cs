using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MyScriptureJournal.Models
{
    public class Scripture
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Book { get; set; }

        [Range(1, 100)]
        public int Chapter { get; set; }
        public int Verse { get; set; }

        [StringLength(150, MinimumLength = 3)]
        [Required]
        public string Note { get; set; }
        
        [Display(Name = "Entry Date"), DataType(DataType.Date)]
        public DateTime EntryDate { get; set; }



    }
}
