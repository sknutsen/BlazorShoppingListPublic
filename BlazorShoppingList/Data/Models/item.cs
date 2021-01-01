using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShoppingList.Data.Models
{
    public class item
    {
        [Key]
        public int iid { get; set; }
        [Required]
        public string iname { get; set; }
        [Required]
        public int ammount { get; set; }
        public int added_by { get; set; }
        public int slid { get; set; }
        public bool sold_out { get; set; }
    }
}
