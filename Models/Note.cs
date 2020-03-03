using System.Data.Common;
using System;
using todonote.Data;
using System.ComponentModel.DataAnnotations;

namespace todonote.Models {
    public class Note {
        public int ID { get; set; }
        
        [Required]
        [StringLength(200, MinimumLength = 10)]
        public string Content { get; set; }

        [Required]
       [StringLength(200, MinimumLength = 1)]
        public string Author { get; set; }

        public string PhotoPath { get; set; }
    }
}