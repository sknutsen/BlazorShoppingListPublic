using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShoppingList.Data.Models
{
    public class user_
    {
        [Key]
        public int uid { get; set; }
        public string uname { get; set; }
        public string passw { get; set; }
        public int gid { get; set; }
    }
}
