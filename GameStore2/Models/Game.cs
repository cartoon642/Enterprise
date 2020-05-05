using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameStore2.Models
{
    public class Game
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Picture { get; set; }
        
        [Required]
        public int CategoryId { get; set; }
        
        public Category Category { get; set; }
    }
}