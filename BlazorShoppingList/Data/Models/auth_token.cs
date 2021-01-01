using Npgsql.TypeHandlers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShoppingList.Data.Models
{
    public class auth_token
    {
        [Key]
        public int id { get; set; }
        public Guid token { get; set; }
        public int user { get; set; }
    }
}
