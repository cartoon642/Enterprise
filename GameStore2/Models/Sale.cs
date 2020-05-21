using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameStore2.Models
{
    public class Sale
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Index("unique", 1, IsUnique = true)]
        public int GameId { get; set; }
        public Game Game { get; set; }
        [Required]
        [Index("unique", 4, IsUnique = true)]
        public int Quantity { get; set; }
        public Quality Quality { get; set; }
        [Required]
        public int QualityID { get; set; }
        [Required]
        [Index("unique", 2, IsUnique = true)]
        public double price {get;set;}
        
        public ApplicationUser User { get; set; }
        [Required]
        [Index("unique", 3, IsUnique = true)]
        public string Userid { get; set; }
    }
}