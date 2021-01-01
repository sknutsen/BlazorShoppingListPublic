using BlazorShoppingList.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShoppingList.Data
{
    public class Storage
    {
        public int shoppingList { get; set; }
        public List<shopping_list> shoppingLists { get; set; }
        public List<item> items { get; set; }
        public Guid userToken { get; set; }
    }
}
