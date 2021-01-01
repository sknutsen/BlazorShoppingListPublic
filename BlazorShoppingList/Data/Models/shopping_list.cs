using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShoppingList.Data.Models
{
    public class shopping_list
    {
        [Key]
        public int slid { get; set; }
        public string slname { get; set; }
        public int gid { get; set; }
    }
}
