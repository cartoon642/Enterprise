using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameStore2.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}